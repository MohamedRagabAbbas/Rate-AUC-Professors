import React, { useState, useEffect, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { TextField, CircularProgress } from '@mui/material';
import NavBar from "../components/NavBar";
import '../components/departments.css';

function Courses() {
    const navigate = useNavigate();
    const [courses, setCourses] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchCourses = async () => {
            try {
                setLoading(true);
                const response = await fetch('http://localhost:5243/api/Course/get-all');
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                const data = await response.json();
                if (data.status && data.data) {
                    setCourses(data.data);
                } else {
                    throw new Error('No courses found in the response');
                }
            } catch (error) {
                console.error('Error fetching courses:', error);
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };
        fetchCourses();
    }, []);

    const handleCourseClick = (courseId) => {
        navigate(`/courses/detail/${courseId}`);
    };

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const filteredCourses = useMemo(() => {
        return courses.filter(course =>
            course.name.toLowerCase().includes(searchTerm.toLowerCase())
        );
    }, [courses, searchTerm]);

    if (loading) {
        return <CircularProgress />;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <>
            <NavBar />
            <div className="departments-list-container">
                <h1>Search For Courses</h1>
                <TextField
                    label="Search Courses"
                    variant="outlined"
                    value={searchTerm}
                    onChange={handleSearchChange}
                    fullWidth
                    sx={{ marginBottom: '20px' }}
                />
                <div className="cards-container">
                    {filteredCourses.length > 0 ? (
                        filteredCourses.map((course) => (
                            <div className="card" key={course.id} onClick={() => handleCourseClick(course.id)}>
                                {course.name}
                            </div>
                        ))
                    ) : (
                        <div>No courses found</div>
                    )}
                </div>
            </div>
        </>
    );
}

export default Courses;
