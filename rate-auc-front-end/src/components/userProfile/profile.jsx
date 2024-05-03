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
            <h2>Birthdate</h2>
            <div className="info">{user.birthdate}</div>
        </div>
        <div className="info-box">
            <h2>Class Standing</h2>
            <div className="info">{user.classStanding}</div>
        </div>
        <div className="info-box">
            <h2>Major</h2>
            <div className="info">{user.major}</div>
        </div>
        <div className="info-box">
            <h2>Minor</h2>
            <div className="info">{user.minor}</div>
        </div>
        <button className="edit-button-profile" onClick={onEditButtonClick}>
          Update Information
        </button>
        </div>
        </div>
    )
}
