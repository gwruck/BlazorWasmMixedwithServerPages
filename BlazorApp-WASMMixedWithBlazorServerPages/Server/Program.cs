using BlazorApp_WASMMixedWithBlazorServerPages.Data;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//***Extra for WASM Hosted
    builder.Services.AddSingleton<WeatherForecastService>(); //only need this to make template pages work
    builder.Services.AddServerSideBlazor();
   
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//***Use MapWhen to handle all endpoints that don't use our chosen prefix (/svr).  ie. this handles routing to WASM
    app.MapWhen(ctx => !ctx.Request.Path.StartsWithSegments("/svr"), wasm =>
    {
        wasm.UseBlazorFrameworkFiles();
        wasm.UseStaticFiles();
        wasm.UseRouting();
        wasm.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("{*path:nonfile}", "index.html");
        });
    });

//***Add For Blazor Server
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//***delete the standard routing for WASM
//app.UseBlazorFrameworkFiles();
//app.UseStaticFiles();

//app.UseRouting();

//app.MapRazorPages();
//app.MapControllers();
//app.MapFallbackToFile("index.html");

app.Run();
