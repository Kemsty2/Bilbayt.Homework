import axios from "axios";
import { BASE_URL } from "../configs/constants";

const API = axios.create({
  baseURL: BASE_URL,
});

export default API;