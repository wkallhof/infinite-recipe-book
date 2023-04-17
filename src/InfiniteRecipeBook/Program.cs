using InfiniteRecipeBook.OpenAI;
using InfiniteRecipeBook.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<OpenAIClient>();
builder.Services.AddTransient<RecipeRepository>();
builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAI"));

var app = builder.Build();

Directory.CreateDirectory("data");

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
