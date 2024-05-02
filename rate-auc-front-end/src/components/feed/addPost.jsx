import React, { useState } from "react";
import { Box } from "@mui/material";
import Post from "./post";
import { CardContent, TextField } from "@mui/material";

export default function AddPost({ posts, updatePosts }) {
  // console.log("posts", posts);
  const [postText, setPostText] = useState("");
  const handleNewPost = async () => {
    try {
      const response = await fetch(
        `http://localhost:5243/api/Feed/add?userId=1dba6f65-3475-41e4-ac8c-9a015dcf9e0c`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            content: postText,
          }),
        }
      );

      if (response.ok) {
        console.log("Reply posted successfully");
        let newPost = await response.json();
        newPost = newPost.data;
        // console.log("newPost", newPost);
        newPost.userName = "Jane Doe";
        newPost.likes = 0;
        newPost.dislikes = 0;
        newPost.comments = [];
        updatePosts([
          ...posts,
          <Post key={newPost.id} post={newPost} userColors={{}} />,
        ]);
        setPostText("");
      } else {
        console.error("Failed to post reply:", response.statusText);
      }
    } catch (error) {
      console.error("Failed to post reply:", error.message);
    }
  };
  const handlePostChange = (event) => {
    setPostText(event.target.value);
  };
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
      <CardContent sx={{ width: "100%" }}>
        <TextField
          id="Post-text"
          label="Add a new post?"
          multiline
          rows={3}
          variant="outlined"
          value={postText}
          onChange={handlePostChange}
          fullWidth
          sx={{ mb: 1 }}
        />
        <div style={{ display: "flex", justifyContent: "center" }}>
          <button className="custom-button" onClick={handleNewPost}>
            Add Post
          </button>
        </div>
      </CardContent>
    </Box>
  );
}
