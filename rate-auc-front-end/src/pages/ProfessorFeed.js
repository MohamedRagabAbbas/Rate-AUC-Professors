import React, { useState } from 'react';
import { Card, CardHeader, Avatar, CardContent, Typography, Box, TextField, Button } from '@mui/material';
import { Link as RouterLink } from 'react-router-dom';
import './ProfessorFeed.css'; // Ensure this file is named correctly and available in your project directory
import professors from './updated_professors.json'; // Importing the updated JSON data
import Rating from '@mui/material/Rating';

function ProfessorsFeed() {
  const [searchTerm, setSearchTerm] = useState('');

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  // Function to generate random ratings
  const getRandomRating = () => Math.ceil(Math.random() * 5);

  // Filter professors based on search term
  const filteredProfessors = professors.sort((a, b) => a.Name.localeCompare(b.Name))
    .filter(professor => professor.Name.toLowerCase().includes(searchTerm.toLowerCase()));

  return (
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
                avatar={<Avatar alt={professor.Name} src={professor.imageUrl} sx={{ width: 80, height: 80 }} />}
                title={professor.Name}
                subheader={
                  <Typography variant="body2" color="text.secondary">{professor.Department}</Typography>
                }
              />
              <CardContent>
                <Typography variant="body2" style={{ color: '#2196f3' }}>{professor.Position}</Typography>
                <Rating name="read-only" value={getRandomRating()} readOnly precision={0.5} />
                <Button variant="contained" color="primary" size="small" sx={{ mt: 2 }}>
                  View/Rate Professor
                </Button>
              </CardContent>
            </Card>
          </RouterLink>
        ))}
      </Box>
    </Box>
  );
}

export default ProfessorsFeed;
