using GameStore.Web.Clients;
using GameStore.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
                      throw new NullReferenceException("GameStoreApiUrl is not set");

builder.Services
    .AddHttpClient<GamesClient>(
        client => client.BaseAddress = new Uri(gameStoreApiUrl));

builder.Services
    .AddHttpClient<GenresClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl));

// Removed to be replaced fo real Api
// builder.Services.AddSingleton<GamesClient>()
// builder.Services.AddSingleton<GenresClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
