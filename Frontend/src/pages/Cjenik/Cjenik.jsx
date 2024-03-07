import React, { useState } from 'react';
import axios from 'axios';
import { Container, Table, Button, Modal, Form } from 'react-bootstrap';
import { FaEdit, FaTrash } from "react-icons/fa";
import CjenikService from '../../services/CjenikService';
import "./Cjenik.css";
import StaticExample from './CjenikDodaj';

function Cjenik() {
    const [cjenik, setCjenik] = useState([]);
    const [showModal, setShowModal] = useState(false);

    const handleCloseModal = () => setShowModal(false);
    const handleShowModal = () => setShowModal(true);

    const fetchCjenikByMonth = async (month) => {
        try {
            const response = await axios.get(`https://karlopet-001-site1.ktempurl.com/api/v1/Cjenik/ByMonth?year=2023&month=${month}`);
            setCjenik(response.data);
        } catch (error) {
            console.error('Error fetching cjenik:', error);
        }
    };

    const obrisiCjenu = async (id) => {
        const odgovor = await CjenikService.obrisiCjenu(id);
        if (odgovor && odgovor.ok) {
            setCjenik(currentCjenik => currentCjenik.filter(cijena => cijena.id !== id));
        }
    }
    const months = ["Siječanj", "Veljača", "Ožujak", "Travanj", "Svibanj", "Lipanj", "Srpanj", "Kolovoz", "Rujan", "Listopad", "Studeni", "Prosinac"];

    return (
        <Container>
            <h2>Dohvati cjenik po mjesecu</h2>
            <div className="dugme">
                {months.map((month, index) => (
                    <button className="btn btn-primary" key={index} onClick={() => fetchCjenikByMonth(index + 1)}>
                        {month}
                    </button>
                ))}
            </div>
            <Table striped bordered hover responsive>
            <thead>
    <tr>
        <th>Datum</th>
        <th>Cijena</th>
        <th class="actions-column">Akcija</th>
    </tr>
</thead>
<tbody>
    {cjenik.map((item) => (
        <tr key={item.id}>
            <td>{new Date(item.datum).toLocaleDateString('hr-HR')}</td>
            <td>{item.cijena} kn</td>
            <td class="actions-column">
            <Button 
            variant="primary" 
            //onClick={handleShowModal}
            >
                <FaEdit size={20} />
            </Button>
            {showModal && <StaticExample handleClose={handleCloseModal} />}
                &nbsp;&nbsp;&nbsp;
                <Button 
                variant="danger"
                onClick={()=>obrisiCjenu(item.id)}
                >
                    <FaTrash size={20} />
                </Button>
            </td>
        </tr>
    ))}
</tbody>
            </Table>
          
        </Container>
    );
}

export default Cjenik;
