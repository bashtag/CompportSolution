using System.Net;
using CompportDataAccess;
using CompportService;

var builder = WebApplication.CreateBuilder(args);

// Data access and services configuration
builder.Services.AddDataAccessServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDependencies();

// Add services to the container.
builder.Services.AddControllers();
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
