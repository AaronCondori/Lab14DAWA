using TAREA13_AaronCondori.Services;
using Microsoft.EntityFrameworkCore;
using TAREA13_AaronCondori.Models;
var builder = WebApplication.CreateBuilder(args);

// Agregar controlador estilo API
builder.Services.AddControllers();

// Registrar el DbContext usando el connection string de appsettings.json
builder.Services.AddDbContext<LinqexampleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaConnection")));

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExcelReportService>();

var app = builder.Build();

// Configurar pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();

