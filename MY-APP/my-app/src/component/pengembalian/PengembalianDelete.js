import './Pengembalian.css';
import axios from 'axios';
import React from 'react';
import { useParams } from 'react-router-dom';

function PengembalianDelete() {
    const { id } = useParams();

    //define state
    const [formValue, setformValue] = React.useState({
        id_peminjam: '',
        nama_peminjaman: '',
        judul_buku_pinjaman: '',
        waktu_pengembalian: '',
        denda: ''
    });

    //useEffect hook
    React.useEffect(() => {
        //panggil method "fetchData"
        fectData();
    }, []);

    //function "fetchData"
    const fectData = async () => {
        try {
            //fetching
            const response = await
        axios.get('https://localhost:7245/GetPengembalianById/'+id);
            //get response data
            const data = await response.data;
            //assign response data to state "formValue"
            setformValue(data);
            console.log(data);
            } catch(error) {
            console.log(error)
            alert('Data tidak ditemukan atau sudah dihapus!')
            }
        }

        const handleChange = (event) => {
            setformValue({
            ...formValue,
            [event.target.name]: event.target.value
            });
        }

        const handleSubmit = async() => {
            // store the states in the form data
            const FormDataInput = new FormData();
            FormDataInput.append("id_peminjam", formValue.id_peminjam)
            FormDataInput.append("nama_peminjaman", formValue.nama_peminjaman)
            FormDataInput.append("judul_buku_pinjaman", formValue.judul_buku_pinjaman)
            FormDataInput.append("waktu_pengembalian", formValue.waktu_pengembalian)
            FormDataInput.append("denda", formValue.denda)
            alert('Data berhasil dihapus')
            try {
                // make axios post request
                const response = await axios({
                    method: "delete",
                    url: 'https://localhost:7245/DeletePengambilanById/'+id,
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
                        Hapus Data Pengembalian {}
                    </div>
                    <div className="conten">
                    <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="id_peminjam"
                        placeholder="enter ID"
                        value={formValue.id_peminjam}
                        onChange={handleChange}
                    /><br/><br/>
                    <input
                        type="text"
                        name="nama_peminjaman"
                        placeholder="enter a Nama"
                        value={formValue.nama_peminjaman}
                        onChange={handleChange}
                    /><br/><br/>
                <button type="submit" className='btn btn-danger'> Hapus </button>
                </form>
                </div>
            </div>
        </div>
    );
}

export default PengembalianDelete;