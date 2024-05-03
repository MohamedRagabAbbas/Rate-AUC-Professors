import React, { useState } from 'react';

export default function EditUserProfile  ({ user, onSave, onCancel }) {
  const [editedUser, setEditedUser] = useState({ ...user });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedUser({ ...editedUser, [name]: value });
  };

  const handleSubmit = () => {
    onSave(editedUser);
  };

  return (
    <div>
      <h1>Edit Information</h1>
      <div>
        <label>Full Name:</label>
        <input
          type="text"
          name="fullName"
          value={editedUser.fullName}
          onChange={handleChange}
        />
      </div>
      <div>
        <label>Birthdate:</label>
        <input
          type="text"
          name="birthdate"
          value={editedUser.birthdate}
          onChange={handleChange}
        />
      </div>
      <div>
        <label>Class Standing:</label>
        <input
          type="text"
          name="classStanding"
          value={editedUser.classStanding}
          onChange={handleChange}
        />
      </div>
      <div>
        <label>Major:</label>
        <input
          type="text"
          name="major"
          value={editedUser.major}
          onChange={handleChange}
        />
      </div>
      <div>
        <label>Minor:</label>
        <input
          type="text"
          name="minor"
          value={editedUser.minor}
          onChange={handleChange}
        />
      </div>
      <button onClick={handleSubmit}>Submit Changes</button>
      <button onClick={onCancel}>Cancel</button>
    </div>
  );
};

