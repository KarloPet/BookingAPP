import React, { useState } from 'react';
import { useLocation, useNavigate } from "react-router-dom";
import { Container, Form, Button, Row, Col } from 'react-bootstrap';
import CjenikService from '../../services/CjenikService';
import { RoutesNames } from '../../constants';

function CjenikDodaj() {
    const location = useLocation();
    const navigate = useNavigate();
    const { id, datum, cijena: pocetnaCijena } = location.state;
    const [novaCijena, setNovaCijena] = useState(pocetnaCijena || '');

    const handleInputChange = (e) => {
        setNovaCijena(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const odgovor = await CjenikService.promjeniCijenu(id, { datum, cijena: novaCijena });
            if (odgovor.ok) {
                navigate(RoutesNames.CJENIK); 
                alert("Cijena uspijesno promjenjana");
            } else {
                alert(odgovor.poruka || 'Došlo je do greške pri ažuriranju cijene.');
            }
        } catch (error) {
            console.error('Greška pri promjeni cijene:', error);
            alert('Došlo je do greške prilikom ažuriranja cijene.');
        }
    };

    return (
        <Container>
            <Row className="justify-content-md-center">
                <Col md={6}>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group className="mb-3" controlId="formaCijena">
                            <Form.Label><strong>Cijena za datum {new Date(datum).toLocaleDateString('hr-HR')}</strong></Form.Label>
                            <Form.Control
                                type="number"
                                value={novaCijena}
                                onChange={handleInputChange}
                                placeholder="Unesite novu cijenu"
                            />
                        </Form.Group>
                        <Button variant="primary" type="submit" className="mb-2">
                            Promjeni Cijenu
                        </Button>
                        <Button variant="danger" onClick={() => navigate(RoutesNames.CJENIK)}>
                            Odustani
                        </Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
}

export default CjenikDodaj;
