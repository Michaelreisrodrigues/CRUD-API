using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exemplo_Api_Locadora.Data;
using Exemplo_Api_Locadora.Services;
using Exemplo_Api_Locadora.Interface;
 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AplicacaoDbContexto>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFilmeService, FilmeService>(); 

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IAluguelService, AluguelService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();