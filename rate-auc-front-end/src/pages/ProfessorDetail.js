import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Card, CardContent, Typography, Avatar, Box, Button, Rating, Divider } from '@mui/material';
import NavBar from "../components/NavBar";
import axios from 'axios';

function ProfessorDetail() {
  const { professorId } = useParams();
  const navigate = useNavigate();
  const [professor, setProfessor] = useState(null);
  const [ratings, setRatings] = useState({ leniency: 0, workload: 0, explanation: 0 });
  const [reviews, setReviews] = useState([]);
  const [comments, setComments] = useState([]);  // New state for comments

  useEffect(() => {
    const fetchProfessor = async () => {
      const response = await axios.get('http://localhost:5243/api/Professor/get-all');
      if (response.data.status) {
        const foundProfessor = response.data.data.find(p => p.id.toString() === professorId);
        setProfessor(foundProfessor);
      } else {
        console.error('Failed to fetch professors:', response.data.message);
      }
    };
    fetchProfessor();
  }, [professorId]);

  useEffect(() => {
    const fetchReviews = async () => {
      const response = await axios.get(`http://localhost:5243/api/Review/get-all-reviews-by-professorId/${professorId}`);
      if (response.data.status) {
        setReviews(response.data.data);
        const leniency = response.data.data.reduce((acc, curr) => acc + curr.leniency, 0) / response.data.data.length;
        const workload = response.data.data.reduce((acc, curr) => acc + curr.workload, 0) / response.data.data.length;
        const explanation = response.data.data.reduce((acc, curr) => acc + curr.explanation, 0) / response.data.data.length;
        setRatings({ leniency, workload, explanation });
      } else {
        console.error('Failed to fetch reviews:', response.data.message);
      }
    };
    if (professor) {
      fetchReviews();
    }
  }, [professor]);

  if (!professor) {
    return (
      <>
        <NavBar />
        <Typography variant="h6" color="error">Professor not found.</Typography>
      </>
    );
  }

  return (
    <>
      <NavBar />
      <div style={{ display: 'flex', justifyContent: 'center', backgroundColor: '#f5f5f5', padding: '20px' }}>
        <div style={{ flex: 1, maxWidth: 'calc(100% / 3)', padding: 20 }}>
          <Card style={{ width: '100%', boxShadow: '0px 4px 6px rgba(0,0,0,.1)' }}>
            <CardContent>
              <Avatar src={professor.imageUrl || '/path/to/default/avatar.png'} style={{ width: 120, height: 120, margin: '0 auto' }} />
              <Typography variant="h5" align="center">{professor.name}</Typography>
              <Typography variant="subtitle1" align="center">{professor.email}</Typography>
              <Typography variant="body1" align="center">Research Interest: {professor.bio || 'No additional details available'}</Typography>
              <Typography variant="body2" align="center">Biography: {professor.bio || 'No biography available'}</Typography>
              <Box style={{ my: 2, borderTop: '1px solid #2196f3', borderBottom: '1px solid #2196f3', padding: '10px 0', textAlign: 'center', marginBottom: '20px' }}>
                <Typography variant="subtitle2">Leniency</Typography>
                <Rating value={ratings.leniency} readOnly />
                <Typography variant="subtitle2">Workload</Typography>
                <Rating value={ratings.workload} readOnly />
                <Typography variant="subtitle2">Explanation</Typography>
                <Rating value={ratings.explanation} readOnly />
              </Box>
              <Button onClick={() => navigate(`/rate-professor/${professorId}`)} style={{ backgroundColor: '#2196f3', color: '#ffffff', '&:hover': { backgroundColor: '#2196f3' }, width: '100%', marginBottom: '10px' }}>
                Rate this Professor
              </Button>
              <Button onClick={() => navigate(-1)} style={{ backgroundColor: '#f44336', color: '#ffffff', '&:hover': { backgroundColor: '#f44336' }, width: '100%' }}>
                Back to Professors
              </Button>
            </CardContent>
          </Card>
        </div>
        <div style={{ flex: 2, padding: 20 }}>
          <Typography variant="h6" gutterBottom>{reviews.length} people have rated this professor</Typography>
          {reviews.map((review) => (
  <Box key={review.id} style={{
    borderLeft: '4px solid #2196f3',
    background: '#fff',
    boxShadow: '0px 4px 6px rgba(0,0,0,.1)',
    marginBottom: '20px',
    padding: '15px',
    borderRadius: '8px'
  }}>
    <div style={{ display: 'flex', alignItems: 'center', marginBottom: '10px' }}>
      <Avatar>{review.studentName ? review.studentName[0] : '?'}</Avatar>
      <div style={{ marginLeft: '10px' }}>
        <Typography variant="subtitle1" gutterBottom><strong>{review.studentName || 'Anonymous'}</strong></Typography>
        {/* Display date if available */}
        {review.timestamp && 
          (<Typography variant="body2" color="textSecondary">
            {new Date(review.timestamp).toLocaleDateString()}
          </Typography>)
        }
      </div>
    </div>

    {/* Display ratings with labels */}
    {"Leniency Workload Explanation".split(" ").map((label) => (
      <div style={{ display: 'flex', alignItems: 'center', marginBottom: '10px' }}>
        <Typography variant="subtitle2" style={{ flex: 1 }}>{label}</Typography>
        <Rating value={review[label.toLowerCase()]} readOnly />
      </div>
    ))}

    {/* Display comment if exists */}
    {review.content && (
      <>
        <Divider style={{ marginTop: '10px', marginBottom: '10px' }} />
        <Box style={{
          border: '1px solid #2196f3',
          padding: '8px',
          borderRadius: '5px',
          background: '#e3f2fd'
        }}>
          <Typography variant="body2">
            "{review.content}"
          </Typography>
        </Box>
        <Divider style={{ marginTop: '15px', marginBottom: '15px' }} />
      </>
    )}
  </Box>
          ))}
        </div>
      </div>
    </>
  );
}

export default ProfessorDetail;