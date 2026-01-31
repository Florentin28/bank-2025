using Microsoft.AspNetCore.Components.Web;
using bank_2025;
var builder = WebApplication.CreateBuilder(args);

// 1. Services pour Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Enregistrement de ta banque (Singleton = une seule instance pour tous)
builder.Services.AddSingleton<BankService>();

var app = builder.Build();

// 3. Configuration du pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); 

app.Run();