import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Typography, Grid, TextField } from '@mui/material';
import professors from './professorDetail.json';
import './Courses.css'; // Make sure this CSS file includes the necessary styles

function Courses() {
    const navigate = useNavigate();
    const coursesSet = new Set();
    const [searchTerm, setSearchTerm] = useState('');

    // Collect all unique courses
    professors.forEach(prof => {
        prof.Courses.split(', ').forEach(course => {
            coursesSet.add(course.trim());
        });
    });
    const courses = Array.from(coursesSet).filter(course =>
        course.toLowerCase().includes(searchTerm.toLowerCase())
    );

    const handleCourseClick = (courseName) => {
        navigate(`/courses/detail/${courseName}`);
    };

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };

    return (
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
            <Grid container spacing={2}>
                {courses.map((course, index) => (
                    <Grid item xs={12} sm={6} md={3} key={index}>
                        <div className="card" onClick={() => handleCourseClick(course)}>
                            <div className="card-content">
                                <Typography gutterBottom variant="h7">
                                    {course}
                                </Typography>
                            </div>
                        </div>
                    </Grid>
                ))}
            </Grid>
        </div>
    );
}

export default Courses;
