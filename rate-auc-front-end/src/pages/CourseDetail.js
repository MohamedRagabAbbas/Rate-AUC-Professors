import React, { useState, useEffect, useMemo } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { TextField, CircularProgress } from '@mui/material';
import NavBar from "../components/NavBar";
import '../components/departments.css';

function CourseDetail() {
    const { courseId } = useParams();
    const navigate = useNavigate();
    const [courseDetails, setCourseDetails] = useState(null);
    const [professors, setProfessors] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(true);
                const [courseResponse, professorResponse] = await Promise.all([
                    fetch(`http://localhost:5243/api/Course/get-all/`),
                    fetch(`http://localhost:5243/api/Professor/get-all/`)
                ]);

                if (!courseResponse.ok || !professorResponse.ok) {
                    throw new Error('Failed to fetch data from server');
                }

                const courseData = await courseResponse.json();
                const professorData = await professorResponse.json();

                if (courseData.status && courseData.data) {
                    const foundCourse = courseData.data.find(course => course.id.toString() === courseId);
                    if (!foundCourse) {
                        throw new Error('Course not found');
                    }
                    setCourseDetails(foundCourse);

                    const departmentProfessors = professorData.data.filter(professor => professor.departmentId === foundCourse.departmentId);
                    setProfessors(departmentProfessors);
                } else {
                    throw new Error('Failed to load course details');
                }
            } catch (error) {
                console.error('Error fetching course and professor details:', error);
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };
        fetchData();
    }, [courseId]);

    const handleProfessorClick = (professorId) => {
        navigate(`/professors/${professorId}`);
    };

    if (loading) return <CircularProgress />;
    if (error) return <div>Error: {error}</div>;
    if (!courseDetails) return <div>No course details available.</div>;

    return (
        <>
            <NavBar />
            <div className="departments-list-container">
                <h1>Course Details</h1>
                <div className="cards-container">
                    <div className="card">
                        <div className="card-content">
                            <h2>{courseDetails.name.trim()}</h2>
                            <p><strong>Description:</strong> {courseDetails.description}</p>
                            <p><strong>Course Code:</strong> {courseDetails.code}</p>
                            <p><strong>Credit Hours:</strong> {courseDetails.credit_Hours}</p>
                            <p><strong>Department:</strong> {courseDetails.department?.name || 'Department information not available'}</p>
                        </div>
                    </div>
                </div>
                <h2>Professors</h2>
                <div className="cards-container">
                    {professors.length > 0 ? (
                        professors.map((professor) => (
                            <div className="card" key={professor.id}>
                                <div className="card-content" onClick={() => handleProfessorClick(professor.id)}>
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
        </>
    );
}

export default CourseDetail;
