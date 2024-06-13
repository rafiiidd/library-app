import React, { useState, useEffect } from 'react';
import './Buku.css';
import axios from 'axios';
import { Link } from "react-router-dom";

function Buku() {
    // Define state
    const [databuku, setDataBuku] = useState([]);

    // useEffect hook
    useEffect(() => {
        // Call method "fetchData"
        fetchData();
    }, []);

    // Function "fetchData"
    const fetchData = async () => {
        // Fetching
        const response = await axios.get('https://localhost:7245/GetInventori');
        // Get response data
        const data = await response.data.data;
        // Assign response data to state "databuku"
        setDataBuku(data);
        console.log(data);
    };

    return (
        <div className='card-container'>
            <div className='container'>
                <div className='title'>
                    Buku
                </div>
                <div className='content'>
                    <h2>Data Buku HanabiLibrary</h2>
                    <div className='cards'>
                        {databuku.map((buku) => (
                            <div key={buku.id} className='card'>
                                <div className='card-body'>
                                    <h3>ID Buku: {buku.id}</h3>
                                    <p><strong>Judul Buku:</strong> {buku.judul_buku}</p>
                                    <p><strong>Rak Buku:</strong> {buku.rak_buku}</p>
                                    <p><strong>Penerbit Buku:</strong> {buku.penerbit_buku}</p>
                                    <p><strong>Pengarang Buku:</strong> {buku.pengarang_buku}</p>
                                    <p><strong>Tahun Buku:</strong> {buku.tahun_buku}</p>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Buku;
