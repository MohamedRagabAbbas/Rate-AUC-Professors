import React, { useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import {
  Typography,
  Box,
  TextField,
  Button,
  Radio,
  RadioGroup,
  FormControlLabel,
  FormControl,
  FormLabel,
  Paper
} from '@mui/material';
import StarBorder from '@mui/icons-material/StarBorder';
import Star from '@mui/icons-material/Star';
import professors from './professorDetail.json'; // Ensure this path is correct
import './ProfessorFeed.css';
import NavBar from "../components/NavBar";

function RateProfessor() {
  const { professorId } = useParams();
  const navigate = useNavigate();
  const professor = professors.find(p => p.id === professorId);
  const [ratings, setRatings] = useState({
    easiness: '',
    helpfulness: '',
    clarity: '',
    comments: ''
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setRatings({
      ...ratings,
      [name]: value
    });
  };

  const validateForm = () => {
    if (!ratings.easiness || !ratings.helpfulness || !ratings.clarity || ratings.comments.trim() === '') {
      alert('All fields must be filled out.');
      return false;
    }
    return true;
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (!validateForm()) {
      return;
    }
    console.log('Submitted Ratings:', ratings);
    navigate(-1);
  };

  if (!professor) {
    return <Typography variant="h6" color="error">Professor not found.</Typography>;
  }

  return (
  <>
  <NavBar/>
    <Box className="container">
      <Box component={Paper} elevation={3} sx={{ p: 3, width: '95%', maxWidth: 'none', mx: 'auto', mt: 5, border: '1px solid black' }}>
        <Typography variant="h4" sx={{ mb: 2 }}>Rate: {professor.Name}</Typography>
        <FormControl component="fieldset" fullWidth>
          <FormLabel component="legend">Leniency</FormLabel>
          <RadioGroup row name="easiness" value={ratings.easiness} onChange={handleChange}>
            {/* Easiness Ratings */}
            <FormControlLabel value="1" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="1 (Hard)" />
            <FormControlLabel value="2" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="2" />
            <FormControlLabel value="3" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="3" />
            <FormControlLabel value="4" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="4" />
            <FormControlLabel value="5" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="5 (Easy)" />
          </RadioGroup>
          <FormLabel component="legend">Workload</FormLabel>
          <RadioGroup row name="helpfulness" value={ratings.helpfulness} onChange={handleChange}>
            {/* Helpfulness Ratings */}
            <FormControlLabel value="1" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="1 (Useless)" />
            <FormControlLabel value="2" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="2" />
            <FormControlLabel value="3" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="3" />
            <FormControlLabel value="4" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="4" />
            <FormControlLabel value="5" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="5 (Extremely Helpful)" />
          </RadioGroup>
          <FormLabel component="legend">Explanation</FormLabel>
          <RadioGroup row name="clarity" value={ratings.clarity} onChange={handleChange}>
            {/* Clarity Ratings */}
            <FormControlLabel value="1" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="1 (None)" />
            <FormControlLabel value="2" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="2" />
            <FormControlLabel value="3" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="3" />
            <FormControlLabel value="4" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="4" />
            <FormControlLabel value="5" control={<Radio icon={<StarBorder />} checkedIcon={<Star />} />} label="5 (Crystal)" />
          </RadioGroup>
          <TextField
            fullWidth
            multiline
            rows={4}
            name="comments"
            label="Comments"
            variant="outlined"
            value={ratings.comments}
            onChange={handleChange}
            margin="normal"
            helperText="Please keep comments clean. Libelous comments will be removed."
            sx={{ mt: 2 }}
          />
          <Button type="submit" variant="contained" color="primary" onClick={handleSubmit} sx={{ mt: 2 }}>
            Rate this Professor
          </Button>
          <Button variant="contained" color="secondary" onClick={() => navigate(-1)} sx={{ mt: 2, bgcolor: 'red' }}>
            Return to Previous Page
          </Button>
        </FormControl>
      </Box>
    </Box>
	</>
  );
}

export default RateProfessor;
