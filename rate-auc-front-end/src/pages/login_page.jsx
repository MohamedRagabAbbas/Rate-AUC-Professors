import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './login_page.css'

const Login = () => {
 const navigate = useNavigate();
 const [username, setUsername] = useState('');
 const [password, setPassword] = useState('');


 const handleSubmit = (event) => {
   event.preventDefault();
   if (username.endsWith('@aucegypt.edu')) {


     navigate(`/feed`);
   } else {
     alert('Please use an AUC email address to login.');
   }
 };
 const handleGoogleLogin = () => {
   navigate("/feed");
   alert('Google login not implemented yet.');
 };


 return (
   <div className="login-container">
     <form onSubmit={handleSubmit} className="login-form">
       <h2>Login</h2>
       <div className="input-group">
         <input
           type="email"
           placeholder="Enter AUC Email"
           value={username}
           onChange={(e) => setUsername(e.target.value)}
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
       <button onClick={handleGoogleLogin} className="login-google-button">
      
        Login with Google
        </button> 
     </form>
   </div>
  
 );
};


export default Login;
