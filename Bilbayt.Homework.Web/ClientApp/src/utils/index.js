import { toast } from "react-toastify";

import API from "./API";
import { alertMessages } from "../configs/constants";

export const setAuthToken = (token) => {
  if (token) {
    // Apply to every request
    API.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  } else {
    // Delete auth header
    delete API.defaults.headers.common["Authorization"];
  }
};

export const capitalize = (s) => {
  if (typeof s !== "string") return "";

  return s.charAt(0).toUpperCase() + s.slice(1);
};

export const isDev = () => {
  return !process.env.NODE_ENV || process.env.NODE_ENV === "development";
};

export const displayError = (error) => {
  if (isDev()) {
    console.log(error.response);
  }
  //toast.error(error.response.data.responseException.exceptionMessage);

  if (
    error.response &&
    error.response.data &&
    error.response.data.responseException
  ) {
    toast.error(error.response.data.responseException.exceptionMessage);
  } else {
    if (error.response && error.response.data && error.response.data.errors) {
      toast.error(alertMessages.error400);
    } else {
      toast.error(alertMessages.error500);
    }
  }
};

export const isEmpty = (value) =>
  value === undefined ||
  value === null ||
  (typeof value === "object" && Object.keys(value).length === 0) ||
  (typeof value === "string" && value.trim().length === 0);
