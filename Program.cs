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
                  //  using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Упоминания$]", excelConnection))
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
                                //sqlBulk.ColumnMappings.Add("Дата", "PostDate");
                                //sqlBulk.ColumnMappings.Add("Время", "PostTime");
                                //sqlBulk.ColumnMappings.Add("Заголовок", "PostTitle");
                                //sqlBulk.ColumnMappings.Add("Дайджест текста", "PostText");
                                //sqlBulk.ColumnMappings.Add("Тип поста", "PostType");
                                //sqlBulk.ColumnMappings.Add("URL", "PostUrl");
                                //sqlBulk.ColumnMappings.Add("Тональность", "PostSentiment");
                                //sqlBulk.ColumnMappings.Add("Автор", "PostAuthor");
                                //sqlBulk.ColumnMappings.Add("Профиль", "AuthorsProfile");
                                //sqlBulk.ColumnMappings.Add("Подписчики", "AuthorsSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("Демография", "PostDemography");
                                //sqlBulk.ColumnMappings.Add("Возраст", "AuthorsAge");
                                //sqlBulk.ColumnMappings.Add("Источник", "PostSource");
                                //sqlBulk.ColumnMappings.Add("Место публикации", "PostPublicationPlace");
                                //sqlBulk.ColumnMappings.Add("Профиль места публикации", "PostPublicationPlaceProfile");
                                //sqlBulk.ColumnMappings.Add("Подписчики места публикации", "PostPublicationPlaceSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("Тип источника", "PostSourceType");
                                //sqlBulk.ColumnMappings.Add("Страна", "PostCountry");
                                //sqlBulk.ColumnMappings.Add("Заметки", "PostNotes");
                                //sqlBulk.ColumnMappings.Add("Сумма всех реакций", "PostReactionsSum");
                                //sqlBulk.ColumnMappings.Add("Лайки", "PostLikesCount");
                                //sqlBulk.ColumnMappings.Add("Love", "PostLoveCount");
                                //sqlBulk.ColumnMappings.Add("Haha", "PostHahaCount");
                                //sqlBulk.ColumnMappings.Add("Wow", "PostWowCount");
                                //sqlBulk.ColumnMappings.Add("Sad", "PostSadCount");
                                //sqlBulk.ColumnMappings.Add("Angry", "PostAngryCount");
                                //sqlBulk.ColumnMappings.Add("Dislikes", "PostDislikesCount");
                                //sqlBulk.ColumnMappings.Add("Комментарии", "PostCommentsCount");
                                //sqlBulk.ColumnMappings.Add("Репосты", "PostRepostsCount");
                                //sqlBulk.ColumnMappings.Add("Просмотры", "PostViewsCount");
                                //sqlBulk.ColumnMappings.Add("Рейтинг", "PostRatingCount");
                                //sqlBulk.ColumnMappings.Add("URL изображения", "PostImageUrl");
                                //#endregion

                                #region Rus Full Text
                                //sqlBulk.ColumnMappings.Add("Дата", "PostDate");
                                //sqlBulk.ColumnMappings.Add("Время", "PostTime");
                                //sqlBulk.ColumnMappings.Add("Заголовок", "PostTitle");
                                //sqlBulk.ColumnMappings.Add("Текст", "PostText");
                                //sqlBulk.ColumnMappings.Add("Тип поста", "PostType");
                                //sqlBulk.ColumnMappings.Add("URL", "PostUrl");
                                //sqlBulk.ColumnMappings.Add("Тональность", "PostSentiment");
                                //sqlBulk.ColumnMappings.Add("Автор", "PostAuthor");
                                //sqlBulk.ColumnMappings.Add("Профиль", "AuthorsProfile");
                                //sqlBulk.ColumnMappings.Add("Подписчики", "AuthorsSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("Демография", "PostDemography");
                                //sqlBulk.ColumnMappings.Add("Возраст", "AuthorsAge");
                                //sqlBulk.ColumnMappings.Add("Источник", "PostSource");
                                //sqlBulk.ColumnMappings.Add("Место публикации", "PostPublicationPlace");
                                //sqlBulk.ColumnMappings.Add("Профиль места публикации", "PostPublicationPlaceProfile");
                                //sqlBulk.ColumnMappings.Add("Подписчики места публикации", "PostPublicationPlaceSubscribersCount");
                                //sqlBulk.ColumnMappings.Add("Тип источника", "PostSourceType");
                                //sqlBulk.ColumnMappings.Add("Страна", "PostCountry");
                                //sqlBulk.ColumnMappings.Add("Заметки", "PostNotes");
                                //sqlBulk.ColumnMappings.Add("Сумма всех реакций", "PostReactionsSum");
                                //sqlBulk.ColumnMappings.Add("Лайки", "PostLikesCount");
                                //sqlBulk.ColumnMappings.Add("Love", "PostLoveCount");
                                //sqlBulk.ColumnMappings.Add("Haha", "PostHahaCount");
                                //sqlBulk.ColumnMappings.Add("Wow", "PostWowCount");
                                //sqlBulk.ColumnMappings.Add("Sad", "PostSadCount");
                                //sqlBulk.ColumnMappings.Add("Angry", "PostAngryCount");
                                //sqlBulk.ColumnMappings.Add("Dislikes", "PostDislikesCount");
                                //sqlBulk.ColumnMappings.Add("Комментарии", "PostCommentsCount");
                                //sqlBulk.ColumnMappings.Add("Репосты", "PostRepostsCount");
                                //sqlBulk.ColumnMappings.Add("Просмотры", "PostViewsCount");
                                //sqlBulk.ColumnMappings.Add("Рейтинг", "PostRatingCount");
                                //sqlBulk.ColumnMappings.Add("URL изображения", "PostImageUrl"); 
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
