using TugasBesar.Core.Models;
using TugasBesar.Core.Services;
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
    var controller = new TugasBesar.Core.Controllers.KategoriController();
    return Results.Ok(controller.GetAll());
});

app.MapPost("/api/kategori", ([FromBody] KategoriModels request) =>
{
    var controller = new TugasBesar.Core.Controllers.KategoriController();
    try
    {
        controller.Tambah(request.Nama);
        var all = controller.GetAll();
        return Results.Created($"/api/kategori/{all.Count - 1}", all.Last());
    }
    catch (Exception ex)
    {
        if (ex.Message.Contains("sudah ada"))
            return Results.Conflict(new { message = ex.Message });
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.MapPut("/api/kategori/{index}", (int index, [FromBody] KategoriModels request) =>
{
    var controller = new TugasBesar.Core.Controllers.KategoriController();
    try
    {
        controller.Edit(index, request.Nama);
        return Results.Ok(controller.GetAll()[index]);
    }
    catch (Exception ex)
    {
        if (ex.Message.Contains("ditemukan") || ex.Message.Contains("tidak valid"))
            return Results.NotFound(new { message = ex.Message });
        if (ex.Message.Contains("sudah ada"))
            return Results.Conflict(new { message = ex.Message });
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.MapDelete("/api/kategori/{index}", (int index) =>
{
    var controller = new TugasBesar.Core.Controllers.KategoriController();
    try
    {
        controller.Hapus(index);
        return Results.Ok(new { message = "Berhasil dihapus." });
    }
    catch (Exception ex)
    {
        return Results.NotFound(new { message = ex.Message });
    }
});

// PRODUK API

app.MapGet("/api/produk", () =>
{
    var controller = new TugasBesar.Core.Controllers.ProdukController();
    return Results.Ok(controller.GetAll());
});

app.MapPost("/api/produk", ([FromBody] ProdukModels request) =>
{
    var controller = new TugasBesar.Core.Controllers.ProdukController();
    try
    {
        controller.Tambah(request.Nama, request.Kategori, request.Harga.ToString());
        var all = controller.GetAll();
        return Results.Created($"/api/produk/{all.Count - 1}", all.Last());
    }
    catch (Exception ex)
    {
        if (ex.Message.Contains("sudah ada"))
            return Results.Conflict(new { message = ex.Message });
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.MapPut("/api/produk/{index}", (int index, [FromBody] ProdukModels request) =>
{
    var controller = new TugasBesar.Core.Controllers.ProdukController();
    try
    {
        controller.Edit(index, request.Nama, request.Kategori, request.Harga.ToString());
        return Results.Ok(controller.GetAll()[index]);
    }
    catch (Exception ex)
    {
        if (ex.Message.Contains("ditemukan") || ex.Message.Contains("tidak valid"))
            return Results.NotFound(new { message = ex.Message });
        if (ex.Message.Contains("sudah ada"))
            return Results.Conflict(new { message = ex.Message });
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.MapDelete("/api/produk/{index}", (int index) =>
{
    var controller = new TugasBesar.Core.Controllers.ProdukController();
    try
    {
        controller.Hapus(index);
        return Results.Ok(new { message = "Berhasil dihapus." });
    }
    catch (Exception ex)
    {
        return Results.NotFound(new { message = ex.Message });
    }
});

app.Run();
