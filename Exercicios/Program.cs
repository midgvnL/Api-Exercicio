using Exercicios.Data;
using Exercicios.Repositorios;
using Exercicios.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuario, RUsuario>();
builder.Services.AddScoped<IPedido, RPedidos>();
builder.Services.AddScoped<IProduto, RProdutos>();
builder.Services.AddScoped<IProdutosPedidos, RProdutosPedidos>();
builder.Services.AddScoped<ICategoria, RCategoria>();

/*Adicionando a nossa string de conex�o*/
builder.Services.AddDbContext<SistemaPedidoDbcontext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
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
