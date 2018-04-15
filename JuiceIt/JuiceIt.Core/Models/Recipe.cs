using System;
using System.Collections.Generic;

namespace JuiceIt.Core.Models
{
    public class Recipe
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<string> ingredients { get; set; }
        public List<string> condition { get; set; }
    }
}
