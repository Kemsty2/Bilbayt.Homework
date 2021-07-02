import { PENDING_STORE, SUCCESS_STORE, FAIL_STORE } from "./messages.types";

export const pendingStore = (message = "") => {
  return {
    type: PENDING_STORE,
    payload: message,
  };
};

export const successStore = (message = "") => {
  return {
    type: SUCCESS_STORE,
    payload: message,
  };
};
export const failStore = (message = "") => {
  return {
    type: FAIL_STORE,
    payload: message,
  };
};
