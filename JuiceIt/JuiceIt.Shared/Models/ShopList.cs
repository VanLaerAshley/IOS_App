using System;
using SQLite;

namespace JuiceIt.Shared.Models
{
    [Table("ShopList")]
    public class ShopList
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Ingredients { get; set; }
    }
}
