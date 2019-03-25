using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkw2
{
    public class Person
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
       // [JsonProperty(PropertyName = "Hair_color")]
        public string HairColor { get; set; }
       // [JsonProperty(PropertyName = "Skin_color")]
        public string SkinColor { get; set; }
       // [JsonProperty(PropertyName = "Eye_color")]
        public string EyeColor { get; set; }
       // [JsonProperty(PropertyName = "Birth_year")]
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public List<object> Films { get; set; }
        public List<object> Species { get; set; }
        public List<object> Vehicles { get; set; }
        public List<object> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
    }
}
