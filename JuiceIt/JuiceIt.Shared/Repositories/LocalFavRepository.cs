using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            //db.DropTable<Favorites>();
            db.CreateTable<Favorites>();
            var table = db.Table<Favorites>();
            foreach (var s in table)
            {
                Console.WriteLine(s.description + " " + s.description);
            }
        }

        public Favorites AddFavorites(Recipe recipe)
        {
            var db = new SQLiteConnection(dbPath);
            var newUserTask = new Favorites();
            newUserTask.name = recipe.name;
            newUserTask.description = recipe.description;
            newUserTask.picture = recipe.picture;
            newUserTask.thumbnail = recipe.thumbnail;
            string joinedIngredients = string.Join(",", recipe.ingredients.ToArray());
            string joinedConditions = string.Join(",", recipe.condition.ToArray());
            newUserTask.ingredients = joinedIngredients;
            newUserTask.condition = joinedConditions;
            var UserExist = db.Query<Favorites>("select * from Favorites where name = ?", recipe.name);
            int selectedDepartment = UserExist.Count;
            if(selectedDepartment > 0)
            {
                Debug.WriteLine("{0} Zit al in database", newUserTask.name);
            }
            else
            {
                db.Insert(newUserTask);
            }
            return newUserTask;
        }
        private List<Favorites> _favorites;
        public async Task<List<Favorites>> GetFavorite()
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var table = db.Table<Favorites>();
            if(_favorites == null) 
                _favorites = await table.ToListAsync();
            return _favorites;
        }

        public async Task<List<Favorites>> GetFavorites()
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var table = db.Table<Favorites>();
            var result = table.ToListAsync();
            return await result;
        }


        public async Task<Favorites> GetFavoritesById(int FavoriteId)
        {
            if (_favorites == null) await GetFavorite();
            return _favorites.Where(favorite => favorite.id == FavoriteId)?.First();
        }


        public async Task DeleteFavorite(int id)
        {
            var db = new SQLiteAsyncConnection(dbPath);
            var newUserTask = db.DeleteAsync(new Favorites()
            {
                id = id
            });
            Console.WriteLine("Resultaat van de verwijderde lijn: {0}", newUserTask.Id);
            await db.DeleteAsync(newUserTask.Id);

        }

    }
}
