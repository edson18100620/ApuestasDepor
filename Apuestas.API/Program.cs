using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using ApuestasDepor.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<ApuestasV2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IApuestaRepository, ApuestaRepository>();
builder.Services.AddTransient<IAudioVisualRepository, AudioVisualRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IEquiposRepository, EquiposRepository>();
builder.Services.AddTransient<IModalidadPagoRepository, ModalidadPagoRepository>();
builder.Services.AddTransient<IPaisRepository, PaisRepository>();
builder.Services.AddTransient<IPartidoRepository, PartidoRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
