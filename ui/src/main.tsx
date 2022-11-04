import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./index.css";
import { setAppElement } from "react-modal";

setAppElement("#root");
ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
