import React from 'react';

const user = {
    image: 'user-image-url.jpg',
    fullName: 'Nour Elewah Selim',
    email: 'nourselim@aucegypt.edu',
    birthdate: '6th January, 2004',
    classStanding: 'Junior',
    major: 'Computer engineering',
    minor: 'Mathematics'
  };

export default function Profile({user}) {
   
  return (
        <div className="profile-container">
        <div className="user-image">
        <img src={user.image} alt="User" />
        </div>
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
        <button className="edit-button">Update Information</button>

        </div>
        </div>
    )
}
