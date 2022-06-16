using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using VSpor.Auths.Security.Encyption;
using VSpor.Auths.Security.Jwt;
using VSpor.IoC;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.IgnoreNullValues = false;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
   
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer 12345abcdef\"",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer"
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                },
//                Scheme = "oauth2",
//                Name = "Bearer",
//                In = ParameterLocation.Header,
//            },
//            new List<string>()
//        }
//    });
//});

builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(
builder.Configuration.GetConnectionString("VSporConnection")));

builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidIssuer = "VSpor",
                            ValidAudience = "VSpor",
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey("2022VSporS23!#dwd#?w32hiM#jAV")
                        };
                    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());
});


var app = builder.Build();


ServiceTool.ServiceProvider = app.Services;
var configurationManager = app.Services.GetService<ConfigurationManager>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
//app.MapControllers();
app.UseCors(b => b
            .WithOrigins(
                "http://localhost:3000",
                "https://localhost:3000"
               )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
        );

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
});
var cultureInfo = new CultureInfo("tr-TR") { DateTimeFormat =  { ShortDatePattern = "yyyy-MM-dd", ShortTimePattern = "HH:mm" }};

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
