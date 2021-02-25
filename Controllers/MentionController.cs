using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TedAz.Data.Models;

namespace TedAzApp.Controllers
{
    public class MentionController : Controller
    {
        public IActionResult Notes()
        {
            return View();
          
        }
        public IActionResult DataNotes(int id)
        {
            var JsonData = "";
            using (var context = new TedAzContext())
            {
                var idnote = new SqlParameter("@id", id);
                var data = context.Posts.FromSqlRaw("exec [dbo].[GetNotes] @id", idnote);
                JsonData = JsonSerializer.Serialize(data);
            }
            return Json(JsonData);
 
        }

        public IActionResult Authors()
        {
           
            return View();
        }


        public IActionResult Author()
        {
            var JsonData = "";
            using (var context = new TedAzContext())
            {

                var data = context.AuthorViewModels.FromSqlRaw("exec [dbo].[GetAuthorInfo]");
                JsonData = JsonSerializer.Serialize(data);   
            }

            return Json(JsonData);
        }
    }
}
