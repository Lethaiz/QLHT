using Microsoft.EntityFrameworkCore;

using WebHocTap;
using WebHocTap.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Context") ?? throw new InvalidOperationException("Connection string 'Connection' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ServicesCollection(builder.Configuration);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
