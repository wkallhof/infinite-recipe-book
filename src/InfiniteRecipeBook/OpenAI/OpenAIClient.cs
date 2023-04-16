using System.Text.Json;
using InfiniteRecipeBook.Common;
using InfiniteRecipeBook.OpenAI.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace InfiniteRecipeBook.OpenAI;

public class OpenAIClient
{
    private readonly HttpClient _client;

    private readonly JsonSerializerOptions _deserializerOptions = new()
    {
        PropertyNamingPolicy = new SnakeCaseNamingPolicy()
    };

    public OpenAIClient(HttpClient client, IOptionsSnapshot<OpenAISettings> settings)
    {
        _client = client;
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.Value.ApiKey}");
    }

    public async Task<TResult?> GenerateData<TResult>(string prefixPrompt)
    {
        var schema = GetJsonSchema<TResult>();
        var prompt = prefixPrompt + "\n Use the following JSON Schema to capture the output of your message. Please respond only with data, no supplemental text. \n Schema : \n " + schema.ToString();
        var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", 
            new CreateChatCompletion.Request(Model:"gpt-3.5-turbo", Messages: new List<ChatMessage>{
                new ChatMessage()
                {
                    Role = "user",
                    Content = prompt
                }
            }));

        response.EnsureSuccessStatusCode();
        //var responseText = await response.Content.ReadAsStringAsync();
        var result = await response.Content.ReadFromJsonAsync<CreateChatCompletion.Response>(_deserializerOptions);
        var json = result?.Choices?.FirstOrDefault()?.Message?.Content;
        if(string.IsNullOrEmpty(json))
            return default;
        
        var token = JToken.Parse(json);
        if(!token.IsValid(schema))
            return default;

        return token.ToObject<TResult>();
    }

    public async Task<string?> GetImageFromPrompt(string prompt)
    {
        var response = await _client.PostAsJsonAsync("https://api.openai.com/v1/images/generations", new {
            Prompt = prompt,
            Size = "512x512"
        });

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<CreateImageFromPrompt.Response>(_deserializerOptions);
        return result?.Data?.FirstOrDefault()?.Url;
    }

    private JSchema GetJsonSchema<T>()
        => new JSchemaGenerator().Generate(typeof(T));
}