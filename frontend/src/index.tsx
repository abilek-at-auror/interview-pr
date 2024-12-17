import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css"; // Add any global CSS styling here
import App from "./components/App";

const rootElement = document.getElementById("root");

// Render the app
const root = ReactDOM.createRoot(rootElement as HTMLElement);
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
