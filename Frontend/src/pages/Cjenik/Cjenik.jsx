import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Container, Button, Modal } from 'react-bootstrap';
import Calendar from 'react-calendar';
import 'react-calendar/dist/Calendar.css';
import { useNavigate } from 'react-router-dom';
import { FaEdit, FaTrash } from "react-icons/fa";
import { useAuth } from '../../AuthContext';
import { RoutesNames } from '../../constants';
//import {CjenikService} from '../../services/CjenikService'

function Cjenik() {
    const { currentUser } = useAuth();
    const navigate = useNavigate();
    const [cjenik, setCjenik] = useState([]);
    const [activeDate, setActiveDate] = useState(new Date());
    const [showModal, setShowModal] = useState(false);
    const [selectedCijena, setSelectedCijena] = useState(null);

    useEffect(() => {
        fetchCjenik(activeDate.getFullYear(), activeDate.getMonth() + 1);
    }, [activeDate]);

    const fetchCjenik = async (year, month) => {
        try {
            const response = await axios.get(`https://karlopet-001-site1.ktempurl.com/api/v1/Cjenik/ByMonth?year=${year}&month=${month}`);
            setCjenik(response.data);
        } catch (error) {
            console.error('Error fetching cjenik:', error);
        }
    };

    const handleDayClick = (value) => {
        const datumString = `${value.getFullYear()}-${(value.getMonth() + 1).toString().padStart(2, '0')}-${value.getDate().toString().padStart(2, '0')}`;
        const foundCijena = cjenik.find(d => d.datum.startsWith(datumString));
        if (foundCijena) {
            setSelectedCijena(foundCijena);
            setShowModal(true);
        }
    };

    const closeModal = () => setShowModal(false);

    const tileContent = ({ date, view }) => {
        if (view === 'month') {
            const datumString = `${date.getFullYear()}-${(date.getMonth() + 1).toString().padStart(2, '0')}-${date.getDate().toString().padStart(2, '0')}`;
            const cijena = cjenik.find(d => d.datum.startsWith(datumString))?.cijena;
            return cijena ? <p>{`${cijena} kn`}</p> : null;
        }
    };

    return (
        <Container>
            {currentUser && currentUser.permissionLevel === 'admin' && (
                <Button className='btn btn-success' onClick={() => navigate(RoutesNames.CJENIKDODAJSVE)}>
                    DODAJ NOVU CIJENU
                </Button>
            )}
            <Calendar
                onChange={setActiveDate}
                value={activeDate}
                onClickDay={handleDayClick}
                tileContent={tileContent}
                locale="hr-HR"
            />

            <Modal show={showModal} onHide={closeModal}>
                <Modal.Header closeButton>
                    <Modal.Title>Uredi Cijenu</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Datum: {selectedCijena ? new Date(selectedCijena.datum).toLocaleDateString() : ''}
                    <br />
                    Cijena: {selectedCijena?.cijena} kn
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={closeModal}>
                        Zatvori
                    </Button>
                    <Button variant="primary" onClick={() => navigate(RoutesNames.CJENIKDODAJ, { state: selectedCijena })}>
                        <FaEdit size={20} /> Uredi
                    </Button>


                    <Button variant="danger" onClick={() => CjenikService.obrisiCjenu(item.id)}>
                                        <FaTrash size={20} />
                                    </Button>




                    {/* <Button variant="danger" onClick={() => {
                        // Ovdje implementirajte logiku brisanja
                        closeModal();
                    }}>
                        <FaTrash size={20} /> Obriši
                    </Button> */}
                </Modal.Footer>
            </Modal>
        </Container>
    );

}

export default Cjenik;
