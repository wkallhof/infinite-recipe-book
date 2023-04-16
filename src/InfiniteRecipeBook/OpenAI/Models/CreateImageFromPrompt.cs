namespace InfiniteRecipeBook.OpenAI.Models
{
    public class CreateImageFromPrompt
    {
        public class Response
        {
            public List<ResponseData> Data { get; set; } = new List<ResponseData>();
            public class ResponseData
            {
                public string Url { get; set; }
            }
        }
    }
}