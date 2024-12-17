import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import ReadingList from "./ReadingList";

const App: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<ReadingList />} />
      </Routes>
    </Router>
  );
};

export default App;
