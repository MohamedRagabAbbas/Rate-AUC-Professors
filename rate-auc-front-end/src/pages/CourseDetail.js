import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Typography, Button, Grid, Paper, Container } from '@mui/material';
import professors from './professorDetail.json';
import './CourseDetail.css'; // Ensure CSS is tailored to handle grid and paper styling
import NavBar from "../components/NavBar";

function CourseDetail() {
    const { courseName } = useParams(); // This gets the course name from the URL
    const navigate = useNavigate();

    const courseProfessors = professors.filter(prof => prof.Courses && prof.Courses.includes(courseName));

    const handleProfessorClick = (profId) => {
        navigate(`/professors/${profId}`);
    };

    return (
	<>
	<NavBar/>
        <div className="departments-list-container">
            <Container maxWidth="lg">
                <Paper elevation={3} style={{ padding: '20px', marginBottom: '20px' }}>
                    {/* Replace "General Courses" with dynamic course name */}
                    <Typography variant="h3" component="h1" className="centered-title" gutterBottom>
                    <h1> {courseName} </h1>
                    </Typography>
                    <Typography variant="h6" gutterBottom>
                    <header>Course Objectives</header>
                    </Typography>
                    <Typography variant="body1" paragraph>
                        Detail the objectives of the course here...
                    </Typography>
                    <Typography variant="h6" gutterBottom>
                    <header>Prerequisites</header>
                    </Typography>
                    <Typography variant="body1" paragraph>
                        List prerequisites here...
                    </Typography>
                </Paper>
                <Grid container spacing={2}>
                    {courseProfessors.map((prof, index) => (
                        <Grid item xs={6} sm={4} md={3} lg={2} key={index}>
                            <Button
                                className="button-size"
                                variant="contained"
                                color="primary"
                                fullWidth
                                onClick={() => handleProfessorClick(prof.id)}
                            >
                                {prof.Name.toUpperCase()}
                            </Button>
                        </Grid>
                    ))}
                </Grid>
            </Container>
        </div>
		</>
    );
}

export default CourseDetail;
