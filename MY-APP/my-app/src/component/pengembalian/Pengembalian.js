import React, { useState, useEffect } from 'react';
import './Pengembalian.css';
import axios from 'axios';
import DataTable from 'react-data-table-component';
import "bootstrap/dist/css/bootstrap.min.css";
import { Link } from "react-router-dom"

function DataPengembalian () {

    //define state
    const [datapengembalian, setDatapengembalian] = useState([]);

    //useEffect hook
    useEffect(() => {
        //panggil method "fetchData"
        fectData();
    }, []);

    //function "fetchData"
    const fectData = async () => {
        //fetching
        const response = await
    axios.get('https://localhost:7245/GetPengembalian');
        //get response data
        const data = await response.data;
        //assign response data to state "datapengembalian"
        setDatapengembalian(data);
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
            name: 'Waktu Pengembalian',
            selector: row => row.waktu_pengembalian,
            sortable:true
        },
        {
            name: 'Denda',
            selector: row => row.denda,
            sortable:true
        },
        {
            name: 'Ubah',
            selector: row => <Link to={"/datapengembalian_edit/"+row.id} className='btn btn-primary'>Edit</Link>,
            sortable:true
        },
        {
            name: 'Hapus',
            selector: row => <Link to={"/datapengembalian_delete/"+row.id} className='btn btn-danger'>Delete</Link>,
            sortable:true
        },
    ];

    return (
        <div className="card">
            <div className="container">
                <div className="Titel">
                    Data Pengembalian
                </div>
                <div className="conten">
                    <h2>Data Pengembalian</h2>
                    <Link to="/datapengembalian_add" className='btn btn-primary'>+ Data Pengembalian</Link>
                    <DataTable
                        columns={columns}
                        data={datapengembalian.data}
                        pagination
                    />
                </div>
            </div>
        </div>
    );
}

export default DataPengembalian;