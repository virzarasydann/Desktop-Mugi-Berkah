using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TugasBesar.Core.Models;


namespace MysqlDatabaseConnectionLibrary
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<ProdukModels> Produk { get; set; }
        //public DbSet<KategoriModels> Kategori { get; set; }

        //public DbSet<AkunPegawaiModels> AkunPegawai { get; set; }
        //public DbSet<OperasionalModels> Operasional { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdukModels>()
                .ToTable("produk")
                .HasOne(p => p.Kategori)      
                .WithMany(k => k.Produk)
                .HasForeignKey(d => d.kategori_id);
            modelBuilder.Entity<KategoriModels>()
                .ToTable("kategori");
            modelBuilder.Entity<AkunPegawaiModels>()
                .ToTable("pegawai");
            modelBuilder.Entity<OperasionalModels>()
                .ToTable("operasional");

            modelBuilder.Entity<TransaksiModels>(entity =>
            {
                entity.ToTable("transaksi");
                entity.HasKey(e => e.id);
                entity.Property(e => e.metode_pembayaran).HasConversion<string>();
            });

           
            modelBuilder.Entity<TransaksiDetailsModels>(entity =>
            {
                entity.ToTable("transaksi_detail");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.transaksi_id).HasColumnName("transaksi_id");

                
                entity.HasOne(d => d.Transaksi)
                      .WithMany(t => t.TransaksiDetails)
                      .HasForeignKey(d => d.transaksi_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });


        }
    }
}
