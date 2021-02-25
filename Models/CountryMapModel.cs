using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TedAz.ExcelToDb.Importer.Models
{
    public class CountryMapModel
    {
        [JsonPropertyName("countries")]
        public List<CountryStatistics> Countries { get; set; }
    }

    public class CountryStatistics
    {
        [JsonPropertyName("name")]
        public string CountryName { get; set; }
        [JsonPropertyName("count")]
        public int MensionsCount { get; set; }
        public CountryStatistics() { }
        public CountryStatistics(string countryName, int mensionsCount) => (CountryName,MensionsCount) = (countryName,mensionsCount);
    }
}
