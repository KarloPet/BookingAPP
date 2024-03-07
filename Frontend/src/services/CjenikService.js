import { httpService } from "./httpService";

async function obrisiCjenu(id){
    try {
        const res = await httpService.delete(`/Cjenik/${id}`);
        return { ok: true, poruka: res.data };
    } catch (e) {
        console.log(e);
        return { ok: false, poruka: e.message };
    }
}

export default {
    obrisiCjenu,
};
