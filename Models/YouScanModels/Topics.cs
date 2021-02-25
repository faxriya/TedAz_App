using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class Topics
    {
        public Topic[] topics { get; set; }
    }
    public class Topic
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
