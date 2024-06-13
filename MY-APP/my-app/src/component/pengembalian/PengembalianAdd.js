import './Pengembalian.css';
import axios from 'axios';
import React from 'react';

function PengembalianAdd() {

    const [formValue, setformValue] = React.useState({
        id: '',
        nama_peminjam: '',
        judul_buku_pinjaman: '',
        waktu_pengembalian: '',
        denda: ''

        });

    const handleChange = (event) => {
        setformValue({
            ...formValue,
            [event.target.name]: event.target.value
        });
    }

    const handleSubmit = async() => {
        // store the states in the form data
        const FormDataInput = new FormData();
        FormDataInput.append("id", formValue.id)
        FormDataInput.append("nama_peminjam", formValue.nama_peminjam)
        FormDataInput.append("judul_buku_pinjaman", formValue.judul_buku_pinjaman)
        FormDataInput.append("waktu_pengembalian", formValue.waktu_pengembalian)
        FormDataInput.append("denda", formValue.denda)
        alert('Data berhasil disimpan')
        try {
            // make axios post request
            const response = await axios({
            method: "post",
            url: 'https://localhost:7245/CreatePengembalian',
            data: FormDataInput,
            headers: { "Content-Type": "application/json" },
        });
            console.log(response)
        } catch(error) {
        console.log(error)
        alert(error)
        }
    }

    return (
        <div className="card">
            <div className="container">
                <div className="Titel">
                    Tambah Data Pengembalian
                </div>
                <div className="conten">
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="id"
                        placeholder="enter ID"
                        value={formValue.id}
                        onChange={handleChange}
                    /><br/><br/>
                    <input
                        type="text"
                        name="nama_peminjam"
                        placeholder="enter a Nama"
                        value={formValue.nama_peminjam}
                        onChange={handleChange}
                    /><br/><br/>
                    <input
                        type="text"
                        name="judul_buku_pinjaman"
                        placeholder="enter a Judul"
                        value={formValue.judul_buku_pinjaman}
                        onChange={handleChange}
                    /><br/><br/>
                    <input
                        type="text"
                        name="waktu_pengembalian"
                        placeholder="enter a Durasi"
                        value={formValue.waktu_pengembalian}
                        onChange={handleChange}
                    /><br/><br/>
                    <input
                        type="text"
                        name="denda"
                        placeholder="enter a Denda"
                        value={formValue.denda}
                        onChange={handleChange}
                    /><br/><br/>
                    <button type="submit" className='btn btn-primary'> Simpan </button>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default PengembalianAdd;