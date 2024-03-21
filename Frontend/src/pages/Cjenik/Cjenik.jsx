import React, { useState } from 'react';
import axios from 'axios';
import { Container, Table, Button } from 'react-bootstrap';
import { FaEdit, FaTrash } from "react-icons/fa";
import CjenikService from '../../services/CjenikService';
import "./Cjenik.css";
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../../constants';
import { useAuth } from '../../AuthContext';

function Cjenik() {
    const { currentUser } = useAuth();
    const navigate = useNavigate();
    const [cjenik, setCjenik] = useState([]);
    const [odabranaGodina, setOdabranaGodina] = useState(new Date().getFullYear());
    const godine = Array.from({ length: 5 }, (_, index) => 2023 + index);

    const fetchCjenikByMonthAndYear = async (year, month) => {
        try {
            const response = await axios.get(`https://karlopet-001-site1.ktempurl.com/api/v1/Cjenik/ByMonth?year=${year}&month=${month}`);
            setCjenik(response.data.sort((a, b) => new Date(a.datum) - new Date(b.datum)));
        } catch (error) {
            console.error('Error fetching cjenik:', error);
        }
    };

    const months = ["Siječanj", "Veljača", "Ožujak", "Travanj", "Svibanj", "Lipanj", "Srpanj", "Kolovoz", "Rujan", "Listopad", "Studeni", "Prosinac"];

    return (
        <Container>
            <h2 className='naslov2'>CJENIK</h2>
            {currentUser && currentUser.permissionLevel === 'admin' && (
                <Button className='btn btn-success dugmeDodaj' onClick={() => navigate(RoutesNames.CJENIKDODAJSVE)}>
                    DODAJ NOVU CIJENU
                </Button>
            )}

            <h2 className='naslov3'>Dohvati cjenik po godini i mjesecu</h2>

            <div className="year-selection button-container" style={{ marginBottom: '20px' }}>
                {godine.map((godina) => (
                    <Button key={godina} variant={odabranaGodina === godina ? "secondary" : "outline-secondary"} onClick={() => { setOdabranaGodina(godina); setOdabraniMjesec(null); }}>
                        {godina}
                    </Button>
                ))}
            </div>
            <div className="month-selection button-container" style={{ marginBottom: '20px' }}>
                {months.map((month, index) => (
                    <Button key={index} variant="primary" onClick={() => fetchCjenikByMonthAndYear(odabranaGodina, index + 1)} style={{ margin: '5px' }}>
                        {month}
                    </Button>
                ))}
            </div>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th style={{ width: currentUser && currentUser.permissionLevel === 'admin' ? '40%' : '50%' }}>Datum</th>
                        <th style={{ width: currentUser && currentUser.permissionLevel === 'admin' ? '40%' : '50%' }}>Cijena</th>
                        {currentUser && currentUser.permissionLevel === 'admin' && (
                            <th style={{ width: '20%' }}>Akcija</th>
                        )}
                    </tr>
                </thead>
                <tbody>
                    {cjenik.map((item) => (
                        <tr key={item.id}>
                            <td>{new Date(item.datum).toLocaleDateString('hr-HR')}</td>
                            <td>{item.cijena} kn</td>
                            {currentUser && currentUser.permissionLevel === 'admin' && (
                                <td>
                                    <Button variant="primary" onClick={() => navigate(RoutesNames.CJENIKDODAJ, { state: { id: item.id, datum: item.datum, cijena: item.cijena } })}>
                                        <FaEdit size={20} />
                                    </Button>
                                    &nbsp;&nbsp;&nbsp;
                                    <Button variant="danger" onClick={() => CjenikService.obrisiCjenu(item.id).then(() => fetchCjenikByMonthAndYear(odabranaGodina, new Date(item.datum).getMonth() + 1))}>
                                        <FaTrash size={20} />
                                    </Button>
                                </td>
                            )}
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default Cjenik;
