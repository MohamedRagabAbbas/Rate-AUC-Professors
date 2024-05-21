import React, { useState, useEffect } from 'react';
import { Button, TextField, Box, Typography, Rating, FormControl, useTheme } from '@mui/material';
import { teal, red } from '@mui/material/colors';
import { motion } from 'framer-motion';
import { useNavigate } from 'react-router-dom'; // Import useNavigate for navigation
import NavBar from "../components/NavBar";
import axios from 'axios'; // Make sure to import axios if not already imported
import { useParams } from 'react-router-dom';



export default function RateProfessor() {
  const { professorId } = useParams();
  const [professor, setProfessor] = useState(null);
  const [leniency, setLeniency] = useState(0);
  const [workload, setWorkload] = useState(0);
  const [explanation, setExplanation] = useState(0);
  const [comment, setComment] = useState('');
  const [submitStatus, setSubmitStatus] = useState('');
  const navigate = useNavigate(); // Hook for navigation

  useEffect(() => {
    const fetchProfessor = async () => {
      try {
        const response = await axios.get(`http://localhost:5243/api/Professor/get-by-id/${professorId}`);
        if (response.data.status) {
          setProfessor(response.data.data); // Assuming response.data.data contains the professor data
        } else {
          throw new Error(response.data.message);
        }
      } catch (error) {
        console.error('Failed to fetch professor details:', error);
      }
    };

    fetchProfessor();
  }, [professorId]);


  const handleBack = () => {
    navigate(-1); // Uses the navigate hook to go back
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const userId = "2b6136fe-6763-4e16-b9f9-589334ab248c";
    const review = {
      professorId, // Include the professorId in the review (linking)
      leniency,
      workload,
      explanation,
      content: comment
    };

    try {
      const response = await fetch(`http://localhost:5243/api/review/add/?userId=${userId}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer your-auth-token'
        },
        body: JSON.stringify(review)
      });

      const responseData = await response.json();

      if (response.ok) {
        setSubmitStatus('Review submitted successfully!');
      } else {
        throw new Error(responseData.message || 'Failed to submit review');
      }
    } catch (error) {
      setSubmitStatus(`Error: ${error.message}`);
    }
  };
  

    return (
        <>
            <NavBar />
            <Box sx={{ width: '95vw', minHeight: '91vh', bgcolor: teal[50], p: 3, overflowX: 'hidden', mx: 'auto' }}> {/* Adjusted dimensions */}
                <Typography variant="h4" component={motion.div} initial={{ scale: 0.9 }} animate={{ scale: 1 }} transition={{ duration: 0.5 }}>
                    Rate Professor {professor ? professor.name : 'Loading...'}
                </Typography>
                <form onSubmit={handleSubmit} style={{ width: '100%', padding: '20px', boxSizing: 'border-box' }}>
                    <FormControl fullWidth margin="normal">
                        <Typography component="legend">Leniency</Typography>
                        <Rating
                            name="leniency-rating"
                            value={leniency}
                            onChange={(event, newValue) => {
                                setLeniency(newValue);
                            }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="normal">
                        <Typography component="legend">Workload</Typography>
                        <Rating
                            name="workload-rating"
                            value={workload}
                            onChange={(event, newValue) => {
                                setWorkload(newValue);
                            }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="normal">
                        <Typography component="legend">Explanation</Typography>
                        <Rating
                            name="explanation-rating"
                            value={explanation}
                            onChange={(event, newValue) => {
                                setExplanation(newValue);
                            }}
                        />
                    </FormControl>
                    <TextField
                        fullWidth
                        label="Comment"
                        multiline
                        rows={4}
                        value={comment}
                        onChange={e => setComment(e.target.value)}
                        margin="normal"
                    />
                    <Box sx={{ display: 'flex', justifyContent: 'space-between', mt: 2 }}>
                        <Button type="submit" variant="contained" color="primary">Submit Review</Button>
                        <Button onClick={handleBack} variant="contained" sx={{ bgcolor: red[500] }}>Go Back</Button>
                    </Box>
                </form>
                <Typography variant="body2" color="error">{submitStatus}</Typography>
            </Box>
        </>
    );
}
