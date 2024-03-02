import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"

import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css';
import Gallery from "./pages/Gallery"
import Informations from "./pages/Informations"
import Zanimljivosti from "./pages/Zanimljivosti"
import Gosti from "./pages/Gosti"

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />
          <Route path={RoutesNames.GALLERY} element={<Gallery />} />
          <Route path={RoutesNames.INFORMATIONS} element={<Informations />} />
          <Route path={RoutesNames.ZANIMLJIVOSTI} element={<Zanimljivosti />} />
          <Route path={RoutesNames.GOSTI} element={<Gosti />} />


        </>
      </Routes>
    </>
  )
}

export default App
