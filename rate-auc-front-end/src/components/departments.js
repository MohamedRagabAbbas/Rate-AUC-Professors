import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom'; // Import useNavigate
import './departments.css'; // Import CSS file for styling
import Papa from 'papaparse'; // Import PapaParse library
import { TextField } from '@mui/material'; // Import TextField component for the search bar
import professors from '../pages/professorDetail.json';

function DepartmentsList() {
    const [categories, setCategories] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [parsedCsv, setParsedCsv] = useState(null);
    const [searchTerm, setSearchTerm] = useState('');
    const navigate = useNavigate(); // Initialize navigate function

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const response = await fetch('/professors_data.csv');
                const reader = response.body.getReader();
                const result = await reader.read();
                const decoder = new TextDecoder('utf-8');
                const csv = decoder.decode(result.value);
                const parsedData = Papa.parse(csv, { header: true });
                const uniqueCategories = [...new Set(parsedData.data.map(row => row.Category))];
                setCategories(uniqueCategories);
                setParsedCsv({
                    ...parsedData,
                    data: parsedData.data.map(row => ({
                        ...row,
                        Professor: standardizeName(row.Professor)
                    }))
                });
            } catch (error) {
                console.error('Error fetching categories:', error);
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

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const handleProfessorClick = (professorName) => {
        let formattedName = standardizeName(professorName);
        let professor = professors.find(p => standardizeName(p.Name) === formattedName);
        if (professor) {
            navigate(`/rate-professor/${professor.id}`);
        } else {
            console.error("Professor not found");
        }
    };

    const filteredCategories = categories.filter(category => 
        category.toLowerCase().includes(searchTerm.toLowerCase()));

    function standardizeName(name) {
        let parts = name.split(/,|\./).join("").split(/\s+/);
        let lastName = parts.shift();
        return [...parts, lastName].join(" ");
    }

    return (
        <div className="departments-list-container">
            {selectedCategory ? (
                <div className="professors-container">
                    <div className="category-header">
                        <h2>{selectedCategory}</h2>
                        <button className="return-button" onClick={handleReturn}>Return to Departments</button>
                    </div>
                    <div className="cards-container">
                        {parsedCsv && parsedCsv.data.map((row, index) => {
                            if (row.Category === selectedCategory) {
                                return (
                                    <div className="card" key={index} onClick={() => handleProfessorClick(row.Professor)}>
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
                    <h1>Search For Departments</h1>
                    <TextField
                        label="Search Departments"
                        variant="outlined"
                        value={searchTerm}
                        onChange={handleSearchChange}
                        fullWidth
                        sx={{ marginBottom: '20px' }}
                    />
                    <div className="cards-container">
                        {filteredCategories && filteredCategories.length > 0 ? (
                            filteredCategories.map((category, index) => (
                                <div className="card" key={index} onClick={() => handleCategoryClick(category)}>
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
