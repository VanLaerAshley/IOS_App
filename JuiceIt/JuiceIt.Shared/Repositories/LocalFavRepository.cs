using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;
using SQLite;


namespace JuiceIt.Shared.Repositories
{
    public class LocalFavRepository : ILocalFavRepository
    {
        private string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Favorites.db3");
        public void SetupDatabase()
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Favorites>();
            var table = db.Table<Favorites>();
            foreach (var s in table)
            {
                Console.WriteLine(s.FavName + " " + s.FavDescription);
            }
        }

        public Favorites AddFavorites(Recipe recipe)
        {
            var db = new SQLiteConnection(dbPath);
            var newUserTask = new Favorites();
            newUserTask.FavName = recipe.name;
            newUserTask.FavDescription = recipe.description;
            db.Insert(newUserTask);
            return newUserTask;
        }

        public async Task<List<Favorites>> GetFavorite()
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var table = db.Table<Favorites>();
            var result = table.ToListAsync();
            return await result;
        }

        public async Task DeleteFavorite(int id)
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var newUserTask = db.DeleteAsync(new Favorites()
            {
                Id = id
            });
            Console.WriteLine("Resultaat van de verwijderde lijn: {0}", newUserTask.Id);
            await db.DeleteAsync(newUserTask.Id);

        }


    }
}
