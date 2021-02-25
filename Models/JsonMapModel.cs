using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TedAz.ExcelToDb.Importer.Models
{

    public class JsonMapModel
    {
        [JsonPropertyName("countries")]
        public Country[] Countries { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("name")]
        public string CountryName { get; set; }
        [JsonPropertyName("alpha3")]
        public string Alpha3 { get; set; }
    }
}
