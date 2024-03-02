import axios from "axios";

export const httpService = axios.create({
    baseURL: 'https://karlopet-001-site1.ktempurl.com/api/v1',
    headers:{
        'Content-Type': 'application/json'
    }
});