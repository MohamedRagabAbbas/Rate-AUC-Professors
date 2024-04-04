import React, { useState, useEffect } from 'react';
import './departments.css'; // Import CSS file for styling

function DepartmentsList() {
    const [names, setNames] = useState([]);

    useEffect(() => {
        const fetchNames = async () => {
            try {
                const response = await fetch('./names.csv'); // Changed file path
                if (!response.ok) {
                    throw new Error('Failed to fetch names');
                }
                const csvData = await response.text();
                const parsedNames = csvData.split('\n').map(name => name.trim());
                const filteredNames = parsedNames.filter(name => name !== '');
                setNames(filteredNames);
            } catch (error) {
                console.error('Error fetching CSV file:', error);
            }
        };

        fetchNames();
    }, []);

    return (
        <div className="departments-list-container"> {/* Apply a CSS class to the container */}
            <h1>Departments</h1>
            <div className="cards-container"> {/* Use a div container for the card layout */}
                {names.map((name, index) => (
                    <div className="card" key={index}>{name}</div> /* Each name is wrapped in a{ card */
                ))}
            </div>
        </div>
    );
}

export default DepartmentsList;
