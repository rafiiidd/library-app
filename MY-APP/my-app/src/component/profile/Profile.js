import React, { Component } from 'react';
import './Profile.css';

class Profile extends Component {
    render() {
        return (
            <div className='card'>
                <div className='container'>
                    <div className='Titel'>
                        Profile
                    </div>
                    <div className='conten'>
                        <b>Belajar React JS</b> <br />
                        Membuat Website Sederhana dengan React JS
                    </div>
                    <div className='conten'>
                        <h1>Biodata</h1>
                        <tr>
                            <td>Nama</td>
                            <td> : Rafid Affan Danar</td>
                        </tr>
                        <tr>
                            <td>Alamat</td>
                            <td> : Tridaya Nuansa Indah BLOK EA 9 No. 25</td>
                        </tr>
                        <tr>
                            <td>Email</td>
                            <td> : rafiddanar1@gmail.com</td>
                        </tr>
                        <tr>
                            <td>Institusi Pendidikan Terakhir</td>
                            <td> : SMK Telekomunikasi Telesandi Bekasi</td>
                        </tr>
                        <tr>
                            <td>Cita-Cita</td>
                            <td> : Konten Kreator, Programmer</td>
                        </tr>
                    </div>
                </div>
            </div>
        );
    }
}

export default Profile;