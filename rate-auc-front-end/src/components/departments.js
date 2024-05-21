import React, { useState, useEffect, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import './departments.css';
import { TextField, CircularProgress } from '@mui/material';

function DepartmentsList() {
    const [departments, setDepartments] = useState([]);
    const [professors, setProfessors] = useState([]);
    const [selectedDepartment, setSelectedDepartment] = useState(null);
    const [searchTerm, setSearchTerm] = useState('');
    const [loading, setLoading] = useState(true);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(true);
                const [departmentsResponse, professorsResponse] = await Promise.all([
                    fetch('http://localhost:5243/api/Department/get-all'),
                    fetch('http://localhost:5243/api/Professor/get-all')
                ]);
                
                const departmentsData = await departmentsResponse.json();
                const professorsData = await professorsResponse.json();
                
                if (departmentsData && departmentsData.data) {
                    setDepartments(departmentsData.data);
                } else {
                    throw new Error('No departments found');
                }
                
                if (professorsData && professorsData.data) {
                    setProfessors(professorsData.data);
                } else {
                    throw new Error('No professors found');
                }
            } catch (error) {
                console.error('Error fetching data:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    const handleDepartmentClick = (id, name) => {
        const departmentProfessors = professors.filter(professor => professor.departmentId === id);
        setSelectedDepartment({ id, name, professors: departmentProfessors });
    };

    const handleReturn = () => {
        setSelectedDepartment(null);
    };

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const handleProfessorClick = (professorId) => {
        navigate(`/professors/${professorId}`);
    };

    const filteredDepartments = useMemo(() => {
        return departments.filter(department =>
            department.name.toLowerCase().includes(searchTerm.toLowerCase())
        );
    }, [departments, searchTerm]);

    if (loading) {
        return <CircularProgress />;
    }

    return (
        <div className="departments-list-container">
            {selectedDepartment ? (
                <div className="professors-container">
                    <div className="department-header">
                        <h2>{selectedDepartment.name}</h2>
                        <button className="return-button" onClick={handleReturn}>Return to Departments</button>
                    </div>
                    <div className="cards-container">
                        {selectedDepartment.professors.length > 0 ? (
                            selectedDepartment.professors.map((professor) => (
                                <div className="card" key={professor.id}>
                                    <div onClick={() => handleProfessorClick(professor.id)}>
                                        {professor.name}
                                    </div>
                                    <button onClick={() => handleProfessorClick(professor.id)}>
                                        View Details
                                    </button>
                                </div>
                            ))
                        ) : (
                            <div>No professors found</div>
                        )}
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
                        {filteredDepartments.length > 0 ? (
                            filteredDepartments.map((department) => (
                                <div className="card" key={department.id} onClick={() => handleDepartmentClick(department.id, department.name)}>
                                    {department.name}
                                </div>
                            ))
                        ) : (
                            <div>No departments found</div>
                        )}
                    </div>
                </>
            )}
        </div>
    );
}

export default DepartmentsList;
