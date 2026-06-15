using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MysqlDatabaseConnectionLibrary; 
using TugasBesar.Core.Services;
using TugasBesar.Core.Services.Interfaces;
using TugasBesar.Core.Repositories.Interfaces;
using MysqlDatabaseConnectionLibrary.Repositories; 
using TugasBesar.Core.Factories;
var builder = WebApplication.CreateBuilder(args);


var connectionString = "Server=localhost;Database=mugi_berkah;User=root;Password=;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddControllers();


builder.Services.AddScoped<IAkunPegawaiRepository, AkunPegawaiRepository>(); 
builder.Services.AddScoped<IKategoriRepository, KategoriRepository>();
builder.Services.AddScoped<IOperasionalRepository, OperasionalRepository>();
builder.Services.AddScoped<IProdukRepository, ProdukRepository>();
builder.Services.AddScoped<ITransaksiRepository, TransaksiRepository>();
builder.Services.AddScoped<ITransaksiDetailsRepository, TransaksiDetailsRepository>();

builder.Services.AddSingleton<IAkunPegawaiFactory, AkunPegawaiFactory>();

builder.Services.AddScoped<IAkunPegawaiServices, AkunPegawaiService>();
builder.Services.AddScoped<IKategoriServices, KategoriService>();
builder.Services.AddScoped<IOperasionalServices, OperasionalService>();
builder.Services.AddScoped<IProdukServices, ProdukService>();
builder.Services.AddScoped<ITransaksiServices, TransaksiServices>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 4. Map ke Controllers Route
app.MapControllers();

app.Run();