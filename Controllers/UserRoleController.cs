using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TedAzApp.Models;
using TedAzApp.Models.ViewModels;
using TedAzApp.Services;

namespace TedAzApp.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserRoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region Role

        public IActionResult RoleIndex() => View(_roleManager.Roles.OrderBy(e => e.Name).ToList());

        public IActionResult RoleCreate() => View();

        [HttpPost]
        public async Task<IActionResult> RoleCreate(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleIndex");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> RoleDelete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("RoleIndex");
        }

        public IActionResult RoleUserList() => View(_userManager.Users.OrderBy(e => e.UserName).ToList());

        public async Task<IActionResult> RoleEdit(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.Select(e => new Role(e, userRoles.Contains(e.Name))).ToList();
                //var allRoles = _roleManager.Roles.Select(e => (Role)e).ToList();
                //allRoles.ForEach(e => e.Checked = userRoles.Contains(e.Name));
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("RoleUserList");
            }

            return NotFound();
        }

        #endregion Role

        #region User

        public IActionResult UserIndex() => View(_userManager.Users.ToList());

        public IActionResult UserCreate() => View();

        [HttpPost]
        public async Task<IActionResult> UserCreate(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await EmailService.SendEmailAsync(model.Email, "TedAz Registration", "Login: " + model.Email + "\nPassword: " + model.Password);
                    return RedirectToAction("UserIndex");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserIndex");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UserDelete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("UserIndex");
        }

        public async Task<IActionResult> UserChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                    await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserIndex");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User is not found");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UsersCreate(string filePath)
        {
            var errors = new List<IdentityError>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
                    };

                    var dataSet = reader.AsDataSet(conf);
                    var dataTable = dataSet.Tables[0];

                    string pass;
                    var userList = new List<User>();
                    for (var i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var user = new User()
                        {
                            TopicId = int.Parse(dataTable.Rows[i]["TopicId"].ToString()),
                            Email = dataTable.Rows[i]["Email"].ToString()
                        };
                        user.UserName = user.Email;
                        pass = GetRandomPassword(10);

                        var result = await _userManager.CreateAsync(user, pass);

                        errors.AddRange(result.Errors);
                        if (errors.Count > 0)
                        {
                            foreach (var error in errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }

                            continue;
                        }

                        await EmailService.SendEmailAsync(user.Email, "TedAz Registration", "Login: " + user.Email + "\nPassword: " + pass);
                    }
                }
            }

            return RedirectToAction("IndexUsers", "Admin");
        }

        public static string GetRandomPassword(int length)
        {
            byte[] rgb = new byte[length];
            RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            rngCrypt.GetBytes(rgb);
            var pass = Convert.ToBase64String(rgb);

            var numbers = "0123456789";
            StringBuilder sb = new StringBuilder(pass);
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(numbers.Length);
                sb.Append(numbers[index]);
            }

            return sb.ToString();
        }

        #endregion User
    }
}
