import { httpService } from "./httpService";
import { App } from "../constants"
import axios from 'axios'

const naziv = 'Cjenik'


async function obrisiCjenu(id) {
  try {
    const res = await httpService.delete(`/Cjenik/${id}`);
    return { ok: true, poruka: res.data };
  } catch (e) {
    console.log(e);
    return { ok: false, poruka: e.message };
  }
}

const promjeniCijenu = async (id, cjenikData) => {
  try {
    const response = await httpService.put(`/Cjenik/${id}`, cjenikData);
    return { ok: true, data: response.data };
  } catch (error) {
    console.error('Greška pri promjeni cijene:', error);
    return { ok: false, poruka: error.response?.data?.poruka || error.message };
  }
};
const dodajCijenu = async (cjenaDatumData) => {
  try {
    const response = await httpService.post(`/Cjenik/`, cjenaDatumData); // Promijenite ovdje "odgovor" u "response"
    return { ok: true, data: response.data };
  } catch (error) {
    console.error('Greška pri dodavanju cijene:', error);
    return { ok: false, poruka: error.response?.data?.poruka || error.message };
  }
}


export default {
  obrisiCjenu,
  promjeniCijenu,
  dodajCijenu
};
