using AppExtratoBancario.API.Data;
using AppExtratoBancario.API.Data.Repositories;
using AppExtratoBancario.API.Services;
using AppExtratoBancario.API.Services.ServiceGeraPdf;
using AppExtratoBancario.API.Services.ServicoDeValidacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// add serviços ao conteiner
builder.Services.AddSingleton<InMemoryDatabase>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<IExtratoPdfService, ExtratoPdfService>();
builder.Services.AddScoped<IParametroValidador, ParametroValidador>();
builder.Services.AddScoped<IBancoUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ExtratoBancario}/{action=GetTransacoes}/{id?}");

app.Run();
