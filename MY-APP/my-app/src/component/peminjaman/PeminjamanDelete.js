import './Peminjaman.css';
import axios from 'axios';
import React from 'react';
import { useParams } from 'react-router-dom';

function PeminjamanDelete() {
    const { id } = useParams();

    // Define state
    const [formValue, setFormValue] = React.useState({
        id: '',
        nama_peminjam: '',
        judul_buku_pinjaman: '',
        waktu_peminjaman: '',
        durasi_peminjaman: ''
    });

    // UseEffect hook
    React.useEffect(() => {
        // Call method "fetchData"
        fetchData();
    }, []);

    // Function "fetchData"
    const fetchData = async () => {
        try {
            // Fetching data
            const response = await axios.get('https://localhost:7245/GetPeminjamanById/'+id);
            // Get response data
            const data = response.data.data[0];
            // Assign response data to state "formValue"
            setFormValue(data);
            console.log(data);
        } catch (error) {
            console.error('Error fetching data:', error);
            alert('Data tidak ditemukan atau sudah dihapus!');
        }
    }

    const handleChange = (event) => {
        setFormValue({
            ...formValue,
            [event.target.name]: event.target.value
        });
    }

    const handleSubmit = async (event) => {
        event.preventDefault();
        // store the states in the form data
        const FormDataInput = new FormData();
        FormDataInput.append("id_peminjam", formValue.id_peminjam)
        FormDataInput.append("nama_peminjaman", formValue.nama_peminjaman)
        FormDataInput.append("judul_buku", formValue.judul_buku)
        FormDataInput.append("durasi_peminjaman", formValue.durasi_peminjaman)
        FormDataInput.append("denda", formValue.denda)
        alert('Data berhasil dihapus')
        try {
            // make axios post request
            const response = await axios({
                method: "delete",
                url: 'https://localhost:7245/DeletePeminjaman/'+id,
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
                    Hapus Data Peminjaman {}
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
                    <button type="submit" className='btn btn-danger'>Hapus</button>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default PeminjamanDelete;