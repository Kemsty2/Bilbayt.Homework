import { USER_LOGOUT, SET_USER_INFO, SET_TOKEN_USER } from "./users.types";
import { loginApi, registerApi, getProfileApi } from "./users.api";
import { displayError } from "../../../utils";
import { successStore } from "../messages/messages.action";

export const logout = () => (dispatch) =>
  dispatch({
    type: USER_LOGOUT,
  });

export const setUserInfo = (profile) => (dispatch) =>
  dispatch({
    type: SET_USER_INFO,
    payload: profile,
  });

export const setTokenUser = (token) => (dispatch) =>
  dispatch({
    type: SET_TOKEN_USER,
    payload: token,
  });

export const loginAsync = (data) => (dispatch) => {
  return new Promise((resolve, reject) => {
    loginApi(data)
      .then((token) => {
        dispatch(setTokenUser(token.accessToken));
        dispatch(
          successStore(`Hello, ${token.userName} Welcome to Bilbayt Homework. `)
        );
        resolve();
      })
      .catch((err) => {
        displayError(err);
        reject();
      });
  });
};

export const registerAsync = (data) => (dispatch) => {
  return new Promise((resolve, reject) => {
    registerApi(data)
      .then((user) => {
        dispatch(
          successStore(
            `Hello, ${user.userName} Successful registration, you will receive a welcome email. `
          )
        );
        resolve();
      })
      .catch((err) => {
        displayError(err);
        reject();
      });
  });
};

export const getProfileAsync = () => (dispatch) => {
  return new Promise((resolve, reject) => {
    getProfileApi()
      .then((user) => {
        dispatch(setUserInfo(user));
        resolve();
      })
      .catch((err) => {
        displayError(err);
        reject();
      });
  });
};
