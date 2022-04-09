using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApi.Data.Models;
using WebApi.Domain.Repositories.Implementations;
using WebApi.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var webApiAdContext = builder.Configuration.GetConnectionString(nameof(WebApiAdContext));
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebApiAdContext>(options => options.UseSqlServer(webApiAdContext));
builder.Services.AddTransient<IAdRepository, AdRepository>();
builder.Services.AddTransient<IAdCategoryRepository, AdCategoryRepository>();
builder.Services.AddTransient<IAdOwnerRepository, AdOwnerRepository>();

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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();