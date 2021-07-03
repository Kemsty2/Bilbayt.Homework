import { createStore, applyMiddleware } from "redux";
import { persistStore } from "redux-persist";
import { composeWithDevTools } from "redux-devtools-extension/developmentOnly";
import { createLogger } from "redux-logger";
import thunk from "redux-thunk";
import { routerMiddleware } from "connected-react-router";

import rootReducer, { history } from "./reducers/rootReducer";
import { setAuthToken } from "../utils";
import { SET_TOKEN_USER } from "./reducers/users/users.types";

const saveAuthToken = () => (next) => (action) => {
  if (action.type === SET_TOKEN_USER) {
    // after a successful login, update the token in the API

    setAuthToken(action.payload);
  }

  // continue processing this action
  return next(action);
};

const middlewares = [
  routerMiddleware(history),
  thunk,
  createLogger({
    predicate: () => process.env.NODE_ENV === "development",
    collapsed: true,
  }),
  saveAuthToken,
];

export const store = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(...middlewares))
);

export const persistor = persistStore(store);
