import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './login_box.css';

import axios from 'axios';
const Login = () => {
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
   
  
    const userData = {
      email,
      password
    };
  
    try {
      const response = await axios.post("http://localhost:5243/api/Authentication/authenticate", userData, {
        headers: {
          "Content-Type": "application/json"
        }
      });
  
      if (response.data.isAuthenticated) {
        console.log('Login success:', response.data);
        navigate('/feed'); 
      } else {
        alert('You are not a recognized user. Please sign up.');
      }
    } catch (error) {
      console.error('Login failed:', error.message);
      alert('Login failed: ' + error.message);
    }
  };


  const handleSignUp = () => {
    navigate("/sign_up");
  };

  return (
    <div className="login-container">
      <form onSubmit={handleSubmit} className="login-form">
        <h2>Login</h2>
        <div className="input-group">
          <input
            type="email"
            placeholder="Enter AUC Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="input-group">
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <div className="input-remember">
          <input type="checkbox" id="rememberMe" />
          <label htmlFor="rememberMe">Remember me</label>
        </div>
        <button type="submit" className="login-button">Login</button>
        <button type="button" onClick={handleSignUp} className="sign-up-button">
          Sign Up
        </button> 
      </form>
    </div>
  );
};

export default Login;