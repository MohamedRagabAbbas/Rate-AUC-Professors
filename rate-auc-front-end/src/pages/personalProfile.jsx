import React, { useState } from 'react';
import Profile from "../components/userProfile/profile";
import EditUserProfile from "../components/userProfile/editUserProfile"; 
import "../components/userProfile/userProfile.css";
import NavBar from "../components/NavBar";

export const PersonalProfile = () => {
  const [isEditing, setIsEditing] = useState(false); // State to manage editing mode

  const handleToggleEditing = () => {
    setIsEditing(!isEditing); // Toggle editing mode

  };

  return (
    <div>
      <NavBar />
      {isEditing ? (
        <EditUserProfile onCancel={handleToggleEditing} onSave={(editedUser) => {
          console.log("Saved changes", editedUser);
          handleToggleEditing(); 
        }} />
      ) : (
        <div>
          <Profile />
          <button onClick={handleToggleEditing}>Edit Information</button>
        </div>
      )}
    </div>
  );
}
