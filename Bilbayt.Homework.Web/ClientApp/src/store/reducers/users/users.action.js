import { USER_LOGOUT, SET_USER_INFO } from "./users.types";

export const logout = () => (dispatch) =>
  dispatch({
    type: USER_LOGOUT,
  });

export const setUserInfo = (profile) => (dispatch) =>
  dispatch({
    type: SET_USER_INFO,
    payload: profile,
  });
