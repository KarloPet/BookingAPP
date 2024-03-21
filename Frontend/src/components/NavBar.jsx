import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../constants';
import { useAuth } from '../AuthContext';


import './NavBar.css';

function NavBar() {
    const navigate = useNavigate();

    const { currentUser, logout } = useAuth(); // Dodajte ovdje currentUser za provjeru je li korisnik prijavljen

    const handleLogout = () => {
        logout(); // Poziva logout funkciju iz AuthContext
        navigate(RoutesNames.HOME);
    }

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
                            onClick={() => navigate(RoutesNames.CJENIK)}>
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
                        {currentUser && currentUser.permissionLevel === 'moderator' && (
                        <Nav.Link 
                            className='link'
                            onClick={() => navigate(RoutesNames.GOSTI)}>
                            <p className='stavke'>Gosti</p>
                        </Nav.Link>
                                            )}

                    </Nav>
                </Navbar.Collapse>
                <Navbar.Collapse className="justify-content-end">
            {currentUser ? (
                // Prikazuje link za odjavu ako je korisnik prijavljen
                <Nav.Link onClick={handleLogout}>
                    Odjava
                </Nav.Link>
            ) : (
                // Prikazuje link za prijavu ako korisnik nije prijavljen
                <Nav.Link onClick={()=>navigate(RoutesNames.LOGIN)}>
                    Prijava
                </Nav.Link>
            )}
        </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavBar;
