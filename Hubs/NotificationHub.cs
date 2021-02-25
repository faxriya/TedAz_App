using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using TedAz.Data.Models;
using TedAzApp.DataContext.Models;
using TedAzApp.Extensions;
using TedAzApp.Models;
using static TedAzApp.Models.NoteViewModel;

namespace TedAzApp.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly UserManager<User> _userManager;

        public NotificationHub(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        //  public static string sqlDataSource = "Data Source=localhost;Initial Catalog = MHM.Accountancy.Database; Integrated Security=True";
        //  public static string sqlDataSource = "Server=SQL5097.site4now.net;Database=DB_A50752_webhook;User Id = DB_A50752_webhook_admin; Password=webHook@002;";
        public override Task OnConnectedAsync()
        {
            var sdf = new ClaimsPrincipal();
            var user = _userManager.GetUserAsync(sdf);
            var data = Context.User;
            //var data = HttpContext.Session.Get<Models.User>("user");

            using (var context = new TedAzContext())

            {
                //context.Database.ExecuteSqlInterpolated($"exec [dbo].[SaveNotes] @au={}")
                //var data=SessionExtension.Get<Models.User>("user").UserName
                //Session.Get<TedAzApp.Models.User>("user").UserName;
                //var temaName = context.NotesAuthors
                //                      .Where(s => s.AuthorName == "filankes")
                //                      .ToList();
                //AddToGroup(temaName.FirstOrDefault().AuthorNickName);
            }

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }
        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user);
            try
            {
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(user);
                Author author = myDeserializedClass.author;
                Channel channel = myDeserializedClass.channel;
                IEnumerable<Author> authordata = new[] { author };
                IEnumerable<Channel> channeldata = new[] { channel };
                IEnumerable<Root> rootdata = new[] { myDeserializedClass };
                var tableauthor = Extension.ToDataTable(authordata);
                var tablechannel = Extension.ToDataTable(channeldata);
                var tableroot = Extension.ToDataTable(rootdata);
                List<SqlParameter> parameters = Extension.Init()
                .Add("@author", tableauthor, "[dbo].[uddtNotesAuthor]")
                .Add("@channel", tablechannel, "[dbo].[uddtNotesAuthor]")
                .Add("@root", tableroot, "[dbo].[uddtNotesRoot]");
                 
                using (var context = new TedAzContext())
                {
                    var data = context.ExecuteProcedure<RootViewModel>("[dbo].[SaveNotes]", parameters);
                    using (var cmd = context.Database.GetDbConnection().CreateCommand())
                    {
                  
                        cmd.CommandText = "[dbo].[SaveNotes]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            if (parameters != null)
                                cmd.Parameters.AddRange(parameters.ToArray());

                            await cmd.Connection.OpenAsync();

                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            cmd.Connection.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }




            // await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

}
