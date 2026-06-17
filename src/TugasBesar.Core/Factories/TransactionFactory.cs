using TugasBesar.Core.DTO.Request;
using TugasBesar.Core.Models;

public static class TransactionFactory
{
    public static (TransaksiModels Transaksi, List<TransaksiDetailsModels> Details) Create(TransaksiRequestDTO item)
    {
        int totalHarga = item.Keranjang.Sum(k => k.Subtotal);
        int? uangKembalian = item.UangDiterima.HasValue
            ? (item.UangDiterima.Value - totalHarga)
            : null;

        var transaksi = new TransaksiModels
        {
            IdUser = item.IdUser,
            NamaPembeli = item.NamaPembeli,
            IdMetodePembayaran = item.IdMetodePembayaran,
            IdStatus = item.IdStatus,
            TotalHarga = totalHarga,
            UangDiterima = item.UangDiterima,
            UangKembalian = uangKembalian,
            Tanggal = DateTime.Now,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        var details = item.Keranjang.Select(d => new TransaksiDetailsModels
        {
            IdProduk = d.IdProduk,
            Qty = d.Qty,
            HargaSatuan = d.HargaSatuan,
            Subtotal = d.Subtotal,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }).ToList();

        return (transaksi, details);
    }
}
