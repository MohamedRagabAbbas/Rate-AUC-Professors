import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Card, CardContent, Typography, Avatar, Box, Button, Rating } from '@mui/material';
import professors from './professorDetail.json';
import './ProfessorFeed.css';

function ProfessorDetail() {
  const { professorId } = useParams();
  const navigate = useNavigate();
  const professor = professors.find(p => p.id === professorId);

  const getRandomRating = () => Math.ceil(Math.random() * 5);

  if (!professor) {
    return <Typography variant="h6" color="error">Professor not found.</Typography>;
  }

  const handleRateClick = () => navigate(`/rate-professor/${professorId}`);
  const handleBackClick = () => navigate(-1);

  return (
    <div className="container">
      <Card sx={{ width: '100%', mx: 'auto', boxShadow: 3, border: '2px solid black', backgroundColor: '#fff', color: 'black'}}>
        <CardContent sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
          <Avatar src={professor.imageUrl} sx={{ width: 150, height: 150, mb: 2, border: '2px solid black' }} />
          <Typography variant="h5">{professor.Name}</Typography>
          <Typography variant="subtitle1">{professor.email}</Typography>
          <Typography variant="body1" sx={{ mt: 1 }}>
            Research Interest: {professor.ResearchInterests}
          </Typography>
          <Typography variant="body2" sx={{ mt: 1, mb: 2 }}>
            Biography: {professor.Biography || 'No biography available'}
          </Typography>
          {/* Rating box with blue border and labels beside each rating */}
          <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', width: '100%', border: '2px solid blue', p: 2, borderRadius: 1 }}>
            <Box sx={{ display: 'flex', mb: 1, alignItems: 'center' }}>
              <Typography sx={{ width: '100px' }}>Leniency </Typography>
              <Rating name="read-only-helpfulness" value={getRandomRating()} readOnly />
            </Box>
            <Box sx={{ display: 'flex', mb: 1, alignItems: 'center' }}>
              <Typography sx={{ width: '100px' }}>Workload </Typography>
              <Rating name="read-only-clarity" value={getRandomRating()} readOnly />
            </Box>
            <Box sx={{ display: 'flex', mb: 1, alignItems: 'center' }}>
              <Typography sx={{ width: '100px' }}>Explanation </Typography>
              <Rating name="read-only-easiness" value={getRandomRating()} readOnly />
            </Box>
          </Box>
          <Button variant="contained" color="primary" onClick={handleRateClick} sx={{ mt: 2 }}>
            Rate this Professor
          </Button>
          <Button variant="contained" color="secondary" onClick={handleBackClick} sx={{ mt: 2, bgcolor: 'red' }}>
            Back to Professors
          </Button>
        </CardContent>
      </Card>
    </div>
  );
}

export default ProfessorDetail;
