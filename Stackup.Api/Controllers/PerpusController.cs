using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class PerpusController : ControllerBase
{
    private readonly DbPerpus _dbManager;

    Response response = new Response();

    public PerpusController(IConfiguration configuration)
    {
        _dbManager = new DbPerpus(configuration);
    }

    // Inventori
    [HttpGet("/GetInventori")]

    public IActionResult GetBuku()
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetAllBuku();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost("/CreateInventori")]
    
    public IActionResult CreateBuku([FromBody] Inventori buku)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.CreateBuku(buku);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPut("/UpdateInventori/{id}")]

    public IActionResult UpdateBuku(int id, [FromBody] Inventori buku)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.UpdateBuku(id, buku);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpDelete("/DeleteInventori/{id}")]

    public IActionResult DeleteBuku(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.DeleteBuku(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet ("/GetInventoriByJudul/{judul_buku}")]

    public IActionResult GetBukuByJudul(string judul_buku)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetBukuByJudul(judul_buku);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
    
    [HttpGet ("/GetInventoriById/{id}")]

    public IActionResult GetBukuById(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetBukuById(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    // Peminjaman
    [HttpGet("/GetPeminjaman")]
    
    public IActionResult GetPeminjaman()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbManager.GetAllPeminjaman();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("/GetLengthPeminjaman/{nama_peminjam}")]
    
    public IActionResult GetLengthPeminjaman(int nama_peminjam)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbManager.GetLengthPeminjaman(nama_peminjam);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost("/CreatePeminjaman")]
    
    public IActionResult CreatePeminjaman([FromBody] Peminjaman peminjaman)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.CreatePeminjaman(peminjaman);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message; 
        }
        return Ok(response);
    }

    [HttpPut("/UpdatePeminjaman/{id}")]
    
    public IActionResult UpdateBuku(int id, [FromBody] Peminjaman peminjaman)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.UpdatePeminjaman(id, peminjaman);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message; 
        }
        return Ok(response);
    }

    [HttpDelete("/DeletePeminjaman/{id}")]
    
    public IActionResult DeletePeminjaman(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.DeletePeminjaman(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message; 
        }
        return Ok(response);
    }

    [HttpGet ("/GetPeminjamanByNama/{nama_peminjam}")]

    public IActionResult GetPeminjamanByNama(int nama_peminjam)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetPeminjamanByNama(nama_peminjam);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
    
    [HttpGet ("/GetPeminjamanById/{id}")]
    public IActionResult GetPeminjamanById(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetPeminjamanById(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    // Pengembalian
    [HttpGet("/GetPengembalian")]
    
    public IActionResult GetPengembalian_bukus()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbManager.GetAllPengembalian_bukus();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost("/CreatePengembalian")]
    
    public IActionResult CreatePengembalian_buku([FromBody] Pengembalian_buku Pengembalian_buku)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            _dbManager.CreatePengembalian_buku(Pengembalian_buku);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPut("/UpdatePengembalian/{id}")]
    
    public IActionResult UpdatePengembalian(int id, [FromBody] Pengembalian_buku pengembalian)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            _dbManager.UpdatePengembalian(id, pengembalian);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message; 
        }
        return Ok(response);
    }

    [HttpDelete("/DeletePengambilanById/{id}")]
    
    public IActionResult DeletePengembalian_buku(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            _dbManager.DeletePengembalian_buku(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet ("/GetPengembalianByNama/{nama_peminjam}")]

    public IActionResult GetPengembaliannByNama(int nama_peminjam)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetPengembalianByNama(nama_peminjam);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
    
    [HttpGet ("/GetPengembalianById/{id}")]

    public IActionResult GetPengembaliannById(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetPengembalianById(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("/Pengembalian.length/{nama_peminjam}")]
    
    public IActionResult GetLengthPengembalian(int nama_peminjam)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbManager.GetLengthPengembalian    (nama_peminjam);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("/GetPengguna")]
    public IActionResult GetPengguna()
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetAllPengguna();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

}