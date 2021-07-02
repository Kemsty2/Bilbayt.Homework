import axios from "axios";

import { BASE_URL } from "../configs/constants";
import checkTokenExpirationOnRequest from "../middlewares/checkTokenExpirationOnRequest";

const API = axios.create({
  baseURL: BASE_URL,
});
API.interceptors.request.use(checkTokenExpirationOnRequest);

export default API;
