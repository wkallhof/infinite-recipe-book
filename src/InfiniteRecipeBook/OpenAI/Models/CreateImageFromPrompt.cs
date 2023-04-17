using System.Text.Json.Serialization;

namespace InfiniteRecipeBook.OpenAI.Models
{
    public class CreateImageFromPrompt
    {
        public class Response
        {
            public List<ResponseData> Data { get; set; } = new List<ResponseData>();
            public class ResponseData
            {
                [JsonPropertyName("b64_json")]
                public string B64Json { get; set; }
            }
        }
    }
}