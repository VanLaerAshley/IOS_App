using System;
using SQLite;

namespace JuiceIt.Shared.Models
{
    [Table("Tasks")]
    public class Favorites
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string FavName { get; set; }
        public string FavDescription { get; set; }
    }
}
