import { toast } from "react-toastify";

import {
  PENDING_STORE,
  SUCCESS_STORE,
  FAIL_STORE,
  RESET_MESSAGE_STORE,
} from "./messages.types";

const INITIAL_STATE = {
  message: "",
  status: "",
};

export default (state = INITIAL_STATE, action = {}) => {
  switch (action.type) {
    case SUCCESS_STORE:
      if (action.payload) toast.info(action.payload);
      return {
        ...state,
        status: "success",
        message: action.payload,
      };

    case FAIL_STORE:
      if (action.payload) toast.error(action.payload);
      return {
        ...state,
        status: "fail",
        message: action.payload,
      };

    case PENDING_STORE:
      return {
        ...state,
        status: "pending",
        message: action.payload,
      };

    case RESET_MESSAGE_STORE:
      return {
        ...state,
        status: "",
        message: "",
      };

    default:
      return state;
  }
};
