namespace InfiniteRecipeBook.Persistence
{
    public class RecipeRecord
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? Base64Image { get; set; }
        public int Version { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Directions { get; set; } = new List<string>();
    }
}