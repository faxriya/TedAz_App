using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TedAz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void ProccessFiles(string path)
        {
        
            ////var filesPathList = Directory.GetFiles(@"D:\MHM projects\TedAz_Excel\ADY noyabr - yanvar\ADY noyabr - yanvar");
             
            var filesPathList = Directory.GetFiles(path);
            foreach (var file in filesPathList)
            {
                SqlBulkInsertScript(file);
            }
            Console.WriteLine("Finished!");
        }

        static void SqlBulkInsertScript(string file)
        {
            string connectionStr = $@"Server=SQL5097.site4now.net;Database=DB_A50752_webhook;User Id = DB_A50752_webhook_admin; Password=webHook@002;";
            //string excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties=\"Excel 12.0\";Persist Security Info=False;", $@"D:\MHM projects\TedAz_Excel\ADY noyabr - yanvar\ADY noyabr - yanvar\MentionsWithFullText_ADY_ 18.11.2020 (00.00 - 00.00).xlsx");
            string excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties=\"Excel 12.0\";Persist Security Info=False;", file);
            try
            {
                using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
                {
                    //Create OleDbCommand to fetch data from Excel 
                    using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Mentions$]", excelConnection))
                  //  using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [����������$]", excelConnection))
                    {
                        excelConnection.Open();
                        using (OleDbDataReader dReader = cmd.ExecuteReader())
                        {
                            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(connectionStr, SqlBulkCopyOptions.KeepIdentity))
                            {
                                //Give your Destination table name 
                                sqlBulk.BatchSize = 5_000;
                                sqlBulk.DestinationTableName = "Posts";
                                #region EnglishVersion
                                sqlBulk.ColumnMappings.Add("Date", "PostDate");
                                sqlBulk.ColumnMappings.Add("Time", "PostTime");
                                sqlBulk.ColumnMappings.Add("Saved at", "PostSavedAt");
                                sqlBulk.ColumnMappings.Add("Title", "PostTitle");
                                sqlBulk.ColumnMappings.Add("Text", "PostText");
                                sqlBulk.ColumnMappings.Add("Post type", "PostType");
                                sqlBulk.ColumnMappings.Add("URL", "PostUrl");
                                sqlBulk.ColumnMappings.Add("Sentiment", "PostSentiment");
                                sqlBulk.ColumnMappings.Add("Author", "PostAuthor");
                                sqlBulk.ColumnMappings.Add("Profile", "AuthorsProfile");
                                sqlBulk.ColumnMappings.Add("Subscribers", "AuthorsSubscribersCount");
                                sqlBulk.ColumnMappings.Add("Demography", "PostDemography");
                                sqlBulk.ColumnMappings.Add("Age", "AuthorsAge");
                                sqlBulk.ColumnMappings.Add("Source", "PostSource");
                                sqlBulk.ColumnMappings.Add("Publication place", "PostPublicationPlace");
                                sqlBulk.ColumnMappings.Add("Publication place profile", "PostPublicationPlaceProfile");
                                sqlBulk.ColumnMappings.Add("Publication place subscribers", "PostPublicationPlaceSubscribersCount");
                                sqlBulk.ColumnMappings.Add("Resource type", "PostSourceType");
                                sqlBulk.ColumnMappings.Add("Country", "PostCountry");
                                sqlBulk.ColumnMappings.Add("Regions", "PostRegion");
                                sqlBulk.ColumnMappings.Add("City", "PostCity");
                                sqlBulk.ColumnMappings.Add("Notes", "PostNotes");
                                sqlBulk.ColumnMappings.Add("Reactions", "PostReactionsSum");
                                sqlBulk.ColumnMappings.Add("Likes", "PostLikesCount");
                                sqlBulk.ColumnMappings.Add("Love", "PostLoveCount");
                                sqlBulk.ColumnMappings.Add("Haha", "PostHahaCount");
                                sqlBulk.ColumnMappings.Add("Wow", "PostWowCount");
                                sqlBulk.ColumnMappings.Add("Sad", "PostSadCount");
                                sqlBulk.ColumnMappings.Add("Angry", "PostAngryCount");
                                sqlBulk.ColumnMappings.Add("Dislikes", "PostDislikesCount");
                                sqlBulk.ColumnMappings.Add("Comments", "PostCommentsCount");
                                sqlBulk.ColumnMappings.Add("Reposts", "PostRepostsCount");
                                sqlBulk.ColumnMappings.Add("Views", "PostViewsCount");
                                sqlBulk.ColumnMappings.Add("Rating", "PostRatingCount");
                                sqlBulk.ColumnMappings.Add("Image URL", "PostImageUrl");
                                sqlBulk.ColumnMappings.Add("Assigned to", "PostAssignedTo");
                                sqlBulk.ColumnMappings.Add("Processed", "PostProcessed");

                                #endregion

                                //#region Rus Dayjest
                                //sqlBulk.ColumnMappings.Add("����", "PostDate");
                                //sqlBulk.ColumnMappings.Add("�����", "PostTime");
                                //sqlBulk.ColumnMappings.Add("���������", "PostTitle");
                                //sqlBulk.ColumnMappings.Add("�������� ������", "PostText");
                                //sqlBulk.ColumnMappings.Add("��� �����", "PostType");
                                //sqlBulk.ColumnMappings.Add("URL", "PostUrl");
                                //sqlBulk.ColumnMappings.Add("�����������", "PostSentiment");
                                //sqlBulk.ColumnMappings.Add("�����", "PostAuthor");
                                //sqlBulk.ColumnMappings.Add("�������", "AuthorsProfile");
                                //sqlBulk.ColumnMappings.Add("����������", "AuthorsSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("����������", "PostDemography");
                                //sqlBulk.ColumnMappings.Add("�������", "AuthorsAge");
                                //sqlBulk.ColumnMappings.Add("��������", "PostSource");
                                //sqlBulk.ColumnMappings.Add("����� ����������", "PostPublicationPlace");
                                //sqlBulk.ColumnMappings.Add("������� ����� ����������", "PostPublicationPlaceProfile");
                                //sqlBulk.ColumnMappings.Add("���������� ����� ����������", "PostPublicationPlaceSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("��� ���������", "PostSourceType");
                                //sqlBulk.ColumnMappings.Add("������", "PostCountry");
                                //sqlBulk.ColumnMappings.Add("�������", "PostNotes");
                                //sqlBulk.ColumnMappings.Add("����� ���� �������", "PostReactionsSum");
                                //sqlBulk.ColumnMappings.Add("�����", "PostLikesCount");
                                //sqlBulk.ColumnMappings.Add("Love", "PostLoveCount");
                                //sqlBulk.ColumnMappings.Add("Haha", "PostHahaCount");
                                //sqlBulk.ColumnMappings.Add("Wow", "PostWowCount");
                                //sqlBulk.ColumnMappings.Add("Sad", "PostSadCount");
                                //sqlBulk.ColumnMappings.Add("Angry", "PostAngryCount");
                                //sqlBulk.ColumnMappings.Add("Dislikes", "PostDislikesCount");
                                //sqlBulk.ColumnMappings.Add("�����������", "PostCommentsCount");
                                //sqlBulk.ColumnMappings.Add("�������", "PostRepostsCount");
                                //sqlBulk.ColumnMappings.Add("���������", "PostViewsCount");
                                //sqlBulk.ColumnMappings.Add("�������", "PostRatingCount");
                                //sqlBulk.ColumnMappings.Add("URL �����������", "PostImageUrl");
                                //#endregion

                                #region Rus Full Text
                                //sqlBulk.ColumnMappings.Add("����", "PostDate");
                                //sqlBulk.ColumnMappings.Add("�����", "PostTime");
                                //sqlBulk.ColumnMappings.Add("���������", "PostTitle");
                                //sqlBulk.ColumnMappings.Add("�����", "PostText");
                                //sqlBulk.ColumnMappings.Add("��� �����", "PostType");
                                //sqlBulk.ColumnMappings.Add("URL", "PostUrl");
                                //sqlBulk.ColumnMappings.Add("�����������", "PostSentiment");
                                //sqlBulk.ColumnMappings.Add("�����", "PostAuthor");
                                //sqlBulk.ColumnMappings.Add("�������", "AuthorsProfile");
                                //sqlBulk.ColumnMappings.Add("����������", "AuthorsSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("����������", "PostDemography");
                                //sqlBulk.ColumnMappings.Add("�������", "AuthorsAge");
                                //sqlBulk.ColumnMappings.Add("��������", "PostSource");
                                //sqlBulk.ColumnMappings.Add("����� ����������", "PostPublicationPlace");
                                //sqlBulk.ColumnMappings.Add("������� ����� ����������", "PostPublicationPlaceProfile");
                                //sqlBulk.ColumnMappings.Add("���������� ����� ����������", "PostPublicationPlaceSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("��� ���������", "PostSourceType");
                                //sqlBulk.ColumnMappings.Add("������", "PostCountry");
                                //sqlBulk.ColumnMappings.Add("�������", "PostNotes");
                                //sqlBulk.ColumnMappings.Add("����� ���� �������", "PostReactionsSum");
                                //sqlBulk.ColumnMappings.Add("�����", "PostLikesCount");
                                //sqlBulk.ColumnMappings.Add("Love", "PostLoveCount");
                                //sqlBulk.ColumnMappings.Add("Haha", "PostHahaCount");
                                //sqlBulk.ColumnMappings.Add("Wow", "PostWowCount");
                                //sqlBulk.ColumnMappings.Add("Sad", "PostSadCount");
                                //sqlBulk.ColumnMappings.Add("Angry", "PostAngryCount");
                                //sqlBulk.ColumnMappings.Add("Dislikes", "PostDislikesCount");
                                //sqlBulk.ColumnMappings.Add("�����������", "PostCommentsCount");
                                //sqlBulk.ColumnMappings.Add("�������", "PostRepostsCount");
                                //sqlBulk.ColumnMappings.Add("���������", "PostViewsCount");
                                //sqlBulk.ColumnMappings.Add("�������", "PostRatingCount");
                                //sqlBulk.ColumnMappings.Add("URL �����������", "PostImageUrl"); 
                                #endregion

                                sqlBulk.WriteToServer(dReader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
