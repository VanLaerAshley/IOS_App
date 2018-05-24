using System;
using System.Collections.Generic;

namespace JuiceIt.Shared.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public List<string> ingredients { get; set; }
        public List<string> condition { get; set; }
    }


}
