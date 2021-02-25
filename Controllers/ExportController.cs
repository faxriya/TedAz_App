using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TedAz.Data.Models;
using TedAzApp.Extensions;
namespace TedAzApp.Controllers
{
    public class ExportController : Controller
    {

        private readonly IWebHostEnvironment _appEnvironment;

        // private readonly TedAzContext context;

        public ExportController(IWebHostEnvironment appEnvironment)
        {

            _appEnvironment = appEnvironment;


        }
        public async Task<JsonResult> Reportajax(string fromdate, string todate, string reporttype)
        {
            using (var context = new TedAzContext())
            {

                if (reporttype == "1")
                {

                    try
                    {
                        //DateTime enddate = Convert.ToDateTime(todate.ToString(), CultureInfo.InvariantCulture);
                        var begidadteparam = new SqlParameter("@fromdate", fromdate);
                        var enddateparamm = new SqlParameter("@todate", todate);
                        // var q = context.ReportsMention.FromSqlRaw("exec [reports].[ReportsMentionTest] @fromdate, @todate", begidadteparam, enddateparamm).ToList();
                        var q = context.MentionReport.FromSqlRaw("exec [reports].[ReportsMention] @fromdate, @todate", begidadteparam, enddateparamm).ToList();
                        string reporturl = "ReportsInExcel/Ted_Az_Mentions" + fromdate.Substring(0, 10) + "-" + todate.Substring(0, 10) + ".xlsx";
                        var workbook = new XLWorkbook();
                        var sheet = workbook.Worksheets.Add("Qeydlər");
                        var table = sheet.Cell(1, 1).InsertTable(q, "Report", false);
                        workbook.SaveAs(reporturl);
                        var period = fromdate.Substring(0, 10) + "-" + todate.Substring(0, 10);
                        var reportname = "Ted_Az_Mentions" + fromdate.Substring(0, 10) + "-" + todate.Substring(0, 10) + ".xlsx";
                        List<SqlParameter> parameters = Extension.Init()
                        .Add("@userid", 3)
                        .Add("@reporttype", "Qeydlər")
                        .Add("@period", period)
                        .Add("@reporturl", reporturl)
                        .Add("@reportname", reportname);
                        using (var cmd = context.Database.GetDbConnection().CreateCommand())
                        {
                            cmd.CommandText = "[reports].[SaveReportInfo]";
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
                    catch (Exception ex)
                    {
                        throw ex;
                    }





                }
                if (reporttype == "2")
                {

                    try
                    {
                        var begidadteparam = new SqlParameter("@fromdate", fromdate);
                        var enddateparamm = new SqlParameter("@todate", todate);
                        var q = context.ReportsMention.FromSqlRaw("exec [reports].[ReportsMentionWithFullTextTest] @fromdate, @todate", begidadteparam, enddateparamm).ToList();
                        string reporturl = "ReportsInExcel/Ted_Az_MentionsWitFullText" + fromdate.Substring(0, 10) + "-" + todate.Substring(0, 10) + ".xlsx";
                        var workbook = new XLWorkbook();
                        var sheet = workbook.Worksheets.Add("Qeydlər(tam mətn)");
                        var table = sheet.Cell(1, 1).InsertTable(q, "Report", false);
                        workbook.SaveAs(reporturl);
                        var period = fromdate.Substring(0, 10) + "-" + todate.Substring(0, 10);
                        var reportname = "Ted_Az_Mentions" + fromdate.Substring(0, 10) + "-" + todate.Substring(0, 10) + ".xlsx";
                        List<SqlParameter> parameters = Extension.Init()
                        .Add("@userid", 3)
                        .Add("@reporttype", "Qeydlər(tam mətn)")
                        .Add("@period", period)
                        .Add("@reporturl", reporturl)
                        .Add("@reportname", reportname);
                        using (var cmd = context.Database.GetDbConnection().CreateCommand())
                        {
                            cmd.CommandText = "[reports].[SaveReportInfo]";
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
                    catch (Exception ex)
                    {
                        throw ex;
                    }






                }
            }
            string status = "Ok";
            return Json(status);
        }

        public IActionResult DownloadsReport(string filename, string reporturl)
        {
            string path = Path.Combine(_appEnvironment.ContentRootPath, reporturl);
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string file_name = filename;
            return File(mas, file_type, file_name);
        }

        public IActionResult Downloads()
        {
            return View();
        }

        public IActionResult GetReportsInfo()
        {
            using (var context = new TedAzContext())
            {
                var q2 = context.GetReportsInfo.FromSqlRaw("exec reports.GetReportsInfo").ToList();
                ///return View(q2);
                string jsondat1 = System.Text.Json.JsonSerializer.Serialize(q2);
                return Json(jsondat1);
            }
        }

    }
}
