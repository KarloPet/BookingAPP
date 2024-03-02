import { Table } from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import React, { useState, useEffect } from 'react';
import GostiService from '../services/GostiService';

export default function Gosti() {
    const [gosti, setGosti] = useState([]);

    async function dohvatiGoste() {
        try {
            const res = await GostiService.getGosti();
            setGosti(res.data);
        } catch (error) {
            alert(error);
        }
    }

    useEffect(() => {
        dohvatiGoste();
    }, []);

    return (
        <>
            <Container>
                <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Ime</th>
                            <th>Prezime</th>
                        </tr>
                    </thead>
                    <tbody>
                        {gosti.map((gost) => (
                            <tr key={gost.id}>
                                <td>{gost.id}</td>
                                <td>{gost.ime}</td>
                                <td>{gost.prezime}</td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </Container>
        </>
    );
}
