using TugasBesar.Models;
using TugasBesar.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// KATEGORI API

app.MapGet("/api/kategori", () =>
{
    return Results.Ok(DataManager.Kategori.GetAll());
});

app.MapPost("/api/kategori", ([FromBody] KategoriModels request) =>
{
    var result = KategoriService.TryAdd(request.Nama, out var kategori);
    if (result == KategoriResult.Success)
        return Results.Created($"/api/kategori/{DataManager.Kategori.GetAll().Count - 1}", kategori);
    if (result == KategoriResult.Duplicate)
        return Results.Conflict(new { message = "Kategori sudah ada." });
    
    return Results.BadRequest(new { message = "Data tidak valid." });
});

app.MapPut("/api/kategori/{index}", (int index, [FromBody] KategoriModels request) =>
{
    var result = KategoriService.TryUpdate(index, request.Nama, out var updated);
    if (result == KategoriResult.Success)
        return Results.Ok(updated);
    if (result == KategoriResult.NotFound)
        return Results.NotFound();
    if (result == KategoriResult.Duplicate)
        return Results.Conflict(new { message = "Kategori dengan nama yang sama sudah ada." });
    
    return Results.BadRequest(new { message = "Data tidak valid." });
});

app.MapDelete("/api/kategori/{index}", (int index) =>
{
    if (index >= 0 && index < DataManager.Kategori.GetAll().Count)
    {
        DataManager.Kategori.RemoveAt(index);
        return Results.Ok(new { message = "Berhasil dihapus." });
    }
    return Results.NotFound();
});

// PRODUK API

app.MapGet("/api/produk", () =>
{
    return Results.Ok(DataManager.Produk.GetAll());
});

app.MapPost("/api/produk", ([FromBody] ProdukModels request) =>
{
    var result = ProdukService.TryAdd(request.Nama, request.Kategori, request.Harga, out var produk);
    if (result == ProdukResult.Success)
        return Results.Created($"/api/produk/{DataManager.Produk.GetAll().Count - 1}", produk);
    if (result == ProdukResult.Duplicate)
        return Results.Conflict(new { message = "Produk sudah ada." });
    
    return Results.BadRequest(new { message = "Data tidak valid." });
});

app.MapPut("/api/produk/{index}", (int index, [FromBody] ProdukModels request) =>
{
    var result = ProdukService.TryUpdate(index, request.Nama, request.Kategori, request.Harga, out var updated);
    if (result == ProdukResult.Success)
        return Results.Ok(updated);
    if (result == ProdukResult.NotFound)
        return Results.NotFound();
    if (result == ProdukResult.Duplicate)
        return Results.Conflict(new { message = "Produk dengan data yang sama sudah ada." });
    
    return Results.BadRequest(new { message = "Data tidak valid." });
});

app.MapDelete("/api/produk/{index}", (int index) =>
{
    if (index >= 0 && index < DataManager.Produk.GetAll().Count)
    {
        DataManager.Produk.RemoveAt(index);
        return Results.Ok(new { message = "Berhasil dihapus." });
    }
    return Results.NotFound();
});

app.Run();
