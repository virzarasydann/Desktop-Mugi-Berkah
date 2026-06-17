using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TugasBesar.Core.Models;


namespace MysqlDatabaseConnectionLibrary
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProdukModels> Produk { get; set; }
        public DbSet<KategoriModels> Kategori { get; set; }

        public DbSet<AkunPegawaiModels> AkunPegawai { get; set; }
        //public DbSet<OperasionalModels> Operasional { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdukModels>(entity =>
            {
                entity.ToTable("produk");
                entity.HasKey(p => p.id);
                entity.Property(p => p.id).HasColumnName("id_produk");
                entity.Property(p => p.nama).HasColumnName("nama_produk");
                entity.Property(p => p.harga).HasColumnName("harga");
                entity.Property(p => p.kategori_id).HasColumnName("id_kategori");

                entity.HasOne(p => p.Kategori)
                    .WithMany(k => k.Produk)
                    .HasForeignKey(d => d.kategori_id);
            });

            modelBuilder.Entity<KategoriModels>(entity =>
            {
                entity.ToTable("kategori");
                entity.HasKey(k => k.id);
                entity.Property(k => k.id).HasColumnName("id_kategori");
                entity.Property(k => k.nama).HasColumnName("nama_kategori");
            });

            modelBuilder.Entity<OperasionalModels>(entity =>
            {
                entity.ToTable("operasional");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasColumnName("id_pengeluaran");

                entity.Property(e => e.Nama)
                      .HasColumnName("nama_pengeluaran");

                entity.Property(e => e.Harga)
                      .HasColumnName("nominal");

                entity.Property(e => e.IdUser)
                      .HasColumnName("id_user");

                entity.Property(e => e.Tanggal)
                      .HasColumnName("tanggal");

                entity.HasOne(o => o.User)
                      .WithMany(u => u.Operasional)
                      .HasForeignKey(o => o.IdUser)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AkunPegawaiModels>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasColumnName("id_user");

                entity.Property(e => e.nama)
                      .HasColumnName("username");

                entity.Property(e => e.nama_user)
                      .HasColumnName("nama_user");

                entity.Property(e => e.password)
                      .HasColumnName("password");

                entity.Property(e => e.role)
                      .HasColumnName("role");
            });


            modelBuilder.Entity<StatusModels>(entity =>
            {
                entity.ToTable("status");
                entity.HasKey(e => e.IdStatus);
                entity.Property(e => e.IdStatus).HasColumnName("id_status");
                entity.Property(e => e.NamaStatus).HasColumnName("nama_status");
            });

           
            modelBuilder.Entity<MetodePembayaranModels>(entity =>
            {
                entity.ToTable("metode_pembayaran");
                entity.HasKey(e => e.IdMetodePembayaran);
                entity.Property(e => e.IdMetodePembayaran).HasColumnName("id_metode_pembayaran");
                entity.Property(e => e.NamaMetode).HasColumnName("nama_metode");
            });

            
            modelBuilder.Entity<TransaksiModels>(entity =>
            {
                entity.ToTable("transaksi");
                entity.HasKey(e => e.IdTransaksi);

                
                entity.Property(e => e.IdTransaksi).HasColumnName("id_transaksi");
                entity.Property(e => e.IdUser).HasColumnName("id_user");
                entity.Property(e => e.NamaPembeli).HasColumnName("nama_pembeli");
                entity.Property(e => e.IdMetodePembayaran).HasColumnName("id_metode_pembayaran");
                entity.Property(e => e.UangDiterima).HasColumnName("uang_diterima");
                entity.Property(e => e.UangKembalian).HasColumnName("uang_kembalian");
                entity.Property(e => e.TotalHarga).HasColumnName("total_harga");
                entity.Property(e => e.IdStatus).HasColumnName("id_status");
                entity.Property(e => e.SnapToken).HasColumnName("snap_token");
                entity.Property(e => e.Tanggal).HasColumnName("tanggal");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                
                entity.HasOne(t => t.User)
                      .WithMany(u => u.Transaksi)
                      .HasForeignKey(t => t.IdUser)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.MetodePembayaran)
                      .WithMany(m => m.Transaksi)
                      .HasForeignKey(t => t.IdMetodePembayaran)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Status)
                      .WithMany(s => s.Transaksi)
                      .HasForeignKey(t => t.IdStatus)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            
            modelBuilder.Entity<TransaksiDetailsModels>(entity =>
            {
                entity.ToTable("detail_transaksi");
                entity.HasKey(e => e.IdDetail);

                
                entity.Property(e => e.IdDetail).HasColumnName("id_detail");
                entity.Property(e => e.IdTransaksi).HasColumnName("id_transaksi");
                entity.Property(e => e.IdProduk).HasColumnName("id_produk");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.HargaSatuan).HasColumnName("harga_satuan");
                entity.Property(e => e.Subtotal).HasColumnName("subtotal");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                
                entity.HasOne(d => d.Transaksi)
                      .WithMany(t => t.TransaksiDetails)
                      .HasForeignKey(d => d.IdTransaksi)
                      .OnDelete(DeleteBehavior.Restrict); 
            });
        
    }
    }
}
