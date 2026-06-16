using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Text.Json;
using System.Windows.Forms;
using TugasBesar.App.Views;
using TugasBesar.App.Views.Pegawai;
using TugasBesar.App.Views.Pegawai.Transaksi;
using TugasBesar.Core.Controllers.Interfaces; 
using TugasBesar.Core.Services;
//using TugasBesar.App.Views.Pegawai.Produk;
//using TugasBesar.App.Views.Pegawai.Kategori;
using TugasBesar.App.Views.Pegawai.Operasional;
using TugasBesar.App.Views.Admin.AkunPegawai;
using TugasBesar.App.Views.Admin;
using TugasBesar.App.Views.Admin.Riwayat;

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


            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true, 
                WriteIndented = false
            };
            var refitSettings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
            };

            var apiBaseUrl = new Uri("https://localhost:7008");

            services.AddSingleton<MasterDataCacheService>();

           
            services.AddRefitClient<IAkunPegawaiApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddRefitClient<IKategoriApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddRefitClient<IProdukApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddRefitClient<ITransaksiApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddRefitClient<IOperasionalApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddRefitClient<IMetodePembayaranApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddRefitClient<IStatusApi>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = apiBaseUrl);

            services.AddTransient<LoginForm>();
            services.AddTransient<BaseFormPegawai>();
            services.AddTransient<BaseFormAdmin>();
            services.AddTransient<ViewRiwayat>();

            services.AddTransient<ViewTransaksi>();
            //services.AddTransient<ViewProduk>();
            //services.AddTransient<ViewKategori>();
            //services.AddTransient<ViewOperasional>();
            services.AddTransient<ViewTambahAkunPegawai>();

            using var serviceProvider = services.BuildServiceProvider();

           
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}