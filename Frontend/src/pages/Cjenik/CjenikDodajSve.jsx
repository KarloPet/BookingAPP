import React, { useState } from 'react';
import { Container, Form, Button, Row, Col } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom'; 
import CjenikService from '../../services/CjenikService';
import { RoutesNames } from '../../constants';



function DodajSve() {
  const [datum, setDatum] = useState({ mjesec: '', dan: '', godina: '' });
  const [cijena, setCijena] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => { 
    e.preventDefault();

    const odabraniDatum = new Date(datum.godina, datum.mjesec - 1, datum.dan, 12);
    const formatiraniDatum = odabraniDatum.toISOString();
    console.log({ datum: formatiraniDatum, cijena });


    try {
      const odgovor = await CjenikService.dodajCijenu({ datum: formatiraniDatum, cijena: parseFloat(cijena) });
      if (odgovor.ok) {
          navigate(RoutesNames.CJENIK);
          alert("Cijena uspiješno promijenjena");
      } else {
          const errorResponse = await odgovor.json();
          alert(errorResponse.message || 'Došlo je do greške pri ažuriranju cijene.');
      }
  } catch (error) {
      console.error('Greška pri promjeni cijene:', error);
      alert('Datum koji pokušavate kreirati vec postoji');
  }

};

  const trenutnaGodina = new Date().getFullYear();
  const godine = Array.from({ length: 5 }, (val, index) => trenutnaGodina - 1 + index);
  return (
    <Container>
      <Row className="justify-content-md-center">
        <Col>
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3">
              <Form.Label><strong>Unesi novu cijenu:</strong></Form.Label>
              <Row>
                <Col>
                  <Form.Control as="select" value={datum.mjesec} onChange={e => setDatum({ ...datum, mjesec: e.target.value })}>
                    <option value="">Mjesec</option>
                    {Array.from(new Array(12), (val, index) => (
                      <option key={index} value={index + 1}>{index + 1}</option>
                    ))}
                  </Form.Control>
                </Col>
                <Col>
                  <Form.Control as="select" value={datum.dan} onChange={e => setDatum({ ...datum, dan: e.target.value })}>
                    <option value="">Dan</option>
                    {Array.from(new Array(31), (val, index) => (
                      <option key={index} value={index + 1}>{index + 1}</option>
                    ))}
                  </Form.Control>
                </Col>
                <Col>
                  <Form.Control as="select" value={datum.godina} onChange={e => setDatum({ ...datum, godina: e.target.value })}>
                    <option value="">Godina</option>
                    {godine.map(godina => (
                      <option key={godina} value={godina}>{godina}</option>
                    ))}
                  </Form.Control>
                </Col>
              </Row>
              <Form.Control
                type="number"
                value={cijena}
                onChange={e => setCijena(e.target.value)}
                placeholder="Cijena"
                className="mt-3"
              />
            </Form.Group>
            <Button variant="primary" type="submit" className="mb-2">
              Promjeni Cijenu
            </Button>
            <Button variant="danger" onClick={() => navigate('/cjenik')}>
              Odustani
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default DodajSve;
