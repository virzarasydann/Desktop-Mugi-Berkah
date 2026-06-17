
-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.14.0.7165
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table mugi_berkah.detail_transaksi
CREATE TABLE IF NOT EXISTS `detail_transaksi` (
  `id_detail` bigint unsigned NOT NULL AUTO_INCREMENT,
  `id_transaksi` bigint unsigned NOT NULL,
  `id_produk` bigint unsigned NOT NULL,
  `qty` int NOT NULL,
  `harga_satuan` int NOT NULL,
  `subtotal` int NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `detail_transaksi_id_transaksi_foreign` (`id_transaksi`),
  KEY `detail_transaksi_id_produk_foreign` (`id_produk`),
  CONSTRAINT `detail_transaksi_id_produk_foreign` FOREIGN KEY (`id_produk`) REFERENCES `produk` (`id_produk`),
  CONSTRAINT `detail_transaksi_id_transaksi_foreign` FOREIGN KEY (`id_transaksi`) REFERENCES `transaksi` (`id_transaksi`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.detail_transaksi: ~0 rows (approximately)

-- Dumping structure for table mugi_berkah.failed_jobs
CREATE TABLE IF NOT EXISTS `failed_jobs` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `uuid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `connection` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `queue` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `payload` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `exception` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.failed_jobs: ~0 rows (approximately)

-- Dumping structure for table mugi_berkah.kategori
CREATE TABLE IF NOT EXISTS `kategori` (
  `id_kategori` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nama_kategori` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_kategori`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.kategori: ~2 rows (approximately)
INSERT INTO `kategori` (`id_kategori`, `nama_kategori`, `created_at`, `updated_at`) VALUES
	(1, 'Kopii', '2026-01-01 17:30:39', '2026-01-13 18:39:56'),
	(4, 'Makanan', '2026-01-13 18:39:34', '2026-01-13 18:39:34');

-- Dumping structure for table mugi_berkah.metode_pembayaran
CREATE TABLE IF NOT EXISTS `metode_pembayaran` (
  `id_metode_pembayaran` int NOT NULL AUTO_INCREMENT,
  `nama_metode` varchar(100) NOT NULL,
  PRIMARY KEY (`id_metode_pembayaran`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.metode_pembayaran: ~2 rows (approximately)
INSERT INTO `metode_pembayaran` (`id_metode_pembayaran`, `nama_metode`) VALUES
	(1, 'QRIS'),
	(2, 'CASH');

-- Dumping structure for table mugi_berkah.migrations
CREATE TABLE IF NOT EXISTS `migrations` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `batch` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.migrations: ~10 rows (approximately)
INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
	(1, '2014_10_12_100000_create_password_reset_tokens_table', 1),
	(2, '2019_08_19_000000_create_failed_jobs_table', 1),
	(3, '2019_12_14_000001_create_personal_access_tokens_table', 1),
	(4, '2026_01_01_142904_create_kategori_table', 1),
	(5, '2026_01_01_142909_create_produk_table', 1),
	(6, '2026_01_01_142915_create_users_table', 1),
	(7, '2026_01_01_142920_create_transaksi_table', 1),
	(8, '2026_01_01_142926_create_detail_transaksi_table', 1),
	(9, '2026_01_01_142931_create_pengeluaran_table', 1),
	(10, '2026_01_01_142935_create_keranjang_table', 2),
	(11, '2026_01_01_160140_create_sessions_table', 2),
	(12, '2026_01_02_121314_add_midtrans_fields_to_transaksi_table', 3);

-- Dumping structure for table mugi_berkah.operasional
CREATE TABLE IF NOT EXISTS `operasional` (
  `id_pengeluaran` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nama_pengeluaran` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `id_user` bigint unsigned NOT NULL,
  `nominal` int NOT NULL,
  `tanggal` date NOT NULL,
  `keterangan` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_pengeluaran`),
  KEY `id_users_foreign` (`id_user`),
  CONSTRAINT `id_users_foreign` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.operasional: ~0 rows (approximately)

-- Dumping structure for table mugi_berkah.password_reset_tokens
CREATE TABLE IF NOT EXISTS `password_reset_tokens` (
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `token` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.password_reset_tokens: ~0 rows (approximately)

-- Dumping structure for table mugi_berkah.personal_access_tokens
CREATE TABLE IF NOT EXISTS `personal_access_tokens` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `tokenable_type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `tokenable_id` bigint unsigned NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `token` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `abilities` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `expires_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.personal_access_tokens: ~0 rows (approximately)

-- Dumping structure for table mugi_berkah.produk
CREATE TABLE IF NOT EXISTS `produk` (
  `id_produk` bigint unsigned NOT NULL AUTO_INCREMENT,
  `id_kategori` bigint unsigned NOT NULL,
  `nama_produk` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `harga` int NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_produk`),
  KEY `produk_id_kategori_foreign` (`id_kategori`),
  CONSTRAINT `produk_id_kategori_foreign` FOREIGN KEY (`id_kategori`) REFERENCES `kategori` (`id_kategori`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.produk: ~12 rows (approximately)
INSERT INTO `produk` (`id_produk`, `id_kategori`, `nama_produk`, `harga`, `created_at`, `updated_at`) VALUES
	(3, 1, 'Kopi Mugi', 12000, '2026-01-01 11:10:47', '2026-01-01 11:10:47'),
	(5, 1, 'Ale ale', 1000, '2026-01-13 18:30:25', '2026-01-13 18:30:25');

-- Dumping structure for table mugi_berkah.sessions
CREATE TABLE IF NOT EXISTS `sessions` (
  `id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `user_id` bigint unsigned DEFAULT NULL,
  `ip_address` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `user_agent` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `payload` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `last_activity` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `sessions_user_id_index` (`user_id`),
  KEY `sessions_last_activity_index` (`last_activity`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.sessions: ~0 rows (approximately)

-- Dumping structure for table mugi_berkah.status
CREATE TABLE IF NOT EXISTS `status` (
  `id_status` int NOT NULL AUTO_INCREMENT,
  `nama_status` varchar(10) NOT NULL,
  PRIMARY KEY (`id_status`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.status: ~0 rows (approximately)
INSERT INTO `status` (`id_status`, `nama_status`) VALUES
	(1, 'Lunas'),
	(2, 'BelumLunas');

-- Dumping structure for table mugi_berkah.transaksi
CREATE TABLE IF NOT EXISTS `transaksi` (
  `id_transaksi` bigint unsigned NOT NULL AUTO_INCREMENT,
  `id_user` bigint unsigned NOT NULL,
  `nama_pembeli` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `id_metode_pembayaran` int NOT NULL,
  `uang_diterima` int DEFAULT NULL,
  `uang_kembalian` int DEFAULT NULL,
  `total_harga` int NOT NULL,
  `id_status` int NOT NULL,
  `snap_token` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `tanggal` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_transaksi`),
  KEY `transaksi_id_user_foreign` (`id_user`),
  KEY `transaksi_id_status` (`id_status`),
  KEY `transaksi_id_metode_pembayaran` (`id_metode_pembayaran`),
  CONSTRAINT `transaksi_id_metode_pembayaran` FOREIGN KEY (`id_metode_pembayaran`) REFERENCES `metode_pembayaran` (`id_metode_pembayaran`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `transaksi_id_status` FOREIGN KEY (`id_status`) REFERENCES `status` (`id_status`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `transaksi_id_user_foreign` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.transaksi: ~16 rows (approximately)

-- Dumping structure for table mugi_berkah.users
CREATE TABLE IF NOT EXISTS `users` (
  `id_user` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nama_user` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `role` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'PEGAWAI',
  `remember_token` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `users_username_unique` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table mugi_berkah.users: ~6 rows (approximately)
INSERT INTO `users` (`id_user`, `nama_user`, `username`, `password`, `role`, `remember_token`, `created_at`, `updated_at`) VALUES
	(1, 'Admin Sistem', 'admin', '$2y$12$aljtYySmpQxdbmzoLWusMOAZt.LDs1t6DUoRfcN1Qtf5Qp4L.hcWu', 'admin', NULL, '2026-01-01 09:17:34', '2026-01-01 09:17:34'),
	(2, 'Kasir Toko', 'kasir', '$2y$12$ugv95al8dK788UcS1wIkh.sQhsVqib2ldvUSRAbNzcupAMH4KzZwS', 'PEGAWAI', NULL, '2026-01-01 09:17:35', '2026-01-02 06:51:43'),
	(3, 'Kasir 2', 'kasir2', '$2y$12$MRgeUusNuIynxd0ib5x5o.I5WnEFvynjWDrwjxanuWjvXp1LLcepa', 'PEGAWAI', NULL, '2026-01-01 09:17:35', '2026-01-01 09:17:35'),
	(4, '123123', '123123123', '$2y$12$LmBIB2hRaf7YM75Gv.p/I.AeN8BdoznXJyUrHuhuVCfUNtfSixRj6', 'PEGAWAI', NULL, '2026-01-11 21:47:05', '2026-01-11 21:47:05'),
	(5, 'lala', 'lulu', '$2y$12$JRPtgaqbRI03IldCa1/deuWcgM9KFsWKC4pUA3HYuIOiFAa2LJ/dy', 'PEGAWAI', NULL, '2026-01-13 18:57:35', '2026-01-13 18:57:35');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

