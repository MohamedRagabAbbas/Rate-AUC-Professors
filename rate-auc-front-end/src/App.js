// App.js
import React, { useState } from 'react';
import logo from "./logo.svg";
import "./App.css";
import NavBar from "./components/NavBar";
import Departments from "../src/components/departments.js";

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
      <NavBar pages={pages} onPageChange={handlePageChange} />
      {renderPage()}
    </div>
  );
}

export default App;
