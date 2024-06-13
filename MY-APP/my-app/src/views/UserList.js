import React, { Component } from 'react';
import '../component/profile/Profile';
import DataUser from '../controllers/UserController'
import DataOwner from '../controllers/OwnerController';

class UserList extends Component {
    render() {
        return (
            <div className="card">
                <div className="container">
                    <div className="Titel">
                        UserList
                    </div>
                    <div className="conten">
                        <h2>Data Pengguna</h2>
                        <DataOwner/>
                        <hr/>
                        <DataUser/>
                    </div>
                </div>
            </div>
        );
    }
}

export default UserList;