// import React, { useState, useEffect } from 'react';
// import Profile from "../components/userProfile/profile";
// import EditUserProfile from "../components/userProfile/editUserProfile"; 
// import "../components/userProfile/userProfile.css";
// import NavBar from "../components/NavBar";
// import { useNavigate } from 'react-router-dom';

// export default function PersonalProfile() {
//   const [user, setUser] = useState(null);
//   const [isEditing, setIsEditing] = useState(false); 
//   const navigate = useNavigate();

//   // const user = {
//   //   image: 'user-image-url.jpg',
//   //   fullName: 'Nour Elewah Selim',
//   //   email: 'nourselim@aucegypt.edu',
//   //   birthdate: '6th January, 2004',
//   //   classStanding: 'Junior',
//   //   major: 'Computer engineering',
//   //   minor: 'Mathematics'
//   // };


//   useEffect(() => {
//     fetchData(); 
//   }, []);

//   const fetchData = async () => {
//     try {
//       const response = await fetch('http://localhost:5243/api/Student/get-all');
//       if (!response.ok) {
//         throw new Error("Failed to fetch user data");
//       }
//       const userData = await response.json();
//       setUser(userData);
//     } catch (error) {
//       console.error('Error fetching user data:', error);
//     }
//   };

//   const handleToggleEditing = () => {
//     setIsEditing(!isEditing);
//   };

//   const handleUpdateInformation = async (editedUser) => {
//     try {
//       const response = await fetch('http://localhost:5243/api/Student/update', {
//         method: 'PUT',
//         headers: {
//           'Content-Type': 'application/json',
//         },
//         body: JSON.stringify(editedUser),
//       });
//       if (!response.ok) {
//         throw new Error('Failed to update user information');
//       }
//       setIsEditing(false); // Exit editing mode
//       fetchData(); // Fetch updated user data
//     } catch (error) {
//       console.error('Error updating user information:', error);
//     }
//   };

//   return (
//     <div>
//       <NavBar />
//       {user ? (
//         isEditing ? (
//           <EditUserProfile 
//             user={user} 
//             onSave={handleUpdateInformation} 
//             onCancel={handleToggleEditing} 
//           />
//         ) : (
//           <Profile 
//             user={user} 
//             onEditButtonClick={handleToggleEditing} 
//           />
//         )
//       ) : (
//         <p>Loading...</p>

//         // <div>
//         //   <Profile user={user} onEditButtonClick={handleToggleEditing} />
//         // </div>
//       )}
//     </div>
//   );
// }

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