import React from 'react';



export default function Profile({user, onEditButtonClick }) {
   
  return (
        <div className="profile-container">
        
        <div className="user-info">
        <h1>{user.fullName}</h1>
        <div className="info-box">
            <h2>Email</h2>
            <div className="info">{user.email}</div>
        </div>
        <div className="info-box">
            <h2>AUC ID</h2>
            <div className="info">{user.aucID}</div>
        </div>
        <div className="info-box">
            <h2>Phone Number</h2>
            <div className="info">{user.phoneNumber}</div>
        </div>
        <div className="info-box">
            <h2>Class Standing</h2>
            <div className="info">{user.classStanding}</div>
        </div>
        <div className="info-box">
            <h2>Graduation Year</h2>
            <div className="info">{user.graduationYear}</div>
        </div>
        <div className="info-box">
            <h2>Major</h2>
            <div className="info">{user.major}</div>
        </div>
        <button className="edit-button-profile" onClick={onEditButtonClick}>
          Update Information
        </button>
        </div>
        </div>
    )
}
