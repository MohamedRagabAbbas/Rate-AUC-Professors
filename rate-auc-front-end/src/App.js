import React, { useState } from "react";
import "./App.css";
import Feed from "./pages/feed";
import TestingRouting from "./pages/professors";
import NotFound from "./pages/notFound";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Departments from "./pages/departments";

function App() {
  const [currentPage, setCurrentPage] = useState("Home");

  const handlePageChange = (page) => {
    setCurrentPage(page);
  };

  const pages = [
    { name: "Home" },
    { name: "Departments" },
    // Add more pages as needed
  ];

  // Render the corresponding component based on the currentPage state
  const renderPage = () => {
    switch (currentPage) {
      case "Departments":
        return <Departments />;
      // Add cases for other pages as needed
      default:
        return <>test</>;
    }
  };

  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Feed />} />
          <Route path="/home" element={<Feed />} />
          <Route path="/feed" element={<Feed />} />
          <Route path="/professors" element={<TestingRouting />} />
          <Route path="/departments" element={<Departments />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
