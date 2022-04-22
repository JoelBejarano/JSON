using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONpokemon
{
    class Pokemon
    {
        public string name { get; set; }
        public string type { get; set; }
        public string move { get; set; }
        public string description { get; set; }
        public string picture { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string HP { get; set; }
    }
}
