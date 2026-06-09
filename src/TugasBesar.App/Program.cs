using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Windows.Forms;
using TugasBesar.App.Views;
using TugasBesar.App.Views.Pegawai;
using TugasBesar.App.Views.Pegawai.Transaksi;
using TugasBesar.Core.Controllers.Interfaces; 
using TugasBesar.Core.Services;
//using TugasBesar.App.Views.Pegawai.Produk;
//using TugasBesar.App.Views.Pegawai.Kategori;
//using TugasBesar.App.Views.Pegawai.Operasional;
//using TugasBesar.App.Views.Admin.AkunPegawai;

namespace TugasBesar.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

           
            var apiBaseUrl = new Uri("https://localhost:7008");

            services.AddSingleton<MasterDataCacheService>();
            services.AddRefitClient<IAkunPegawaiApi>().ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);
            services.AddRefitClient<IKategoriApi>().ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);
            services.AddRefitClient<IProdukApi>().ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);
            services.AddRefitClient<ITransaksiApi>().ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);
            services.AddRefitClient<IOperasionalApi>().ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

           
            services.AddTransient<LoginForm>();
            services.AddTransient<BaseFormPegawai>();

          
            services.AddTransient<ViewTransaksi>();
            //services.AddTransient<ViewProduk>();
            //services.AddTransient<ViewKategori>();
            //services.AddTransient<ViewOperasional>();
            //services.AddTransient<ViewTambahAkunPegawai>();

            using var serviceProvider = services.BuildServiceProvider();

           
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}