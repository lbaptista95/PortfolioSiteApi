using PortfolioSiteApi.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; 
using PortfolioSiteApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

builder.Services.AddCors(options =>
{
    // options.AddPolicy("AllowSpecificOrigins",
    // builder =>
    // {
    //     builder.WithOrigins("https://lbaptista95.github.io/PortfolioSite/")
    //            .AllowAnyHeader()
    //            .AllowAnyMethod();
    // });

    options.AddPolicy("AllowLocalhost",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });

    // options.AddPolicy("AllowAny",
    // builder => 
    // {
    //     builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    // });

});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EmailService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

//app.UseAuthorization();
app.MapControllers();

app.Run();
