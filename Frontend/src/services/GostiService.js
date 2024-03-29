import { App } from "../constants"
import { httpService } from "./httpService";

async function getGosti(){
    return await httpService.get('/Gost')
    .then((res)=>{
        if(App.DEV) console.table(res.data);

        return res;
    }).catch((e)=>{
        console.log(e);
    });
}



export default{
    getGosti
};