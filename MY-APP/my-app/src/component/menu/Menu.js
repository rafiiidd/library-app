import React, { Component } from 'react';
import { Link } from "react-router-dom";
import './Menu.css';

class Menu extends Component {
    render() {
        return (
            <div>
                    <header>
      <nav class="navbar navbar-expand-md text-white fixed-top bg-danger">
        <div class="container-fluid d-flex justify-content-evenly">
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="container">
            <a class="navbar-brand text-white fw-bold" href="/">HANABI<span className='text-primary'>LIBRARY</span></a>
          </div>
          <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
            <ul class="navbar-nav mr-auto">
              <li class="nav-item">
                <Link to="/" class="nav-link text-white fw-bold buku">BUKU</Link>
              </li>
              <li class="nav-item">
                <Link to="/datapeminjaman" class="nav-link text-white fw-bold peminjaman">PEMINJAMAN</Link>
              </li>
              <li class="nav-item">
                <Link to="/datapengembalian" class="nav-link text-white fw-bold pengembalian">PENGEMBALIAN</Link>
              </li>
              <li class="nav-item">
                <Link to="/pengguna" class="nav-link text-white fw-bold pengguna">PENGGUNA</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </header>
            </div>
        );
    }
}

export default Menu;