using DataAccessNet;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.IgnoreNullValues = false;
    });
// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(
builder.Configuration.GetConnectionString("VSporConnection")));


builder.Services.AddScoped<VSporEntities, VSporEntities>();

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var connectionString = builder.Configuration.GetConnectionString("AppDb");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
