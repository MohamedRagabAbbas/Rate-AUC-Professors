import React, { useState, useEffect } from 'react';
import Profile from "../components/userProfile/profile";
import EditUserProfile from "../components/userProfile/editUserProfile"; 
import "../components/userProfile/userProfile.css";
import NavBar from "../components/NavBar";
import { useNavigate } from 'react-router-dom';

export default function PersonalProfile() {
  const [user, setUser] = useState(null);
  const [isEditing, setIsEditing] = useState(false); 
  const navigate = useNavigate();

  useEffect(() => {
    fetchData(); 
  }, []);

  const fetchData = async () => {
    try {
      // Scott Something
      const id = '1dba6f65-3475-41e4-ac8c-9a015dcf9e0c';
      // Testing
      const response = await fetch(`http://localhost:5243/api/Authentication/get-by-id/${id}`);
      //const response = await fetch(`http://localhost:5243/api/Authentication/get-by-id`);

      if (!response.ok) {
        throw new Error('Failed to fetch user data');
      }
      
      const responseData = await response.json();
      const userData = responseData.data;

      const formattedUser = {
        email: userData.userName,
        aucID: userData.student_Id,
        phoneNumber: userData.phoneNumber, 
        classStanding: userData.standing,
        //major: userData.majors,
        fullName: `${userData.firstName} ${userData.lastName}`,
        graduationYear: userData.graduationYear, 
      };
        
      setUser(formattedUser);
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  const handleToggleEditing = () => {
    setIsEditing(!isEditing);
  };

  
  // const handleUpdateInformation = async (editedUser) => {
  //   try {
  //     const id = '9741f712-10d2-41d4-a10e-853283e3ada3';
  //     // Testing
  //     const response = await fetch(`http://localhost:5243/api/Authentication/update/${id}`, {
  //     //const response = await fetch(`http://localhost:5243/api/Authentication/update/${user.id}`,
  //       method: 'PUT',
  //       headers: {
  //         'Content-Type': 'application/json',
  //       },
  //       body: JSON.stringify({
  //         standing: editedUser.classStanding, // Update standing
  //         majors: editedUser.major, // Update major
  //       }),
  //     });
      
  //     if (!response.ok) {
  //       throw new Error('Failed to update user information');
  //     }
      
  //     setIsEditing(false);
  //     fetchData();
  //   } catch (error) {
  //     console.error('Error updating user information:', error);
  //   }
  // };
  const handleUpdateInformation = async (editedUser) => {
    try {
      // Fetch the existing user data for Scott Something 
      const id = '1dba6f65-3475-41e4-ac8c-9a015dcf9e0c';

      const response = await fetch(`http://localhost:5243/api/Authentication/get-by-id/${id}`);
      if (!response.ok) {
        throw new Error('Failed to fetch user data for update');
      }
      
      const responseData = await response.json();
      const existingUserData = responseData.data;
  
      // Create a new user object with the updated standing and major fields,
      // while preserving the rest of the existing user data
      const updatedUserData = {
        ...existingUserData,
        standing: editedUser.classStanding, // Update standing
        //majors: editedUser.major, // Update major
        phoneNumber: editedUser.phoneNumber, 
        graduationYear: editedUser.graduationYear,
      };
  
      // Send the updated user data to the backend for update
      const updateResponse = await fetch(`http://localhost:5243/api/Authentication/update/${id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedUserData),
      });
  
      if (!updateResponse.ok) {
        throw new Error('Failed to update user information');
      }
      
      setIsEditing(false);
      fetchData(); // Fetch updated user data
    } catch (error) {
      console.error('Error updating user information:', error);
    }
  };
  
  return (
    <div>
      <NavBar />
      {user ? (
        isEditing ? (
          <EditUserProfile 
            user={user} 
            onSave={handleUpdateInformation} 
            onCancel={handleToggleEditing} 
          />
        ) : (
          <Profile 
            user={user} 
            onEditButtonClick={handleToggleEditing} 
          />
        )
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
}


//////////////////////////////////////////////////////////////////////////////////without backend
// import React, { useState } from 'react';
// import Profile from "../components/userProfile/profile";
// import EditUserProfile from "../components/userProfile/editUserProfile"; 
// import "../components/userProfile/userProfile.css";
// import NavBar from "../components/NavBar";
// import { useNavigate } from 'react-router-dom';

// export default function PersonalProfile  () {
//   const [isEditing, setIsEditing] = useState(false); // State to manage editing mode
//   const navigate = useNavigate();
//  const user = {
//     image: 'user-image-url.jpg',
//     fullName: 'Nour Elewah Selim',
//     aucID: '900211928', 
//     phoneNumber: '01222280852', 
//     email: 'nourselim@aucegypt.edu',
//     classStanding: 'Junior',
//     major: 'Computer engineering',
//     minor: 'Mathematics'
//   };

//   const handleToggleEditing = () => {
//     setIsEditing(!isEditing); // Toggle editing mode
//   };

//   const handleUpdateInformation = (editedUser) => {
//     console.log("Updated user information", editedUser);
//     setIsEditing(false); // Close editing mode
//   };


//   return (
//     <div>
//       <NavBar />
//       {isEditing ? (
//         <EditUserProfile 
//           user={user} 
//           onSave={handleUpdateInformation} 
//           onCancel={handleToggleEditing} 
//         />
//       ) : (
//         <div>
//           <Profile user={user} onEditButtonClick={handleToggleEditing} />
//         </div>
//       )}
//     </div>
//   );
// }