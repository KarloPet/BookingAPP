import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../constants';

import './NavBar.css';

function NavBar() {
    const navigate = useNavigate();

    return (
        <Navbar expand="lg" className="bg-body-tertiary">
            <Container>
                <Navbar.Brand 
                    className='linkPocetna'
                    onClick={() => navigate(RoutesNames.HOME)}>
                    <img
                        src="../images/logo.png" // Postavite putanju do vaše slike
                        alt="Apartments Peterfaj" // Alternativni tekst za sliku
                        className="d-inline-block align-top logo-image" // Dodatne klase ako su potrebne
                    />
                    <p className='naslov'>Apartments Peterfaj</p>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <Nav.Link 
                            className='link'
                            onClick={() => navigate(RoutesNames.GALLERY)}>
                            <p className='stavke'>Galerija</p>
                        </Nav.Link>
                        <Nav.Link 
                            className='link'
                            href="#action/3.2">
                            <p className='stavke'>Cjenik</p>
                        </Nav.Link>
                        <Nav.Link 
                            className='link'
                            onClick={() => navigate(RoutesNames.INFORMATIONS)}>
                            <p className='stavke'>Informacije</p>
                        </Nav.Link>
                        <Nav.Link 
                            className='link'
                            onClick={() => navigate(RoutesNames.ZANIMLJIVOSTI)}>
                            <p className='stavke'>Zanimljivosti</p>
                        </Nav.Link>
                    </Nav>
                </Navbar.Collapse>
                <Navbar.Collapse className="justify-content-end">
                    <Nav.Link target="_blank">Prijava</Nav.Link>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavBar;
