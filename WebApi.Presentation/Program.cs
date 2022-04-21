using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Data.Models;
using WebApi.Domain.Configurations;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Implementations;
using WebApi.Domain.Repositories.Interfaces;
using WebApi.Domain.Services;
using WebApi.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

var webApiAdContext = builder.Configuration.GetConnectionString(nameof(WebApiAdContext));
var jwtConfiguration = builder.Configuration.GetSection(nameof(JwtConfiguration)).Get<JwtConfiguration>();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebApiAdContext>(options => options.UseSqlServer(webApiAdContext));

builder.Services.AddTransient<IAdRepository, AdRepository>();
builder.Services.AddTransient<IAdCategoryRepository, AdCategoryRepository>();
builder.Services.AddTransient<IAdOwnerRepository, AdOwnerRepository>();

builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<AdModel>, AdModelValidator>();
builder.Services.AddTransient<IValidator<AdCategoryModel>, AdCategoryModelValidator>();
builder.Services.AddTransient<IValidator<AdOwnerModel>, AdOwnerModelValidator>();

builder.Services.AddTransient<JwtService>();
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtConfiguration.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtConfiguration.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.AudienceSecret)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Web Api", Version = "v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();