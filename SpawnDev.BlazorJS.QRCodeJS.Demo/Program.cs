using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.QRCodeJS;
using SpawnDev.BlazorJS.QRCodeJS.Demo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Add BlazorJSRunAsync service
builder.Services.AddBlazorJSRuntime(out var JS);
// Add QRCodeJSService service
builder.Services.AddSingleton<QRCodeJSService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

// initialize BlazorJSRuntime to start app
await builder.Build().BlazorJSRunAsync();
