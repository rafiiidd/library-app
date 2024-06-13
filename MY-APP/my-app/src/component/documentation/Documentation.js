import React, { Component } from 'react';
import './Documentation.css';
import docImg from './Documentation.jpg';

class Documentation extends Component {
    render() {
        return (
            <div className='card'>
                <div className='container'>
                    <div className='Titel'>
                        Documentation 
                    </div>
                    <div className='contenz'>
                        <img src={docImg} className='gambar'></img>
                    </div>
                </div>
            </div>
        );
    }
}

export default Documentation;