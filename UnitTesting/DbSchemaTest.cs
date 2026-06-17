using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MysqlDatabaseConnectionLibrary;
using System.Linq;
using TugasBesar.Core.Models;

namespace UnitTesting
{
    public class DbSchemaTest
    {
        [Fact]
        public void TestDatabaseConnectionAndQuery()
        {
            var connectionString = "Server=localhost;Database=mugi_berkah;User=root;Password=;";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
            try
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            catch (Exception ex)
            {
                throw new Exception("FAILED TO DETECT SERVER VERSION (MySQL might not be running): " + ex.ToString());
            }

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                try
                {
                    // Alter users.role column to varchar(50) to allow 'PEGAWAI'
                    context.Database.ExecuteSqlRaw("ALTER TABLE `users` MODIFY COLUMN `role` varchar(50) NOT NULL DEFAULT 'PEGAWAI';");
                    context.Database.ExecuteSqlRaw("UPDATE `users` SET `role` = 'PEGAWAI' WHERE `role` = 'kasir';");

                    var count = context.AkunPegawai.Count();
                    Assert.True(count >= 0);
                }
                catch (Exception ex)
                {
                    var fullMessage = ex.ToString();
                    if (ex.InnerException != null)
                    {
                        fullMessage += "\nINNER EXCEPTION: " + ex.InnerException.ToString();
                    }
                    throw new Exception("DATABASE QUERY FAILED: " + fullMessage);
                }
            }
        }

        [Fact]
        public void TestAddAkunPegawaiWithPegawaiRole()
        {
            var connectionString = "Server=localhost;Database=mugi_berkah;User=root;Password=;";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                // Ensure table structure is altered
                context.Database.ExecuteSqlRaw("ALTER TABLE `users` MODIFY COLUMN `role` varchar(50) NOT NULL DEFAULT 'PEGAWAI';");
                context.Database.ExecuteSqlRaw("UPDATE `users` SET `role` = 'PEGAWAI' WHERE `role` = 'kasir';");

                var uniqueUsername = "test_pegawai_" + Guid.NewGuid().ToString().Substring(0, 8);
                var testPegawai = new AkunPegawaiModels
                {
                    nama = uniqueUsername,
                    nama_user = "Test Pegawai Name",
                    password = "hashed_password_123",
                    role = "PEGAWAI"
                };

                try
                {
                    context.AkunPegawai.Add(testPegawai);
                    context.SaveChanges();

                    // Retrieve to verify
                    var retrieved = context.AkunPegawai.FirstOrDefault(a => a.nama == uniqueUsername);
                    Assert.NotNull(retrieved);
                    Assert.Equal("PEGAWAI", retrieved.role);

                    // Clean up
                    context.AkunPegawai.Remove(retrieved);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var fullMessage = ex.ToString();
                    if (ex.InnerException != null)
                    {
                        fullMessage += "\nINNER EXCEPTION: " + ex.InnerException.ToString();
                    }
                    throw new Exception("ADD PEGAWAI TEST FAILED: " + fullMessage);
                }
            }
        }
    }
}
