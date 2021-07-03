import jwtDecode from "jwt-decode";

import { setAuthToken } from "../utils/";

const checkTokenExpirationOnRequest = function (config) {
  const userString =
    JSON.parse(localStorage.getItem("persist:root")) &&
    JSON.parse(localStorage.getItem("persist:root"))["users"];

  if (userString) {
    const token = JSON.parse(userString).token;

    if (token) {
      if (jwtDecode(token).exp < Date.now() / 1000) {
        localStorage.clear();
        setAuthToken(null);
        window.location = "/login";
      }
    }
  }
  // Do something before request is sent
  return config;
};

export default checkTokenExpirationOnRequest;
