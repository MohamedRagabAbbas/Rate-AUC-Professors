import React, { useState, useEffect } from 'react';
import { Card, CardHeader, Avatar, CardContent, Typography, Box, TextField, Button } from '@mui/material';
import { Link as RouterLink } from 'react-router-dom';
import './ProfessorFeed.css';
import Rating from '@mui/material/Rating';
import NavBar from "../components/NavBar";
import axios from 'axios';

function ProfessorsFeed() {
  const [professors, setProfessors] = useState([]);
  const [departments, setDepartments] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [ratings, setRatings] = useState({});

  useEffect(() => {
    const fetchProfessors = async () => {
      try {
        const response = await axios.get('http://localhost:5243/api/Professor/get-all');
        if (response.data.status) {
          setProfessors(response.data.data);
        } else {
          console.error('Failed to fetch professors:', response.data.message);
        }
      } catch (error) {
        console.error('Error fetching professors:', error);
      }
    };

    const fetchDepartments = async () => {
      try {
        const response = await axios.get('http://localhost:5243/api/Department/get-all');
        if (response.data.status) {
          setDepartments(response.data.data);
        } else {
          console.error('Failed to fetch departments:', response.data.message);
        }
      } catch (error) {
        console.error('Error fetching departments:', error);
      }
    };

    const fetchReviews = async () => {
      try {
        const response = await axios.get('http://localhost:5243/api/Review/get-all');
        if (response.data.status) {
          const ratings = {};
          response.data.data.forEach(review => {
            if (!ratings[review.professorId]) {
              ratings[review.professorId] = { leniency: 0, workload: 0, explanation: 0, count: 0 };
            }
            ratings[review.professorId].leniency += review.leniency;
            ratings[review.professorId].workload += review.workload;
            ratings[review.professorId].explanation += review.explanation;
            ratings[review.professorId].count++;
          });
          for (const professorId in ratings) {
            ratings[professorId].leniency /= ratings[professorId].count;
            ratings[professorId].workload /= ratings[professorId].count;
            ratings[professorId].explanation /= ratings[professorId].count;
            ratings[professorId].average = (ratings[professorId].leniency + ratings[professorId].workload + ratings[professorId].explanation) / 3;
          }
          setRatings(ratings);
        } else {
          console.error('Failed to fetch reviews:', response.data.message);
        }
      } catch (error) {
        console.error('Error fetching reviews:', error);
      }
    };

    fetchProfessors();
    fetchDepartments();
    fetchReviews();
  }, []);

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const getDepartmentName = (departmentId) => {
    const dept = departments.find(dept => dept.id === departmentId);
    return dept ? dept.name : 'No Department';
  };

  const filteredProfessors = professors
    .sort((a, b) => a.name.localeCompare(b.name))
    .filter(professor => professor.name.toLowerCase().includes(searchTerm.toLowerCase()));

  return (
    <>
      <NavBar />
      <Box className="container">
        <Typography variant="h5" className="header" style={{ color: '#000000', margin: '20px', fontWeight: 'bold' }}>
          Search by Professors
        </Typography>
        <TextField
          label="Search Professors"
          variant="outlined"
          value={searchTerm}
          onChange={handleSearchChange}
          fullWidth
          sx={{
            marginBottom: '20px',
          }}
        />
        <Box className="cardsContainer">
          {filteredProfessors.map((professor, index) => (
            <RouterLink to={`/professors/${professor.id}`} className="link" key={index}>
              <Card className="professorCard" sx={{ border: '1px solid #000000', borderRadius: '15px', boxShadow: '0px 4px 8px rgba(0, 0, 0, 0.1)', marginBottom: '20px' }}>
                <CardHeader
                  avatar={<Avatar alt={professor.name} src={professor.imageUrl || '/path/to/default/avatar.png'} sx={{ width: 80, height: 80 }} />}
                  title={professor.name}
                  subheader={
                    <Typography variant="body2" color="text.secondary">{getDepartmentName(professor.departmentId)}</Typography>
                  }
                />
                <CardContent>
                  <Typography variant="body2" style={{ color: '#2196f3' }}>{professor.position || 'No additional details available'}</Typography>
                  <Rating name="read-only" value={ratings[professor.id] ? ratings[professor.id].average : 0} readOnly precision={0.5} />
                  <Button variant="contained" color="primary" size="small" sx={{ mt: 2 }}>
                    View/Rate Professor
                  </Button>
                </CardContent>
              </Card>
            </RouterLink>
          ))}
        </Box>
      </Box>
    </>
  );
}

export default ProfessorsFeed;
