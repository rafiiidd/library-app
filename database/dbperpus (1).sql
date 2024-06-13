-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 28, 2024 at 01:36 PM
-- Server version: 10.4.32-MariaDB-log
-- PHP Version: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbperpus`
--

-- --------------------------------------------------------

--
-- Table structure for table `denda`
--

CREATE TABLE `denda` (
  `keterangan` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `denda`
--

INSERT INTO `denda` (`keterangan`) VALUES
('Tidak'),
('Ya');

-- --------------------------------------------------------

--
-- Table structure for table `inventori_buku`
--

CREATE TABLE `inventori_buku` (
  `id` int(11) NOT NULL,
  `judul_buku` varchar(70) NOT NULL,
  `rak_buku` varchar(15) NOT NULL,
  `penerbit_buku` varchar(40) NOT NULL,
  `pengarang_buku` varchar(40) NOT NULL,
  `tahun_buku` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventori_buku`
--

INSERT INTO `inventori_buku` (`id`, `judul_buku`, `rak_buku`, `penerbit_buku`, `pengarang_buku`, `tahun_buku`) VALUES
(25, 'Satra', 'a', 'akaka', 'djhjsd', 2022),
(26, 'sksjdkjks', 'ksdjsah', 'sjhdj', 'hdahkd', 2023);

-- --------------------------------------------------------

--
-- Table structure for table `karyawan`
--

CREATE TABLE `karyawan` (
  `id` int(11) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `jabatan` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `peminjaman_buku`
--

CREATE TABLE `peminjaman_buku` (
  `id` int(11) NOT NULL,
  `nama_peminjam` int(11) NOT NULL,
  `judul_buku_pinjaman` int(11) NOT NULL,
  `waktu_peminjaman` datetime NOT NULL,
  `durasi_peminjaman` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `peminjaman_buku`
--

INSERT INTO `peminjaman_buku` (`id`, `nama_peminjam`, `judul_buku_pinjaman`, `waktu_peminjaman`, `durasi_peminjaman`) VALUES
(1, 6, 25, '2024-05-28 13:02:13', 30),
(2, 6, 26, '2024-05-28 13:03:28', 40);

-- --------------------------------------------------------

--
-- Table structure for table `pengembalian_buku`
--

CREATE TABLE `pengembalian_buku` (
  `id` int(11) NOT NULL,
  `nama_peminjam` int(11) NOT NULL,
  `judul_buku_pinjaman` int(11) NOT NULL,
  `waktu_pengembalian` datetime NOT NULL,
  `denda` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pengembalian_buku`
--

INSERT INTO `pengembalian_buku` (`id`, `nama_peminjam`, `judul_buku_pinjaman`, `waktu_pengembalian`, `denda`) VALUES
(3, 6, 25, '2024-05-28 13:05:35', 'Tidak');

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE `pengguna` (
  `id` int(11) NOT NULL,
  `nama` varchar(10) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `pass` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`id`, `nama`, `alamat`, `pass`) VALUES
(6, 'Satra', 'Tuban', '123'),
(7, 'Rafly', 'Sumur bor', '456');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `denda`
--
ALTER TABLE `denda`
  ADD PRIMARY KEY (`keterangan`);

--
-- Indexes for table `inventori_buku`
--
ALTER TABLE `inventori_buku`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `karyawan`
--
ALTER TABLE `karyawan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `peminjaman_buku`
--
ALTER TABLE `peminjaman_buku`
  ADD PRIMARY KEY (`id`),
  ADD KEY `namapinjam` (`nama_peminjam`),
  ADD KEY `judulbukupinjam` (`judul_buku_pinjaman`);

--
-- Indexes for table `pengembalian_buku`
--
ALTER TABLE `pengembalian_buku`
  ADD PRIMARY KEY (`id`),
  ADD KEY `judulbukukembali` (`judul_buku_pinjaman`),
  ADD KEY `namakembali` (`nama_peminjam`),
  ADD KEY `denda` (`denda`);

--
-- Indexes for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `inventori_buku`
--
ALTER TABLE `inventori_buku`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `karyawan`
--
ALTER TABLE `karyawan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `peminjaman_buku`
--
ALTER TABLE `peminjaman_buku`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `pengembalian_buku`
--
ALTER TABLE `pengembalian_buku`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `pengguna`
--
ALTER TABLE `pengguna`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `peminjaman_buku`
--
ALTER TABLE `peminjaman_buku`
  ADD CONSTRAINT `judulbukupinjam` FOREIGN KEY (`judul_buku_pinjaman`) REFERENCES `inventori_buku` (`id`),
  ADD CONSTRAINT `namapinjam` FOREIGN KEY (`nama_peminjam`) REFERENCES `pengguna` (`id`);

--
-- Constraints for table `pengembalian_buku`
--
ALTER TABLE `pengembalian_buku`
  ADD CONSTRAINT `denda` FOREIGN KEY (`denda`) REFERENCES `denda` (`keterangan`),
  ADD CONSTRAINT `judulbukukembali` FOREIGN KEY (`judul_buku_pinjaman`) REFERENCES `inventori_buku` (`id`),
  ADD CONSTRAINT `namakembali` FOREIGN KEY (`nama_peminjam`) REFERENCES `pengguna` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
