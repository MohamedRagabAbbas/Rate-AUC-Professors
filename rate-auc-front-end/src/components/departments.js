import React, { useState, useEffect } from "react";
import "./departments.css"; // Import CSS file for styling
import Papa from "papaparse"; // Import PapaParse library

function DepartmentsList() {
  const [categories, setCategories] = useState([]);
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [parsedCsv, setParsedCsv] = useState(null);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await fetch("/professors_data.csv");
        const reader = response.body.getReader();
        const result = await reader.read();
        const decoder = new TextDecoder("utf-8");
        const csv = decoder.decode(result.value);
        const parsedData = Papa.parse(csv, { header: true });
        const uniqueCategories = [
          ...new Set(parsedData.data.map((row) => row.Category)),
        ];
        setCategories(uniqueCategories);
        setParsedCsv(parsedData);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };

    fetchCategories();
  }, []);

  const handleCategoryClick = (category) => {
    setSelectedCategory(category);
  };

  const handleReturn = () => {
    setSelectedCategory(null);
  };

  return (
    <div className="departments-list-container">
      {selectedCategory ? (
        <div className="professors-container">
          <div className="category-header">
            <h2>{selectedCategory}</h2>
            <button className="return-button" onClick={handleReturn}>
              Return to Departments
            </button>
          </div>
          <div className="cards-container">
            {parsedCsv &&
              parsedCsv.data.map((row, index) => {
                if (row.Category === selectedCategory) {
                  return (
                    <div className="card" key={index}>
                      {row.Professor}
                    </div>
                  );
                }
                return null;
              })}
          </div>
        </div>
      ) : (
        <>
          <h1>Departments</h1>
          <div className="cards-container">
            {categories && categories.length > 0 ? (
              categories.map((category, index) => (
                <div
                  className="card"
                  key={index}
                  onClick={() => handleCategoryClick(category)}
                >
                  {category}
                </div>
              ))
            ) : (
              <div>No categories found</div>
            )}
          </div>
        </>
      )}
    </div>
  );
}

export default DepartmentsList;
