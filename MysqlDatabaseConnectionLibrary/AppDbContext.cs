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
                
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id_produk");
                entity.Property(e => e.nama).HasColumnName("nama_produk");
                entity.Property(e => e.kategori_id).HasColumnName("id_kategori");
                entity.Property(e => e.harga).HasColumnName("harga");

                entity.HasOne(p => p.Kategori)
                      .WithMany(k => k.Produk)
                      .HasForeignKey(d => d.kategori_id);
            });

            modelBuilder.Entity<KategoriModels>(entity =>
            {
                entity.ToTable("kategori");
                
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id_kategori");
                entity.Property(e => e.nama).HasColumnName("nama_kategori");
            });

            modelBuilder.Entity<AkunPegawaiModels>()
                .ToTable("pegawai");

            modelBuilder.Entity<OperasionalModels>(entity =>
            {
                entity.ToTable("operasional");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasColumnName("id");

                entity.Property(e => e.Nama)
                      .HasColumnName("nama");

                entity.Property(e => e.Harga)
                      .HasColumnName("harga");
            });

            modelBuilder.Entity<TransaksiModels>(entity =>
            {
                entity.ToTable("transaksi");

                entity.HasKey(e => e.id);

                entity.Property(e => e.metode_pembayaran)
                      .HasConversion<string>();
            });

            modelBuilder.Entity<TransaksiDetailsModels>(entity =>
            {
                entity.ToTable("transaksi_detail");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                      .HasColumnName("id");

                entity.Property(e => e.transaksi_id)
                      .HasColumnName("transaksi_id");

                entity.HasOne(d => d.Transaksi)
                      .WithMany(t => t.TransaksiDetails)
                      .HasForeignKey(d => d.transaksi_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
