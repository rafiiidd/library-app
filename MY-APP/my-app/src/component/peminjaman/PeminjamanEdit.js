import './Peminjaman.css';
import axios from 'axios';
import React from 'react';
import { useParams } from 'react-router-dom';

function PeminjamanEdit() {
    const { id } = useParams();

    //define state
    const [formValue, setformValue] = React.useState({
        id: '',
        nama_peminjam: '',
        judul_buku_pinjaman: '',
        waktu_peminjaman: '',
        durasi_peminjaman: ''
    });

    //useEffect hook
    React.useEffect(() => {
        //panggil method "fetchData"
        fectData();
    }, []);

    //function "fetchData"
    const fectData = async () => {
    //fetching
    const response = await
    axios.get('https://localhost:7245/GetPeminjamanById/'+id);
    //get response data
    const data = await response.data.data[0];
    //assign response data to state "formValue"
    setformValue(data); 
    console.log(data);
}

    const handleChange = (event) => {
        setformValue({
        ...formValue,
        [event.target.name]: event.target.value
        });
    }
    
    const handleSubmit = async(event) => {
        event.preventDefault();
    // store the states in the form data
    const FormDataInput = new FormData();
    FormDataInput.append("id", formValue.id)
    FormDataInput.append("nama_peminjam", formValue.nama_peminjam)
    FormDataInput.append("judul_buku_pinjaman", formValue.judul_buku_pinjaman)
    FormDataInput.append("waktu_peminjaman", formValue.waktu_peminjaman)
    FormDataInput.append("durasi_peminjaman", formValue.durasi_peminjaman)
    alert('Data berhasil diubah')
    try {
        // make axios post request
        const response = await axios({
        method: "put",
        url: 'https://localhost:7245/UpdatePeminjaman/'+id,
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
                    Edit Data Peminjaman {id}
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
                        name="waktu_peminjaman"
                        placeholder="enter a Durasi"
                        value={formValue.waktu_peminjaman}
                        onChange={handleChange}
                    /><br/><br/>
                    <input
                        type="text"
                        name="durasi_peminjaman"
                        placeholder="enter a Durasi"
                        value={formValue.durasi_peminjaman}
                        onChange={handleChange}
                    /><br/><br/>
            <button type='submit' className='btn btn-primary'> Simpan </button>
            </form>
            </div>
        </div>
    </div>
    );
}

export default PeminjamanEdit;