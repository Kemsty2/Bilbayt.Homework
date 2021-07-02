import axios from "axios";

import { BASE_URL } from "../configs/constants";
import checkTokenExpirationOnRequest from "../middlewares/checkTokenExpirationOnRequest";

API.interceptors.response.use(checkTokenExpirationOnRequest);

const API = axios.create({
  baseURL: BASE_URL,
});

export default API;
