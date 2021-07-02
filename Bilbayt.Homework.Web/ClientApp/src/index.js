import React from "react";
import ReactDOM from "react-dom";
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
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
