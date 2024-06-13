import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Menu from './component/menu/Menu'
import Buku from './component/buku/Buku' // home
import Profile from './component/profile/Profile'
import Contact from './component/contact/Contact'
import Documentation from './component/documentation/Documentation'
import Pengguna from './component/pengguna/Pengguna'
import UserList from './views/UserList'

import DataPeminjaman from './component/peminjaman/Peminjaman'
import PeminjamanAdd from './component/peminjaman/PeminjamanAdd'
import PeminjamanEdit from './component/peminjaman/PeminjamanEdit'
import PeminjamanDelete from './component/peminjaman/PeminjamanDelete'

import DataPengembalian from './component/pengembalian/Pengembalian'
import DataPengembalianAdd from './component/pengembalian/PengembalianAdd'
import DataPengembalianEdit from './component/pengembalian/PengembalianEdit'
import DataPengembalianDelete from './component/pengembalian/PengembalianDelete'

function App() {
  return (
  <Router basepath="./my-app">
    <div className="app-header">
      <Menu />
    </div>
    <div className="app-content">
      <Routes>
        <Route path="/" element={<Buku />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/documentation" element={<Documentation />} />
        <Route path="/pengguna" element={<Pengguna />} />
        <Route path="/userlist" element={<UserList />} />

        <Route path="/datapeminjaman" element={<DataPeminjaman />} />
        <Route path="/datapeminjaman_add" element={<PeminjamanAdd />} />
        <Route path="/datapeminjaman_edit/:id" element={<PeminjamanEdit />} />
        <Route path="/datapeminjaman_delete/:id" element={<PeminjamanDelete />} />

        <Route path="/datapengembalian" element={<DataPengembalian />} />
        <Route path="/datapengembalian_add" element={<DataPengembalianAdd />} />
        <Route path="/datapengembalian_edit/:id" element={<DataPengembalianEdit />} />
        <Route path="/datapengembalian_delete/:id" element={<DataPengembalianDelete />} />
      </Routes>
    </div>
  </Router>
  );
}

export default App;