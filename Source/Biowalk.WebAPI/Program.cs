using Biowalk.Data;
using Biowalk.Data.Repositorios;
using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.Interfaces.Repositorios;
using Biowalk.Dominio.UseCases.Clientes.AlteraCliente;
using Biowalk.Dominio.UseCases.Clientes.CriaCliente;
using Biowalk.Dominio.UseCases.Clientes.DeletaCliente;
using Biowalk.Dominio.UseCases.Clientes.ObterTodos;
using Biowalk.Dominio.UseCases.Equipamentos.AlteraEquipamento;
using Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento;
using Biowalk.Dominio.UseCases.Equipamentos.DeletaEquipamento;
using Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMediator, Mediator>();

builder.Services.AddScoped<DbSession>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
builder.Services.AddScoped<IEquipamentoSetorRepository, EquipamentoSetorRepository>();

builder.Services.AddScoped<IRequestHandler<CriaClienteCommand, Response<CriaClienteResult>>, CriaClienteHandler>();
builder.Services.AddScoped<IRequestHandler<AlteraClienteCommand, Response<AlteraClienteResult>>, AlteraClienteHandler>();
builder.Services.AddScoped<IRequestHandler<DeletaClienteCommand, Response<DeletaClienteResult>>, DeletaClienteHandler>();
builder.Services.AddScoped<IRequestHandler<ObterTodosClientesCommand, Response<List<ObterTodosClientesResult>>>, ObterTodosClientesHandler>();

builder.Services.AddScoped<IRequestHandler<CriaEquipamentoCommand, Response<CriaEquipamentoResult>>, CriaEquipamentoHandler>();
builder.Services.AddScoped<IRequestHandler<AlteraEquipamentoCommand, Response<AlteraEquipamentoResult>>, AlteraEquipamentoHandler>();
builder.Services.AddScoped<IRequestHandler<DeletaEquipamentoCommand, Response<DeletaEquipamentoResult>>, DeletaEquipamentoHandler>();

builder.Services.AddScoped<IRequestHandler<CriaEquipamentoSetorCommand, Response<CriaEquipamentoSetorResult>>, CriaEquipamentoSetorHandler>();


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
