using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SQLDataAccess;
using TicketSystem.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<UserManager>();
builder.Services.AddSingleton<TicketManager>();
builder.Services.AddTransient<SqlDataAccess>();
builder.Services.AddTransient<TicketData>();
builder.Services.AddTransient<UserData>();

var app = builder.Build();

await app.Services.GetService<UserManager>().Initialize();
await app.Services.GetService<TicketManager>().Initialize();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
