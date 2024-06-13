import React, { useState, useEffect } from 'react';
import './Peminjaman.css';
import axios from 'axios';
import DataTable from 'react-data-table-component';
import "bootstrap/dist/css/bootstrap.min.css";
import { Link } from "react-router-dom"

function DataPeminjaman () {

    //define state
    const [datapeminjaman, setDataPeminjaman] = useState([]);

    //useEffect hook
    useEffect(() => {
        //panggil method "fetchData"
        fectData();
    }, []);

    //function "fetchData"
    const fectData = async () => {
        //fetching
        const response = await
    axios.get('https://localhost:7245/GetPeminjaman');
        //get response data
        const data = await response.data;
        //assign response data to state "datapeminjaman"
        setDataPeminjaman(data);
        console.log(data);
    }

    const columns = [
        {
            name: 'ID Peminjam',
            selector: row => row.id,
            sortable:true
        },
        {
            name: 'Nama Peminjam',
            selector: row => row.nama_peminjam,
            sortable:true
        },
        {
            name: 'Judul Buku',
            selector: row => row.judul_buku_pinjaman,
            sortable:true
        },
        {
            name: 'Waktu Peminjaman',
            selector: row => row.waktu_peminjaman,
            sortable:true
        },
        {
            name: 'Durasi Peminjaman',
            selector: row => row.durasi_peminjaman,
            sortable:true
        },
        {
            name: 'Ubah',
            selector: row => <Link to={"/datapeminjaman_edit/"+row.id} className='btn btn-primary'>Edit</Link>,
            sortable:true
        },
        {
            name: 'Hapus',
            selector: row => <Link to={"/datapeminjaman_delete/"+row.id} className='btn btn-danger'>Delete</Link>,
            sortable:true
        },
    ];

    return (
        <div className="card">
            <div className="container">
                <div className="Titel">
                    Data Peminjaman
                </div>
                <div className="conten">
                    <h2>Data Peminjaman</h2>
                    <Link to="/datapeminjaman_add" className='btn btn-primary'>+ Data Peminjam</Link>
                    <DataTable
                        columns={columns}
                        data={datapeminjaman.data}
                        pagination
                    />
                </div>
            </div>
        </div>
    );
}

export default DataPeminjaman;