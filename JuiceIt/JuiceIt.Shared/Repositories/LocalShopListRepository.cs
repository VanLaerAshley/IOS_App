using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;
using SQLite;

namespace JuiceIt.Shared.Repositories
{
    public class LocalShopListRepository : ILocalShopListRepository
    {
        private string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ShopList.db3");
        public void SetupDatabase()
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<ShopList>();
            var table = db.Table<ShopList>();
            foreach (var s in table)
            {
                Console.WriteLine(s.Id + " " + s.Ingredients);
            }
        }
        private string _ingredients;
        public ShopList AddShopList(Recipe recipe)
        {
            var db = new SQLiteConnection(dbPath);
            var newUserTask = new ShopList();
            foreach(string value in recipe.ingredients)
            {
                newUserTask.Ingredients = value;
                var UserExist = db.Query<ShopList>("select * from ShopList where Ingredients = ?", value);
                int selectedDepartment = UserExist.Count;
                if (selectedDepartment > 0)
                {
                    Debug.WriteLine(" Zit al in database", newUserTask.Ingredients);
                }
                else
                {
                    db.Insert(newUserTask);
                }
                Console.WriteLine("Ingredients: {0}", value);
            }
            return newUserTask;
        }

        public async Task<List<ShopList>> GetShopList()
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var table = db.Table<ShopList>();
            var result = table.ToListAsync();
            return await result;
        }

        public async Task DeleteShopListItem(int id)
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var newUserTask = db.DeleteAsync(new ShopList()
            {
                Id = id
            });
            Console.WriteLine("Resultaat van de verwijderde lijn: {0}", newUserTask.Id);
            await db.DeleteAsync(newUserTask.Id);

        }
    }
}
