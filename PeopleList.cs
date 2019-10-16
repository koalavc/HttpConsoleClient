using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpConsoleClient
{
    public class Result
    {
        public string name { get; set; }
        public string height { get; set; }
        //public string mass { get; set; }
        public double mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        //public List<string> films { get; set; }
        public List<string> films { get; set; }
        public List<string> species { get; set; }

        [JsonProperty("vehicles")]
        public List<string> vehiclesJson { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        [JsonIgnore]
        public int NumberOfVehicles
        {
            get {
                return vehiclesJson.Count;
            }
        }
    }

    public class PeopleList
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Result> People { get; set; }
    }
}
