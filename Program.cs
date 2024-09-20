using PortfolioSiteApi.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; 
using PortfolioSiteApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

var smtpPwd = Environment.GetEnvironmentVariable("SMTP_PWD");

if (!string.IsNullOrEmpty(smtpPwd))
{
    builder.Configuration["SmtpSettings:Password"] = smtpPwd;
}

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

Console.WriteLine(connectionString);

if (!string.IsNullOrEmpty(connectionString))
{
    builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;
}

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMultipleOrigins",
    builder =>
    {
        builder.WithOrigins("https://lbaptista95.github.io","http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });

});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EmailService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowMultipleOrigins");

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
