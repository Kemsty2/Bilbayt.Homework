import { USER_LOGOUT, SET_USER_INFO } from "./users.types";

const INITIAL_STATE = {
  profile: {},
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
    default:
      return state;
  }
};
