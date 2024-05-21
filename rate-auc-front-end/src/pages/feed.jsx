import React, { useState, useEffect } from "react";
import { Box } from "@mui/material";
import NavBar from "../components/NavBar";
import "../components/feed/feed.css";
import Post from "../components/feed/post";
import AddPost from "../components/feed/addPost";

export default function Feed() {
  let colors = ["#6171BA", "#218B8B", "#EF8CCB", "#31B0CD", "#A083C9"];
  function getRandomColor() {
    return colors[Math.floor(Math.random() * colors.length)];
  }
  const [updatedPosts, setUpdatedPosts] = useState([]);
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
  const currToken =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmN2RmNWY3NS0xMmNhLTQ0MGUtYmYwYi1kNWY2MDZjYmQwMzkiLCJleHAiOjE3MTYxNTY3NjQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCJ9.S9D-5q95LQ5eeht49WoUsPY5wOTQSGBoNt0tKa4SWzs";

  // const YOUR_TOKEN =
  //   "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmN2RmNWY3NS0xMmNhLTQ0MGUtYmYwYi1kNWY2MDZjYmQwMzkiLCJleHAiOjE3MTYxOTEwODcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCJ9.ZwwgXHUqA27xqle5jYkVnQ24V-TJtJYMw2_ch1xEkb0";
  const YOUR_TOKEN = localStorage.getItem("authToken");
  const fetchData = async () => {
    try {
      // Fetch all posts
      const postsResponse = await fetch(
        "http://localhost:5243/api/Feed/get-all",
        {
          headers: {
            Authorization: `Bearer ${YOUR_TOKEN}`,
          },
        }
      );
      if (!postsResponse.ok) {
        throw new Error("Failed to fetch posts data");
      }
      const postsData = await postsResponse.json();
      let posts = postsData.data;

      // Fetch additional data for each post
      const updatedPostsData = await Promise.all(
        posts.map(async (post) => {
          // Fetch user name for the post author
          const authorResponse = await fetch(
            `http://localhost:5243/api/Authentication/get-by-id/${post.userId}`,
            {
              headers: {
                Authorization: `Bearer ${YOUR_TOKEN}`,
              },
            }
          );
          const authorData = await authorResponse.json();
          // console.log("user: ", authorData);
          const userName = authorData.data.email;
          const postUserColor = authorData.data.color;
          // console.log("postUserColor", postUserColor);

          // Fetch reactions for the post
          const reactionsResponse = await fetch(
            `http://localhost:5243/api/Reaction/get-all-reactions-by-feedId/${post.id}`,
            {
              headers: {
                Authorization: `Bearer ${YOUR_TOKEN}`,
              },
            }
          );
          const reactionsData = await reactionsResponse.json();
          const postReactions = reactionsData.status ? reactionsData.data : [];
          // Count number of likes and dislikes for the post
          let postLikes = 0;
          let postDislikes = 0;
          postReactions.forEach((reaction) => {
            if (reaction.isLike) {
              postLikes++;
            } else {
              postDislikes++;
            }
          });

          // Fetch comments for the post
          const commentsResponse = await fetch(
            `http://localhost:5243/api/Comment/get-all-comments-by-feedId/${post.id}`,
            {
              headers: {
                Authorization: `Bearer ${YOUR_TOKEN}`,
              },
            }
          );
          const commentsData = await commentsResponse.json();
          let comments = commentsData.data;

          // Fetch additional data for each comment
          const updatedComments = await Promise.all(
            comments.map(async (comment) => {
              // Fetch user name for the comment author
              const commentAuthorResponse = await fetch(
                `http://localhost:5243/api/Authentication/get-by-id/${comment.userId}`,
                {
                  headers: {
                    Authorization: `Bearer ${YOUR_TOKEN}`,
                  },
                }
              );
              const commentAuthorData = await commentAuthorResponse.json();
              const commentuserName = commentAuthorData.data.email;
              const commentUserColor = commentAuthorData.data.color;
              // console.log("commentUserColor", commentUserColor);
              // Fetch reactions for the comment
              const commentReactionsResponse = await fetch(
                `http://localhost:5243/api/Reaction/get-all-reactions-by-commentId/${comment.id}`,
                {
                  headers: {
                    Authorization: `Bearer ${YOUR_TOKEN}`,
                  },
                }
              );
              const commentReactionsData =
                await commentReactionsResponse.json();
              const commentReactions = commentReactionsData.status
                ? commentReactionsData.data
                : [];
              // Count number of likes and dislikes for the comment
              let commentLikes = 0;
              let commentDislikes = 0;
              commentReactions.forEach((reaction) => {
                if (reaction.isLike) {
                  commentLikes++;
                } else {
                  commentDislikes++;
                }
              });

              // Fetch replies for the comment
              const repliesResponse = await fetch(
                `http://localhost:5243/api/Reply/get-all-replys-by-commentId/${comment.id}`,
                {
                  headers: {
                    Authorization: `Bearer ${YOUR_TOKEN}`,
                  },
                }
              );
              const repliesData = await repliesResponse.json();
              let replies = repliesData.data;

              // Fetch additional data for each reply
              const updatedReplies = await Promise.all(
                replies.map(async (reply) => {
                  // Fetch user name for the reply author
                  const replyAuthorResponse = await fetch(
                    `http://localhost:5243/api/Authentication/get-by-id/${reply.userId}`,
                    {
                      headers: {
                        Authorization: `Bearer ${YOUR_TOKEN}`,
                      },
                    }
                  );
                  const replyAuthorData = await replyAuthorResponse.json();
                  const replyuserName = replyAuthorData.data.email;
                  const replyUserColor = replyAuthorData.data.color;

                  // Fetch reactions for the reply
                  const replyReactionsResponse = await fetch(
                    `http://localhost:5243/api/Reaction/get-all-reactions-by-replyId/${reply.id}`,
                    {
                      headers: {
                        Authorization: `Bearer ${YOUR_TOKEN}`,
                      },
                    }
                  );
                  const replyReactionsData =
                    await replyReactionsResponse.json();
                  const replyReactions = replyReactionsData.status
                    ? replyReactionsData.data
                    : [];
                  // Count number of likes and dislikes for the reply
                  let replyLikes = 0;
                  let replyDislikes = 0;
                  replyReactions.forEach((reaction) => {
                    if (reaction.isLike) {
                      replyLikes++;
                    } else {
                      replyDislikes++;
                    }
                  });

                  return {
                    ...reply,
                    userName: replyuserName,
                    likes: replyLikes,
                    dislikes: replyDislikes,
                    color: replyUserColor,
                  };
                })
              );

              return {
                ...comment,
                userName: commentuserName,
                likes: commentLikes,
                dislikes: commentDislikes,
                replies: updatedReplies,
                color: commentUserColor,
              };
            })
          );

          return {
            ...post,
            userName: userName,
            likes: postLikes,
            dislikes: postDislikes,
            comments: updatedComments,
            color: postUserColor,
          };
        })
      );

      // console.log("Updated Posts:", updatedPostsData);
      const updatedPostComponents = updatedPostsData.map((post) => (
        <Post key={post.id} post={post} />
      ));
      setUpdatedPosts(updatedPostComponents);
      // console.log("updated posts:", updatedPosts);
    } catch (error) {
      console.error("Error:", error.message);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

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
                marginBottom: "500px",
              }}
            >
              {updatedPosts}
            </div>
          </Box>
          <AddPost posts={updatedPosts} updatePosts={setUpdatedPosts} />
        </div>
      </div>
    </>
  );
}
