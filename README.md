# SpawnDev.BlazorJS.QRCodeJS
Create QR Codes in Blazor WebAssembly with QRCode.js

[![NuGet version](https://badge.fury.io/nu/SpawnDev.BlazorJS.QRCodeJS.svg?label=SpawnDev.BlazorJS.QRCodeJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS.QRCodeJS)

**SpawnDev.BlazorJS.QRCodeJS** brings the extremely useful [QRCode.js](https://github.com/davidshimjs/qrcodejs) library to Blazor WebAssembly.

[QRCode.js](https://github.com/davidshimjs/qrcodejs) is javascript library for making QRCode. QRCode.js supports Cross-browser with HTML5 Canvas and table tag in DOM. QRCode.js has no dependencies.

### Demo
[Live Demo](https://lostbeard.github.io/SpawnDev.BlazorJS.QRCodeJS/)

### Getting started

Example Program.cs 
```cs
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.QRCodeJS;
using SpawnDev.BlazorJS.QRCodeJS.Demo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Add BlazorJSRunAsync service
builder.Services.AddBlazorJSRuntime();
// Add QRCodeJSService service
builder.Services.AddSingleton<QRCodeJSService>();
// initialize BlazorJSRuntime to start app
await builder.Build().BlazorJSRunAsync();
```

```html
<QRCodeImage Text="Hello world!" />
```

