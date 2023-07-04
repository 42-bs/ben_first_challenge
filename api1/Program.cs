using Microsoft.EntityFrameworkCore;
using api1.Models;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Add services to the container.
builder.Services.AddControllers();
// builder.Services.AddDbContext<InfoContext>(opt=>opt.UseSqlite("Data Source=/app/db/litedb.sqlite"));
builder.Services.AddDbContext<InfoContext>(opt=>opt.UseSqlServer(@"Server="+Env.GetString("DB_SERVER")+";Database=Ben; User Id="+Env.GetString("DB_USER")+"; Password="+Env.GetString("DB_PASS")+";TrustServerCertificate=true"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
