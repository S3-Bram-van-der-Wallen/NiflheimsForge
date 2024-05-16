using NiflheimsForge.Data;
using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Data.Interfaces;
using NiflheimsForge.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", 
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});

builder.Services.AddDbContext<NiflheimsForgeDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NiflheimsForgeDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionLT")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
