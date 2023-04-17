using LiteDB;

namespace InfiniteRecipeBook.Persistence
{
    public class RecipeRepository
    {
        private const string DB_PATH = "./data/app.db";
        private const string RECIPE_COLLECTION = "recipes";

        public List<RecipeRecord> GetAll()
        {
            using var db = new LiteDatabase(DB_PATH);
            var collection = db.GetCollection<RecipeRecord>(RECIPE_COLLECTION);
            return collection.FindAll().ToList();
        }

        public RecipeRecord? Get(Guid id)
        {
            using var db = new LiteDatabase(DB_PATH);
            var collection = db.GetCollection<RecipeRecord>(RECIPE_COLLECTION);
            return collection.FindById(id);
        }

        public Guid Insert(RecipeRecord recipe)
        {
            using var db = new LiteDatabase(DB_PATH);
            var collection = db.GetCollection<RecipeRecord>(RECIPE_COLLECTION);
            collection.Insert(recipe);
            return recipe.Id;
        }

        public void Update(RecipeRecord recipe)
        {
            using var db = new LiteDatabase(DB_PATH);
            var collection = db.GetCollection<RecipeRecord>(RECIPE_COLLECTION);
            collection.Update(recipe);
        }
    }
}