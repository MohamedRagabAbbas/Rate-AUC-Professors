import React from "react";
import { Box } from "@mui/material";

export default function AddPost() {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        position: "fixed",
        bottom: "0px",
        mt: 2,
        zIndex: 999,
        backgroundColor: "white",
        left: "50%",
        transform: "translateX(-50%)",
        width: "800px",
        padding: "20px",
        borderRadius: "8px",
      }}
    >
      <textarea
        placeholder="Add a new post?"
        style={{
          width: "100%",
          minHeight: "100px",
          padding: "10px",
          borderRadius: "4px",
          border: "1px solid #ccc",
          resize: "vertical",
          marginBottom: "10px",
          fontFamily: "SF Pro Display Light",
          fontSize: "1.02rem",
        }}
      />
      <div style={{ display: "flex", flexDirection: "row" }}>
        {/* Input for uploading images */}
        <label htmlFor="file-upload" className="custom-file-label">
          Choose file
        </label>
        <input
          id="file-upload"
          type="file"
          className="custom-file-input"
          accept="image/*"
          style={{
            display: "none", // Hide the input element
          }}
          // onChange={(e) => handleFileUpload(e.target.files)}
        />
        {/* Add a button or action to submit the post */}
        <button className="custom-button">Post</button>
      </div>
    </Box>
  );
}
