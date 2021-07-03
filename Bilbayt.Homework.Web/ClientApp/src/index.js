import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { PersistGate } from "redux-persist/integration/react";
import { ConnectedRouter } from "connected-react-router";

import { history } from "./store/reducers/rootReducer";
import { store, persistor } from "./store";

import App from "./App";

import reportWebVitals from "./reportWebVitals";

import "./assets/scss/index.scss";
import "boosted/dist/css/boosted.min.css";
import "boosted/dist/js/boosted.bundle.js";
import "react-toastify/dist/ReactToastify.css";
import "./assets/css/loading.min.css";
import "ldbutton/dist/ldbtn.min.css";

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <PersistGate persistor={persistor}>
          <App />
        </PersistGate>
      </ConnectedRouter>
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
