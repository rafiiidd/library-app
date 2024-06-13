using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class DbPerpus
{
    private readonly string connectionString;

    private readonly MySqlConnection _connection;

    public DbPerpus(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }

    //  Inventori method
    public List<Inventori> GetAllBuku()
    {
        List<Inventori> inventoriList = new List<Inventori>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inventori_Buku";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventori buku = new Inventori
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            judul_buku = reader["Judul_Buku"].ToString(),
                            rak_buku = reader["Rak_Buku"].ToString(),
                            penerbit_buku = reader["Penerbit_Buku"].ToString(),
                            pengarang_buku = reader["Pengarang_Buku"].ToString(),
                            tahun_buku = Convert.ToInt32(reader["Tahun_Buku"])
                        };
                        inventoriList.Add(buku);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return inventoriList;
    }

    public List<Inventori> GetBukuByJudul(string judul_buku)
    {
        List<Inventori> inventoriList = new List<Inventori>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, judul_buku, rak_buku, penerbit_buku, pengarang_buku, tahun_buku FROM inventori_buku WHERE judul_buku = @Judul_Buku";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Judul_Buku", judul_buku);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventori buku = new Inventori
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            judul_buku = reader["Judul_Buku"].ToString(),
                            rak_buku = reader["Rak_Buku"].ToString(),
                            penerbit_buku = reader["Penerbit_Buku"].ToString(),
                            pengarang_buku = reader["Pengarang_Buku"].ToString(),
                            tahun_buku = Convert.ToInt32(reader["Tahun_Buku"])
                        };
                        inventoriList.Add(buku);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return inventoriList;
    }

    public List<Inventori> GetBukuById(int id)
    {
        List<Inventori> inventoriList = new List<Inventori>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, judul_buku, rak_buku, penerbit_buku, pengarang_buku, tahun_buku FROM inventori_buku WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventori buku = new Inventori
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            judul_buku = reader["Judul_Buku"].ToString(),
                            rak_buku = reader["Rak_Buku"].ToString(),
                            penerbit_buku = reader["Penerbit_Buku"].ToString(),
                            pengarang_buku = reader["Pengarang_Buku"].ToString(),
                            tahun_buku = Convert.ToInt32(reader["Tahun_Buku"])
                        };
                        inventoriList.Add(buku);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return inventoriList;
    }

    public int CreateBuku(Inventori buku)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO Inventori_Buku (judul_buku, rak_buku, penerbit_buku, pengarang_buku, tahun_buku) VALUES (@Judul_Buku, @Rak_Buku, @Penerbit_Buku, @Pengarang_Buku, @Tahun_Buku)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Judul_Buku", buku.judul_buku);
                command.Parameters.AddWithValue("@Rak_Buku", buku.rak_buku);
                command.Parameters.AddWithValue("@Penerbit_Buku", buku.penerbit_buku);
                command.Parameters.AddWithValue("@Pengarang_Buku", buku.pengarang_buku);
                command.Parameters.AddWithValue("@Tahun_Buku", buku.tahun_buku);
                

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdateBuku(int id, Inventori buku)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE Inventori_Buku SET judul_buku = @Judul_Buku, rak_buku = @Rak_Buku, penerbit_buku = @Penerbit_Buku, pengarang_buku = @Pengarang_Buku, " + " tahun_buku = @Tahun_Buku  WHERE id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Judul_Buku", buku.judul_buku);
                command.Parameters.AddWithValue("@Rak_Buku", buku.rak_buku);
                command.Parameters.AddWithValue("@Penerbit_Buku", buku.penerbit_buku);
                command.Parameters.AddWithValue("@Pengarang_Buku", buku.pengarang_buku);
                command.Parameters.AddWithValue("@Tahun_Buku", buku.tahun_buku);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeleteBuku(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM Inventori_Buku WHERE id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    // Peminjaman method
    public List<Peminjaman> GetAllPeminjaman()
    {
        List<Peminjaman> peminjamanList = new List<Peminjaman>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM peminjaman_buku";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Peminjaman peminjaman = new Peminjaman
                        {
                            id = Convert.ToInt32(reader["id"]),
                            nama_peminjam = Convert.ToInt32(reader["nama_peminjam"]),
                            judul_buku_pinjaman = Convert.ToInt32(reader["judul_buku_pinjaman"]),
                            waktu_peminjaman = Convert.ToDateTime(reader["waktu_peminjaman"]).ToString("yyyy-MM-dd"),
                            durasi_peminjaman = Convert.ToInt32(reader["durasi_peminjaman"])
                        };
                        peminjamanList.Add(peminjaman);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return peminjamanList;
    }

    public int CreatePeminjaman(Peminjaman peminjaman)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO peminjaman_buku (nama_peminjam, judul_buku_pinjaman, waktu_peminjaman, durasi_peminjaman) VALUES (@Nama_peminjam, @Judul_buku_pinjaman, @Waktu_peminjaman, @Durasi_peminjaman)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nama_peminjam", peminjaman.nama_peminjam);
                command.Parameters.AddWithValue("@Judul_buku_pinjaman", peminjaman.judul_buku_pinjaman);
                command.Parameters.AddWithValue("@Waktu_peminjaman", peminjaman.waktu_peminjaman);
                command.Parameters.AddWithValue("@Durasi_peminjaman", peminjaman.durasi_peminjaman);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdatePeminjaman(int id, Peminjaman peminjaman)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE peminjaman_buku SET nama_peminjam = @Nama_peminjam, judul_buku_pinjaman = @Judul_buku_pinjaman, waktu_peminjaman = @Waktu_peminjaman, " + " durasi_peminjaman = @Durasi_peminjaman WHERE id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nama_peminjam", peminjaman.nama_peminjam);
                command.Parameters.AddWithValue("@Judul_buku_pinjaman", peminjaman.judul_buku_pinjaman);
                command.Parameters.AddWithValue("@Waktu_peminjaman", peminjaman.waktu_peminjaman);
                command.Parameters.AddWithValue("@Durasi_peminjaman", peminjaman.durasi_peminjaman);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeletePeminjaman(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM peminjaman_buku WHERE id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int GetLengthPeminjaman(int nama_peminjam)
    {
        int count = 0;
        using (MySqlConnection connection = _connection)
        {
            string query = "SELECT COUNT(*) As count FROM peminjaman_buku WHERE nama_peminjam = @Nama_peminjam";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nama_peminjam", nama_peminjam);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = Convert.ToInt32(reader["count"]);
                    }
                }
            }
        }
        return count;
    }

    public List<Peminjaman> GetPeminjamanByNama(int nama_peminjam)
    {
        List<Peminjaman> peminjamanList = new List<Peminjaman>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, nama_peminjam, judul_buku_pinjaman, waktu_peminjaman, durasi_peminjaman FROM peminjaman_buku WHERE nama_peminjam = @Nama_Peminjam";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nama_Peminjam", nama_peminjam);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Peminjaman peminjam = new Peminjaman
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            nama_peminjam = Convert.ToInt32(reader["Nama_Peminjam"]),
                            judul_buku_pinjaman = Convert.ToInt32(reader["Judul_Buku_Pinjaman"]),
                            waktu_peminjaman = reader["Waktu_Peminjaman"].ToString(),
                            durasi_peminjaman = Convert.ToInt32(reader["Durasi_Peminjaman"])
                        };
                        peminjamanList.Add(peminjam);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return peminjamanList;
    }
    
    public List<Peminjaman> GetPeminjamanById(int id)
    {
        List<Peminjaman> peminjamanList = new List<Peminjaman>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, nama_peminjam, judul_buku_pinjaman, waktu_peminjaman, durasi_peminjaman FROM peminjaman_buku WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Peminjaman peminjam = new Peminjaman
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            nama_peminjam = Convert.ToInt32(reader["Nama_Peminjam"]),
                            judul_buku_pinjaman = Convert.ToInt32(reader["Judul_Buku_Pinjaman"]),
                            waktu_peminjaman = reader["Waktu_Peminjaman"].ToString(),
                            durasi_peminjaman = Convert.ToInt32(reader["Durasi_Peminjaman"])
                        };
                        peminjamanList.Add(peminjam);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return peminjamanList;
    }

    // Pengembalian method
    public List<Pengembalian_buku> GetAllPengembalian_bukus()
    {
        List<Pengembalian_buku> pengembalian_bukuList = new List<Pengembalian_buku>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM pengembalian_buku";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pengembalian_buku Pengembalian_buku = new Pengembalian_buku
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            nama_peminjam = Convert.ToInt32(reader["nama_peminjam"]),
                            judul_buku_pinjaman = Convert.ToInt32(reader["judul_buku_pinjaman"]),
                            waktu_pengembalian = Convert.ToDateTime(reader["waktu_pengembalian"]).ToString("yyyy-MM-dd"),
                            denda = Convert.ToInt32(reader["denda"])
                        };
                        pengembalian_bukuList.Add(Pengembalian_buku);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pengembalian_bukuList;
    }

    public int CreatePengembalian_buku(Pengembalian_buku pengembalian_buku)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "INSERT INTO pengembalian_buku (nama_peminjam, judul_buku_pinjaman, waktu_pengembalian, denda) VALUES (@Nama_peminjam, @Judul_buku_pinjaman, @Waktu_pengembalian, @Denda)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nama_peminjam", pengembalian_buku.nama_peminjam);
                command.Parameters.AddWithValue("@Judul_buku_pinjaman", pengembalian_buku.judul_buku_pinjaman);
                command.Parameters.AddWithValue("@Waktu_pengembalian", pengembalian_buku.waktu_pengembalian);
                command.Parameters.AddWithValue("@Denda", pengembalian_buku.denda);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdatePengembalian(int id, Pengembalian_buku pengembalian)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE pengembalian_buku SET nama_peminjam = @Nama_peminjam, judul_buku_pinjaman = @Judul_buku_pinjaman, waktu_pengembalian = @Waktu_pengembalian, " + " denda = @Denda WHERE id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nama_peminjam", pengembalian.nama_peminjam);
                command.Parameters.AddWithValue("@Judul_buku_pinjaman", pengembalian.judul_buku_pinjaman);
                command.Parameters.AddWithValue("@Waktu_pengembalian", pengembalian.waktu_pengembalian);
                command.Parameters.AddWithValue("@Denda", pengembalian.denda);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeletePengembalian_buku(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "DELETE FROM pengembalian_buku WHERE id = @Id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public List<Pengembalian_buku> GetPengembalianByNama(int nama_peminjam)
    {
        List<Pengembalian_buku> pengembalianList = new List<Pengembalian_buku>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT nama_peminjam, judul_buku_pinjaman, waktu_pengembalian, denda FROM pengembalian_buku WHERE nama_peminjam = @Nama_Peminjam";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nama_Peminjam", nama_peminjam);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pengembalian_buku pengembalian = new Pengembalian_buku
                        {
                            nama_peminjam = Convert.ToInt32(reader["Nama_Peminjam"]),
                            judul_buku_pinjaman = Convert.ToInt32(reader["Judul_Buku_Pinjaman"]),
                            waktu_pengembalian = reader["Waktu_pengembalian"].ToString(),
                            denda = Convert.ToInt32(reader["Denda"])
                        };
                        pengembalianList.Add(pengembalian);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pengembalianList;
    }
    
    public List<Pengembalian_buku> GetPengembalianById(int id)
    {
        List<Pengembalian_buku> pengembalianList = new List<Pengembalian_buku>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, nama_peminjam, judul_buku_pinjaman, waktu_pengembalian, denda FROM pengembalian_buku WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pengembalian_buku pengembalian = new Pengembalian_buku
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            nama_peminjam = Convert.ToInt32(reader["Nama_Peminjam"]),
                            judul_buku_pinjaman = Convert.ToInt32(reader["Judul_Buku_Pinjaman"]),
                            waktu_pengembalian = reader["Waktu_pengembalian"].ToString(),
                            denda = Convert.ToInt32(reader["Denda"])
                        };
                        pengembalianList.Add(pengembalian);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pengembalianList;
    }

    public int GetLengthPengembalian(int nama_peminjam)
    {
        int count = 0;
        using (MySqlConnection connection = _connection)
        {
            string query = "SELECT COUNT(*) As count FROM pengembalian_buku WHERE nama_peminjam = @Nama_peminjam";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nama_peminjam", nama_peminjam);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = Convert.ToInt32(reader["count"]);
                    }
                }
            }
        }
        return count;
    }

    public List<Pengguna> GetAllPengguna()
    {
        List<Pengguna> penggunaList = new List<Pengguna>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM pengguna";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pengguna pengguna = new Pengguna
                        {
                            id = Convert.ToInt32(reader["id"]),
                            nama = reader["nama"].ToString(),
                            alamat = reader["alamat"].ToString(),
                            pass = reader["pass"].ToString(),
                        };
                        penggunaList.Add(pengguna);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return penggunaList;
    }
}