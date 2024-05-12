import React, { useState } from 'react';

export default function EditUserProfile({ user, onSave, onCancel }) {
  const [editedUser, setEditedUser] = useState({ ...user });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedUser({ ...editedUser, [name]: value });
  };

  const handleSubmit = () => {
    onSave(editedUser);
  };

  return (
    <div className="profile-container">
      <h1>Edit Information</h1>
      {/* <div className="info-box-editing">
        <div className="info-title">
          <label><strong>Full Name:</strong></label>
        </div>
        <input
          type="text"
          name="fullName"
          value={editedUser.fullName}
          onChange={handleChange}
        />
      </div>
      <div className="info-box-editing">
        <div className="info-title">
          <label><strong>Birthdate:</strong></label>
        </div>
        <input
          type="text"
          name="birthdate"
          value={editedUser.birthdate}
          onChange={handleChange}
        />
      </div> */}
      <div className="info-box-editing">
        <div className="info-title">
          <label><strong>Class Standing:</strong></label>
        </div>
        <input
          type="text"
          name="classStanding"
          value={editedUser.classStanding}
          onChange={handleChange}
        />
      </div>
      <div className="info-box-editing">
        <div className="info-title">
          <label><strong>Graduation Year:</strong></label>
        </div>
        <input
          type="text"
          name="graduationYear"
          value={editedUser.major}
          onChange={handleChange}
        />
      </div>
      <div className="info-box-editing">
        <div className="info-title">
          <label><strong>Phone Number:</strong></label>
        </div>
        <input
          type="text"
          name="phoneNumber"
          value={editedUser.phoneNumber}
          onChange={handleChange}
        />
      </div>
      <button className="edit-button" onClick={handleSubmit}>Submit Changes</button>
      <button className="edit-button" onClick={onCancel}>Cancel</button>
    </div>
  );
};
