import { USER_LOGOUT, SET_USER_INFO, SET_TOKEN_USER } from "./users.types";

const INITIAL_STATE = {
  profile: {},
  token: "",
};

export default (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case USER_LOGOUT:
      return {
        ...state,
      };
    case SET_USER_INFO:
      return {
        ...state,
        profile: action.payload,
      };
    case SET_TOKEN_USER:
      return {
        ...state,
        token: action.payload,
        loading: false,
      };
    default:
      return state;
  }
};
