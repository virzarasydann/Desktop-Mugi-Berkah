using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MysqlDatabaseConnectionLibrary; 
using MysqlDatabaseConnectionLibrary.Repositories; 
using TugasBesar.Core.Factories;
using TugasBesar.Core.Factories.Payments;
using TugasBesar.Core.Repositories.Interfaces;
using TugasBesar.Core.Services;
using TugasBesar.Core.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Paksa API listen di semua interface port 5141
builder.WebHost.UseUrls("http://0.0.0.0:5141");


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
builder.Services.AddScoped<IMetodePembayaranRepository, MetodePembayaranRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<PaymentFactory>();
builder.Services.AddSingleton<IAkunPegawaiFactory, AkunPegawaiFactory>();

builder.Services.AddScoped<IAkunPegawaiServices, AkunPegawaiService>();
builder.Services.AddScoped<IKategoriServices, KategoriService>();
builder.Services.AddScoped<IOperasionalService, OperasionalService>();
builder.Services.AddScoped<IProdukServices, ProdukService>();
builder.Services.AddScoped<ITransaksiServices, TransaksiServices>();
builder.Services.AddScoped<IMetodePembayaranServices, MetodePembayaranService>();
builder.Services.AddScoped<IStatusServices, StatusService>();
builder.Services.AddHttpClient<IMidtransService, MidtransService>();
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



app.MapControllers();

app.Run();