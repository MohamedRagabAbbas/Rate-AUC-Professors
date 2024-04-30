import React, { useState, useEffect } from "react";
import { Box } from "@mui/material";
import NavBar from "../components/NavBar";
import "../components/feed/feed.css";
import Post from "../components/feed/post";
import AddPost from "../components/feed/addPost";

export default function Feed() {
  let colors = ["#6171BA", "#218B8B", "#EF8CCB", "#31B0CD", "#A083C9"];
  const [userColors, setUserColors] = useState({});
  function getRandomColor() {
    return colors[Math.floor(Math.random() * colors.length)];
  }

  let posts = [
    {
      id: 1,
      user: "John Doe",
      userId: 1,
      content:
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
      likes: 5,
      dislikes: 1,
      datePosted: "September 14, 2016",
      comments: [
        {
          id: 1,
          user: "Jane Dae",
          userId: 2,
          content: "I agree with this post!",
          likes: 2,
          dislikes: 0,
          commentId: 1,
          datePosted: "September 14, 2016",
          replies: [
            {
              id: 1,
              user: "Scott Something",
              userId: 3,
              content: "I agree with this comment!",
              likes: 2,
              dislikes: 0,
              datePosted: "September 14, 2016",
            },
            {
              id: 2,
              user: "Emilia Clarke",
              userId: 4,
              content: "I agree with this comment!",
              likes: 2,
              dislikes: 0,
              datePosted: "September 14, 2016",
            },
          ],
        },
      ],
    },
    {
      id: 2,
      user: "Harry Potter",
      userId: 5,
      content: "This is another post",
      likes: 2,
      dislikes: 0,
      datePosted: "September 14, 2016",
      comments: [],
    },
  ];

  useEffect(() => {
    let userColors = {};
    posts.forEach((post) => {
      if (!userColors[post.userId]) {
        userColors[post.userId] = getRandomColor();
      }
      post.comments.forEach((comment) => {
        if (!userColors[comment.userId]) {
          userColors[comment.userId] = getRandomColor();
        }
        comment.replies.forEach((reply) => {
          if (!userColors[reply.userId]) {
            userColors[reply.userId] = getRandomColor();
          }
        });
      });
    });
    setUserColors(userColors);
  }, []);

  const renderPosts = () => {
    console.log("posts", posts);
    return posts.map((post) => (
      <Post key={post.id} post={post} userColors={userColors} />
    ));
  };

  return (
    <>
      <NavBar />
      <div
        style={{
          width: "800px",
          margin: "auto",
          // paddingTop: "50px",
        }}
      >
        <div>
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              margin: "0 auto", // Center horizontally
              mt: 2, // Add some top margin
              zIndex: 0,
              marginBottom: "200px",
            }}
          >
            <div
              style={{
                position: "relative",
                height: "400px",
                marginBottom: "500px",
              }}
            >
              {renderPosts()}
            </div>
          </Box>
          <AddPost />
        </div>
      </div>
    </>
  );
}
