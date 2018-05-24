using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;
using SQLite;

namespace JuiceIt.Shared.Repositories
{
    public class LocalShopListRepository : ILocalShopListRepository
    {
        private string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ShopzzList.db3");
        public void SetupDatabase()
        {
            var db = new SQLiteConnection(dbPath);
            //db.DropTable<ShopList>();
            db.CreateTable<ShopList>();
            var table = db.Table<ShopList>();
            foreach (var s in table)
            {
                Console.WriteLine(s.Id + " " + s.Ingredients);
            }
        }

        public ShopList AddShopList(Recipe recipe)
        {
            var db = new SQLiteConnection(dbPath);
            var newUserTask = new ShopList();
            List<string> ingredientList = recipe.ingredients.ToList<string>();
            foreach (string value in ingredientList)
            {
                var firstSpaceIndex = value.IndexOf(" ");
                var firstString = value.Substring(0, firstSpaceIndex); 
                var secondString = value.Substring(firstSpaceIndex + 1);

                var IngredientExist = db.Query<ShopList>($"select * from ShopList where Ingredients LIKE '%{secondString}%'");
                int selectedIngredient = IngredientExist.Count;
                if (selectedIngredient > 0)
                {
                    var DatabaseIngredient = db.Query<ShopList>($"select * from ShopList where Ingredients LIKE '%{secondString}%'");
                    var GetInteger = DatabaseIngredient[0].Ingredients.Split(' ');

                    var clone = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    clone.NumberFormat.NumberDecimalSeparator = ",";
                    clone.NumberFormat.NumberGroupSeparator = " ";

                    decimal numVal = decimal.Parse(GetInteger[0], clone);
                    decimal numVal2 = decimal.Parse(firstString, clone);
                    decimal math = numVal + numVal2;
                    string result = $"{math} {secondString}";


                    var Update = db.Query<ShopList>($"update ShopList set Ingredients = '{result}' where Ingredients LIKE '%{secondString}%'");

                }
                else
                {
                    newUserTask.Ingredients = value;
                    db.Insert(newUserTask);
                }
                Console.WriteLine("Ingredients: {0}", value);
            }
            return newUserTask;
        }

        public ShopList AddShopListFromLocal(Favorites favorite)
        {
            var db = new SQLiteConnection(dbPath);
            var newUserTask = new ShopList();
            List<string> ingredientList = favorite.ingredients.Split(':').ToList<string>();
            foreach (string value in ingredientList)
            {
                //Split string bij de eerste space
                var firstSpaceIndex = value.IndexOf(" ");
                var firstString = value.Substring(0, firstSpaceIndex);//Voor de spatie
                var secondString = value.Substring(firstSpaceIndex + 1); // Na de spatie


                var IngredientExist = db.Query<ShopList>($"select * from ShopList where Ingredients LIKE '%{secondString}%'");
                int selectedIngredient = IngredientExist.Count;
                if (selectedIngredient > 0)
                {
                    var DatabaseIngredient = db.Query<ShopList>($"select * from ShopList where Ingredients LIKE '%{secondString}%'");
                    var GetInteger = DatabaseIngredient[0].Ingredients.Split(' ');

                    var clone = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    clone.NumberFormat.NumberDecimalSeparator = ",";
                    clone.NumberFormat.NumberGroupSeparator = " ";

                    decimal numVal = decimal.Parse(GetInteger[0], clone);
                    decimal numVal2 = decimal.Parse(firstString, clone);
                    decimal math = numVal + numVal2;
                    string result = $"{math} {secondString}";


                    var Update = db.Query<ShopList>($"update ShopList set Ingredients = '{result}' where Ingredients LIKE '%{secondString}%'");
                    //Debug.WriteLine("{0} Zit al in database. Checker is: {1}", namesArray, newUserTask.checker);

                 
                }
                else
                {
                    newUserTask.Ingredients = value;
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


        public ShopList AddShopListChecker()
        {
            var db = new SQLiteConnection(dbPath);
            var newUserTask = new ShopList();
            if (newUserTask.checker == 0)
            {
                newUserTask.checker = 1;
                db.Insert(newUserTask);
                Debug.WriteLine("1 is toegevoeg: ", newUserTask);
                return newUserTask;

            }
            else
            {

                newUserTask.checker = 0;
                db.Update(newUserTask);
                Debug.WriteLine("1 is verwijderd: ", newUserTask);
                return newUserTask;
            }
        }
    }
}
