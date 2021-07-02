import { createStore, applyMiddleware } from "redux";
import { persistStore } from "redux-persist";
import { composeWithDevTools } from "redux-devtools-extension/developmentOnly";
import { createLogger } from "redux-logger";
import thunk from "redux-thunk";
import { routerMiddleware } from "connected-react-router";

import rootReducer, { history } from "./reducers/rootReducer";

const middlewares = [
  routerMiddleware(history),
  thunk,
  createLogger({
    predicate: () => process.env.NODE_ENV === "development",
    collapsed: true,
  }),
];

export const store = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(...middlewares))
);

export const persistor = persistStore(store);
