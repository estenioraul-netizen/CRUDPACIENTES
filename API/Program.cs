using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Application.Interfaces.Repositories;
using SistemaPacientes.Application.Interfaces.Services;
using SistemaPacientes.Application.Services;
using SistemaPacientes.Infrastructure.Context;
using SistemaPacientes.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrar controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Registrar interfaces y servicios
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IPacienteService, PacienteService>();

// Configurar CORS para permitir la conexión con Blazor
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirCliente", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();

app.UseCors("PermitirCliente");

app.UseAuthorization();

// Mapear controladores
app.MapControllers();

app.Run();