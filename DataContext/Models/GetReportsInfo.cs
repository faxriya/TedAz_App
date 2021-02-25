using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TedAzApp.DataContext.Models
{
    public class GetReportsInfo
    {
        public string UserFullName { get; set; }
        public string ReportType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Period { get; set; }
        public string ReportUrl { get; set; }
        public string ReportName { get; set; }
    }
}