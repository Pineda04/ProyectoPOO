import axios from "axios";

const API_URL = 'https://localhost:7234/api';

const travelApi = axios.create({
    baseURL: API_URL,
    headers: {
        "Content-Type": "application/json"
    },
}); 

export {
    travelApi,
    API_URL
}