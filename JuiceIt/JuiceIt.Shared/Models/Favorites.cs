using System;
using System.Collections.Generic;
using SQLite;

namespace JuiceIt.Shared.Models
{
    [Table("Favorites")]
    public class Favorites
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ingredients { get; set; }
        public string condition { get; set; }
    }
}
