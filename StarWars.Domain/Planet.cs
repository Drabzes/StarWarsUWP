using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain
{
    public class Planet
    {
        public string Name { get; set; }
        [JsonProperty("rotation_period")]
        public int RotationPeriod { get; set; }
        [JsonProperty("orbital_period")]
        public int OrbitalPeriod { get; set; }
        public int Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie> Films { get; set; }
        [JsonProperty(PropertyName = "films")]
        public List<string> FilmUris { get; set; }

    }
}
