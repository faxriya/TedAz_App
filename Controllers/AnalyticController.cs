using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TedAz.Data.Models;
using TedAzApp.DataContext.Models;

namespace TedAzApp.Controllers
{
    public class AnalyticController : Controller
    {
        public IActionResult Analitics(int? id=null)
        {
            
            return View();
      
        }
        public IActionResult DataWords()
        {

            var JsonData = "";
            var idnext = new SqlParameter("@id", 11);
            var filters = new SqlParameter("@pJson", string.Empty);
            using (var context = new TedAzContext())
            {
                var data = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();//worldcolud                        
                JsonData = JsonSerializer.Serialize(data);
            }
            return Json(JsonData);
        }
        public IActionResult Data(int id,string data)
        {
            // var JsonData = "";
            if (data == null)
                data = string.Empty;
            var idnext = new SqlParameter("@id", id);
            var filters = new SqlParameter("@pJson", data);
            List<AnalyticData> dataresult = new List<AnalyticData>();
           
            using (var context = new TedAzContext())
            {

             //   var folderDetails = "";
                switch (id)
                {

                    case 2:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();

                        break;
                    case 4:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();

                        break;
                    case 6:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();

                        break;
                    case 8:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();

                        break;
                    case 11:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();//worldcolud

                        break;
                    case 12:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();//worldcolud

                        break;
                    default:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetAnalytics](@id,@pJson)", idnext, filters).ToList();
                        break;
                }
                var JSON = JsonSerializer.Serialize(dataresult);
                // Histogram myDeserializedClass = JsonConvert.DeserializeObject<Histogram>(JSON);
                return Json(JSON);

               


            }


        }
        public IActionResult Links()
        {
            var JsonData = "";
            using (var context = new TedAzContext())
            {

                var data = context.LinkData.FromSqlRaw("exec   [dbo].[GetLinks]");
                JsonData = JsonSerializer.Serialize(data);
            }
            return Json(JsonData);

        }
        public IActionResult Filters(int id)
        {
           
            var idfilter = new SqlParameter("@id", id);
            List<AnalyticData> dataresult = new List<AnalyticData>();

            using (var context = new TedAzContext())
            {

                //   var folderDetails = "";
                switch (id)
                {
                   
                    case 4:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetFilters](@id)", idfilter).ToList();

                        break;
                    case 6:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetFilters](@id)", idfilter).ToList();

                        break;
                   
                    case 11:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetFilters](@id)", idfilter).ToList();//worldcolud

                        break;                   
                    default:
                        dataresult = context.AnalyticData.FromSqlRaw("Select * from [dbo].[fnGetFilters](@id)", idfilter).ToList();
                        break;
                }
                var JSON = JsonSerializer.Serialize(dataresult);
                return Json(JSON);




            }



        }
    }
}
