import React, { useState, useEffect } from 'react';
import './Pengguna.css';
import axios from 'axios';
import DataTable from 'react-data-table-component';
import "bootstrap/dist/css/bootstrap.min.css";
import { Link } from "react-router-dom"

function Pengguna () {

    //define state
    const [datapengguna, setDatapengguna] = useState([]);

    //useEffect hook
    useEffect(() => {
        //panggil method "fetchData"
        fectData();
    }, []);

    //function "fetchData"
    const fectData = async () => {
        //fetching
        const response = await
    axios.get('https://localhost:7245/GetPengguna');
        //get response data
        const data = await response.data;
        //assign response data to state "datapengguna"
        setDatapengguna(data);
        console.log(data);
    }

    const columns = [
        {
            name: 'ID',
            selector: row => row.id,
            sortable:true
        },
        {
            name: 'Nama',
            selector: row => row.nama,
            sortable:true
        },
        {
            name: 'Alamat',
            selector: row => row.alamat,
            sortable:true
        },
        {
            name: 'Pass',
            selector: row => row.pass,
            sortable:true
        },
    ];

    return (
        <div className="card">
            <div className="container">
                <div className="Titel">
                    Data Pengguna
                </div>
                <div className="conten">
                    <h2>Data Pengguna</h2>
                    <DataTable
                        columns={columns}
                        data={datapengguna.data}
                        pagination
                    />
                </div>
            </div>
        </div>
    );
}

export default Pengguna;