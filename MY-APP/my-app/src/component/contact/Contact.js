import React, { Component } from 'react';
import './Contact.css';

class Contact extends Component {
    render() {
        return (
            <div className='card'>
                <div className='container'>
                    <div className='Titel'>
                        Contact
                    </div>
                    <div className='conten'>
                        <b>Developer :</b> Rafid Affan Danar <br />
                        <b>Email :</b> rafiddanar1@gmail.com <br />
                        <b>Referensi :</b> https://www.akscoding.com/ <br />
                    </div>
                </div>
            </div>
        );
    }
}

export default Contact;