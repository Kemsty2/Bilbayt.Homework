import storage from "redux-persist/lib/storage";
import topReducer from "./topReducer";
import { createBrowserHistory } from "history";
import { persistReducer } from "redux-persist";

import { USER_LOGOUT } from "./users/users.types";

export const history = createBrowserHistory();

export const persistConfig = {
  key: "root",
  storage,
  whilelist: ["users"],
  blacklist: ["router"],
};

const rootReducer = (state, action) => {
  // when a logout action is dispatched it will reset redux state
  if (action.type === USER_LOGOUT) {
    state = undefined;
  }

  return topReducer(history)(state, action);
};

export default persistReducer(persistConfig, rootReducer);
