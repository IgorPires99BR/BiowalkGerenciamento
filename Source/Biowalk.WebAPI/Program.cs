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
using Biowalk.Dominio.UseCases.CriaEquipamentoMontagem;
using Biowalk.Dominio.UseCases.Equipamentos.AlteraEquipamento;
using Biowalk.Dominio.UseCases.Equipamentos.CriaEquipamento;
using Biowalk.Dominio.UseCases.Equipamentos.DeletaEquipamento;
using Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor;
using Biowalk.Dominio.UseCases.ObterEquipamentoMontagem;
using Biowalk.Dominio.UseCases.ProcessaEtapa;
using Biowalk.Dominio.UseCases.Usuario.ObterUsuario;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
                      policy =>
                      {
                          // Substitua "http://localhost:4200" pelo endereço do seu front-end
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMediator, Mediator>();

builder.Services.AddScoped<DbSession>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
builder.Services.AddScoped<IEquipamentoSetorRepository, EquipamentoSetorRepository>();
builder.Services.AddScoped<IEquipamentoMontagemRepository, EquipamentoMontagemRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IRequestHandler<CriaClienteCommand, Response<CriaClienteResult>>, CriaClienteHandler>();
builder.Services.AddScoped<IRequestHandler<AlteraClienteCommand, Response<AlteraClienteResult>>, AlteraClienteHandler>();
builder.Services.AddScoped<IRequestHandler<DeletaClienteCommand, Response<DeletaClienteResult>>, DeletaClienteHandler>();
builder.Services.AddScoped<IRequestHandler<ObterTodosClientesCommand, Response<List<ObterTodosClientesResult>>>, ObterTodosClientesHandler>();

builder.Services.AddScoped<IRequestHandler<CriaEquipamentoCommand, Response<CriaEquipamentoResult>>, CriaEquipamentoHandler>();
builder.Services.AddScoped<IRequestHandler<AlteraEquipamentoCommand, Response<AlteraEquipamentoResult>>, AlteraEquipamentoHandler>();
builder.Services.AddScoped<IRequestHandler<DeletaEquipamentoCommand, Response<DeletaEquipamentoResult>>, DeletaEquipamentoHandler>();

builder.Services.AddScoped<IRequestHandler<CriaEquipamentoSetorCommand, Response<CriaEquipamentoSetorResult>>, CriaEquipamentoSetorHandler>();


builder.Services.AddScoped<IRequestHandler<ObterEquipamentoMontagemQuery, Response<List<ObterEquipamentoMontagemResult>>>, ObterEquipamentoMontagemHandler>();
builder.Services.AddScoped<IRequestHandler<ProcessaEtapaCommand, Response<ProcessaEtapaResult>>, ProcessaEtapaHandler>();
builder.Services.AddScoped<IRequestHandler<CriaEquipamentoMontagemCommand, Response<CriaEquipamentoMontagemResult>>, CriaEquipamentoMontagemHandler>();


builder.Services.AddScoped<IRequestHandler<ObterUsuarioCommand, Response<ObterUsuarioResult>>, ObterUsuarioHandler>();


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

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
