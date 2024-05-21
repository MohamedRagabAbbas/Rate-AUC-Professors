import React, { useState } from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Tooltip, IconButton, Avatar, Menu, MenuItem, Typography } from '@mui/material';
import "./App.css";
import NavBar from "./components/NavBar";
import Feed from "./pages/feed";
import ProfessorsFeed from "./pages/ProfessorFeed";
import ProfessorDetail from "./pages/ProfessorDetail";
import Departments from "./pages/departments";
import RateProfessor from './pages/RateProfessor';
import NotFound from "./pages/notFound";
import Courses from './pages/Courses'; // Import the Courses component
import CourseDetail from './pages/CourseDetail';
import Login from './pages/login';
import SignUp from './pages/sign_up';
import PersonalProfile  from './pages/personalProfile';
import Profile from './components/userProfile/profile';

function App() {
  const [currentPage, setCurrentPage] = useState("Home");

  const handlePageChange = (page) => {
    setCurrentPage(page);
  };

  const pages = [
    { name: "Home" },
    { name: "Departments" },
    // Add more pages as needed
  ];

  // Render the corresponding component based on the currentPage state
  const renderPage = () => {
    switch (currentPage) {
      case "Departments":
        return <Departments />;
      // Add cases for other pages as needed
      default:
        return <>test</>;
    }
  };

  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/sign_up" element={<SignUp />} />
          <Route path="/login" element={<Login />} />
          <Route path="/" element={<Feed />} />
          <Route path="/home" element={<Feed />} />
          <Route path="/feed" element={<Feed />} />
          <Route path="/professors" element={<ProfessorsFeed />} />
          <Route path="/professors/:professorId" element={<ProfessorDetail />} />
          <Route path="/rate-professor/:professorId" element={<RateProfessor />} />
          <Route path="/departments" element={<Departments />} />
          <Route path="/courses" element={<Courses />} />
          <Route path="/courses/detail/:courseName" element={<CourseDetail />} />
          <Route path="*" element={<NotFound />} />
          <Route path="/profile" element={<PersonalProfile />} /> 
        </Routes>
      </BrowserRouter>
      
    </div>
  );
}

export default App;
