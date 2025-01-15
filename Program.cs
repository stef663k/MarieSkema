using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using MarieSkema.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 

builder.Services.AddDbContext<SkemaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection(); 
app.UseAuthorization(); 
app.MapControllers();

app.Run(); 