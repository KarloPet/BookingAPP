import React from 'react';
import { Route, Routes } from "react-router-dom";
import { AuthProvider } from './AuthContext'; // Ako AuthContext nije u istom direktoriju, prilagodite putanju
import NavBar from "./components/NavBar";
import Pocetna from "./pages/Pocetna";
import Gallery from "./pages/Gallery";
import Informations from "./pages/Informations";
import Zanimljivosti from "./pages/Zanimljivosti";
import Gosti from "./pages/Gosti";
import Cjenik from "./pages/Cjenik/Cjenik";
import CjenikDodaj from"./pages/Cjenik/CjenikDodaj";
import CjenikDodajSve from "./pages/Cjenik/CjenikDodajSve";
import Login from "./pages/RegLog/Login";
import { RoutesNames } from "./constants";

import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

function App() {
  return (
    <AuthProvider> {/* Ovo obavija sve komponente unutar AuthProvider-a */}
      <>
        <NavBar />
        <Routes>
          <>
            <Route path={RoutesNames.HOME} element={<Pocetna />} />
            <Route path={RoutesNames.GALLERY} element={<Gallery />} />
            <Route path={RoutesNames.INFORMATIONS} element={<Informations />} />
            <Route path={RoutesNames.ZANIMLJIVOSTI} element={<Zanimljivosti />} />
            <Route path={RoutesNames.GOSTI} element={<Gosti />} />
            <Route path={RoutesNames.CJENIK} element={<Cjenik />} />
            <Route path={RoutesNames.CJENIKDODAJ} element={<CjenikDodaj />} />
            <Route path={RoutesNames.CJENIKDODAJSVE} element={<CjenikDodajSve />} />
            <Route path={RoutesNames.LOGIN} element={<Login />} />
          </>
        </Routes>
      </>
    </AuthProvider>
  );
}

export default App;
