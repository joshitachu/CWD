using BlazorApp1.Components;

var builder = WebApplication.CreateBuilder(args);

// builder.WebHost.UseUrls($"http://*:5003");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();
builder.Services.AddHttpClient(); // Registers HttpClient


builder.Services.AddScoped<AssetService>();
builder.Services.AddSingleton<AssetDataService>();
builder.Services.AddSingleton<SimulationDataService>();


builder.Host.UseWindowsService();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



app.Run();
