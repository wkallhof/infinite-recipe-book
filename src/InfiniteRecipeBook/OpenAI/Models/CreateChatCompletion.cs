namespace InfiniteRecipeBook.OpenAI.Models;

public static class CreateChatCompletion
{
    public record Request(string Model, List<ChatMessage> Messages);

    public class Response
    {
        public List<Choice> Choices { get; set; } = new List<Choice>();

        public class Choice
        {
            public ChatMessage? Message { get; set; }
        }
    }
}