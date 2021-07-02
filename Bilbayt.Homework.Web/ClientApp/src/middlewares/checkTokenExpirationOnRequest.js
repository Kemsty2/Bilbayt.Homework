import jwtDecode from "jwt-decode";

import { setAuthToken } from "../utils/";

const checkTokenExpirationOnRequest = function (config) {
  const userString =
    JSON.parse(localStorage.getItem("persist:root")) &&
    JSON.parse(localStorage.getItem("persist:root"))["users"];

  if (userString) {
    const token = JSON.parse(userString).token;

    if (token && jwtDecode(token).exp < Date.now() / 1000) {
      localStorage.clear();
      setAuthToken(null);
      window.location = "/";
    }
  }
  // Do something before request is sent
  return config;
};

export default checkTokenExpirationOnRequest;
