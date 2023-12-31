using Microsoft.EntityFrameworkCore;
using SurveyNew.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(c =>
    {
        c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SurveyProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("constring"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
