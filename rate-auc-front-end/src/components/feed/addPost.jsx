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
        `http://localhost:5243/api/Feed/add?userId=2b6136fe-6763-4e16-b9f9-589334ab248c`,
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
        console.log("Post added successfully");
        let newPost = await response.json();
        newPost = newPost.data;
        // console.log("newPost", newPost);

        const userId = newPost.userId;
        const userResponse = await fetch(
          `http://localhost:5243/api/Authentication/get-by-id/${userId}`
        );
        const userData = await userResponse.json();
        newPost.userName = userData.data.email;
        newPost.likes = 0;
        newPost.dislikes = 0;
        newPost.comments = [];
        updatePosts([...posts, <Post key={newPost.id} post={newPost} />]);
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
