import React, { useState } from 'react';
import Profile from "../components/userProfile/profile";
import EditUserProfile from "../components/userProfile/editUserProfile"; 
import "../components/userProfile/userProfile.css";
import NavBar from "../components/NavBar";
import { useNavigate } from 'react-router-dom';

export default function PersonalProfile  () {
  const [isEditing, setIsEditing] = useState(false); // State to manage editing mode
  const navigate = useNavigate();
  const user = {
    image: 'user-image-url.jpg',
    fullName: 'Nour Elewah Selim',
    email: 'nourselim@aucegypt.edu',
    birthdate: '6th January, 2004',
    classStanding: 'Junior',
    major: 'Computer engineering',
    minor: 'Mathematics'
  };

  const handleToggleEditing = () => {
    setIsEditing(!isEditing); // Toggle editing mode
  };

  const handleUpdateInformation = (editedUser) => {
    console.log("Updated user information", editedUser);
    setIsEditing(false); // Close editing mode
  };

  return (
    <div>
      <NavBar />
      {isEditing ? (
        <EditUserProfile 
          user={user} 
          onSave={handleUpdateInformation} 
          onCancel={handleToggleEditing} 
        />
      ) : (
        <div>
          <Profile user={user} onEditButtonClick={handleToggleEditing} />
        </div>
      )}
    </div>
  );
}
