import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios'; // Import Axios
import './sign_up.css';

const SignUp = () => {
  const [name, setName] = useState('');
  const [id, setId] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [standing, setStanding] = useState('');
  const [graduationYear, setGraduationYear] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    
    const userData = {
      name,
      id,
      email,
      password,
      phoneNumber,
      standing,
      graduationYear
    };

    try {
      const response = await axios.post('http://localhost:5243/api/Authentication/signup', userData, {
        method: "POST",
        headers: {},
      });

      console.log('Signup success:', response.data);
      navigate('/login'); // Redirect to login after successful signup
    } catch (error) {
      console.error('Signup failed:', error.response ? error.response.data : 'Error');
      alert('Signup failed: ' + (error.response ? error.response.data.message : 'An error occurred'));
    }
  };

  return (
    <div className="signup-container">
      <form className="signup-form" onSubmit={handleSubmit}>
        <h2>Sign Up</h2>
        <input type="text" placeholder="Name" value={name} onChange={e => setName(e.target.value)} required />
        <input type="text" placeholder="ID" value={id} onChange={e => setId(e.target.value)} required />
        <input type="email" placeholder="Email" value={email} onChange={e => setEmail(e.target.value)} required />
        <input type="password" placeholder="Password" value={password} onChange={e => setPassword(e.target.value)} required />
        <input type="text" placeholder="Phone Number" value={phoneNumber} onChange={e => setPhoneNumber(e.target.value)} />
        <input type="text" placeholder="Standing" value={standing} onChange={e => setStanding(e.target.value)} />
        <input type="text" placeholder="Graduation Year" value={graduationYear} onChange={e => setGraduationYear(e.target.value)} />
        <button type="submit">Sign Up</button>
      </form>
    </div>
  );
};

export default SignUp;
