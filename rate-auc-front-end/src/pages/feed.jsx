import React, { useState, useEffect } from "react";
// import data from "../assets/feedPosts.json";
import {
  Typography,
  Card,
  Box,
  CardHeader,
  Avatar,
  IconButton,
  CardContent,
  CardActions,
} from "@mui/material";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import CommentIcon from "@mui/icons-material/Comment";
import ThumbDownIcon from "@mui/icons-material/ThumbDown";
import TextField from "@mui/material/TextField";
import NavBar from "../components/NavBar";
import "../index.css";

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

  const [expandedPostId, setExpandedPostId] = useState(null);

  const toggleComments = (postId) => {
    setExpandedPostId(postId === expandedPostId ? null : postId);
  };

  const renderReplies = (replies) => {
    return replies.map((reply) => (
      <Card
        key={reply.id}
        sx={{
          ml: 20,
          // width: "100%",
          display: "flex",
          justifyContent: "center",
          flexDirection: "column",
          mb: 0.75,
          boxShadow: "0",
          // backgroundColor: "rgba(239, 140, 203, 0.3)",
          backgroundColor: "rgba(156,128,196, 0.3)",
          borderRadius: "15px",
        }}
      >
        {/* Render reply content */}
        <CardHeader
          avatar={
            // background color corresponding to state
            <Avatar sx={{ bgcolor: userColors[reply.userId] }}>
              {reply.user[0]}
            </Avatar>
          }
          title={reply.user}
          subheader={reply.datePosted}
        />
        <CardContent sx={{ py: 0.4 }}>
          <Typography
            variant="body2"
            color="text.secondary"
            sx={{ fontFamily: "SF Pro Display Light", fontSize: "1.05rem" }}
          >
            {reply.content}
          </Typography>
        </CardContent>
        <CardActions disableSpacing>
          <IconButton aria-label="like post">
            <ThumbUpIcon />
          </IconButton>
          <Typography sx={{ color: "#808080", fontSize: "2" }}>
            {reply.likes}
          </Typography>
          <IconButton aria-label="dislike post">
            <ThumbDownIcon />
          </IconButton>
          <Typography sx={{ color: "#808080", fontSize: "2" }}>
            {reply.dislikes}
          </Typography>
          <IconButton aria-label="comment">
            {/* <CommentIcon /> */}
            <Typography sx={{ color: "#808080", fontSize: "2" }}>
              Reply
            </Typography>
          </IconButton>
        </CardActions>
      </Card>
    ));
  };

  const renderComments = (comments) => {
    return comments.map((comment) => (
      <div>
        <Card
          key={comment.id}
          sx={{
            ml: 10,
            // width: 750,
            display: "flex",
            justifyContent: "center",
            flexDirection: "column",
            mb: 0.75,
            paddingBottom: 0.75,
            boxShadow: "0",
            // backgroundColor: "rgba(239, 140, 203, 0.3)",
            backgroundColor: "rgba(156,128,196, 0.5)",
            borderRadius: "15px",
          }}
        >
          {/* Render comment content */}
          <CardHeader
            avatar={
              <Avatar sx={{ bgcolor: userColors[comment.userId] }}>
                {comment.user[0]}
              </Avatar>
            }
            title={comment.user}
            subheader={comment.datePosted}
          />
          <CardContent sx={{ py: 0.4 }}>
            <Typography
              variant="body2"
              color="text.secondary"
              sx={{ fontFamily: "SF Pro Display Light", fontSize: "1.05rem" }}
            >
              {comment.content}
            </Typography>
          </CardContent>
          <CardActions disableSpacing>
            <IconButton aria-label="like post">
              <ThumbUpIcon />
            </IconButton>
            <Typography sx={{ color: "#808080", fontSize: "2" }}>
              {comment.likes}
            </Typography>
            <IconButton aria-label="dislike post">
              <ThumbDownIcon />
            </IconButton>
            <Typography sx={{ color: "#808080", fontSize: "2" }}>
              {comment.dislikes}
            </Typography>
            <IconButton aria-label="comment">
              {/* <CommentIcon /> */}
              <Typography sx={{ color: "#808080", fontSize: "2" }}>
                Reply
              </Typography>
            </IconButton>
          </CardActions>
          {/* Replies */}
        </Card>
        {renderReplies(comment.replies)}
      </div>
    ));
  };

  const renderPosts = () => {
    return posts.map((post) => (
      <div key={post.id} style={{ borderBottom: "1px solid #909090" }}>
        <Card
          sx={{
            width: "100%",
            display: "flex",
            justifyContent: "center",
            flexDirection: "column",
            // mb: 0.75,
            paddingBottom: 1,
            boxShadow: "0",
          }}
        >
          <CardHeader
            avatar={
              <Avatar sx={{ bgcolor: userColors[post.userId] }}>
                {post.user[0]}
              </Avatar>
            }
            title={post.user}
            subheader={post.datePosted}
            sx={{ fontFamily: "SF Pro Display Light" }}
          />
          <CardContent sx={{ py: 0.5 }}>
            <Typography
              variant="body2"
              color="text.secondary"
              sx={{ fontFamily: "SF Pro Display Light", fontSize: "1.05rem" }}
            >
              {post.content}
            </Typography>
          </CardContent>
          <CardActions disableSpacing>
            <IconButton aria-label="like post">
              <ThumbUpIcon />
            </IconButton>
            <Typography sx={{ color: "#808080", fontSize: "2" }}>
              {post.likes}
            </Typography>
            <IconButton aria-label="dislike post">
              <ThumbDownIcon />
            </IconButton>
            <Typography sx={{ color: "#808080", fontSize: "2" }}>
              {post.dislikes}
            </Typography>
            <IconButton
              aria-label="comment"
              sx={{ ml: "auto" }}
              onClick={() => toggleComments(post.id)}
            >
              <CommentIcon />
            </IconButton>
          </CardActions>
        </Card>
        {/* Render expanded comments if post is expanded */}
        {expandedPostId === post.id && renderComments(post.comments)}
      </div>
    ));
  };

  return (
    <>
      <NavBar />
      <div
        style={{
          width: "800px",
          margin: "auto",
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
                // overflowY: "auto",
              }}
            >
              {renderPosts()}
            </div>
          </Box>
          <Box
            sx={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              position: "fixed",
              bottom: "10px",
              mt: 2, // Add some top margin
              zIndex: 999,
              backgroundColor: "white",
              left: "50%",
              transform: "translateX(-50%)",
              width: "800px",
              padding: "20px",
              // boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.1)",
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
                // change the border color when text area is clicked on
                // ":focus": {
                //   border: "1px solid red",
                // },
              }}
            />
            <div style={{ display: "flex", flexDirection: "row" }}>
              {/* Input for uploading images */}
              <label htmlFor="file-upload" className="custom-file-label">
                Choose file
              </label>
              <input
                type="file"
                className="custom-file-input"
                accept="image/*"
                style={{
                  marginBottom: "10px",
                  fontFamily: "SF Pro Display Light",
                }}
              />
              {/* Add a button or action to submit the post */}
              <button className="custom-button">Post</button>
            </div>
          </Box>
        </div>
      </div>
    </>
  );
}

// SAME PAGE BUT WITH NESTED COMPONENTS FOR COMMENTS AND REPLIES
// export default function Feed() {
//   let [showComments, setShowComments] = useState({});
//   let posts = [
//     {
//       id: 1,
//       user: "John Doe",
//       content:
//         "Lorem ipsum dolor sit amet, consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
//       likes: 5,
//       dislikes: 1,
//       datePosted: "September 14, 2016",
//       comments: [
//         {
//           id: 1,
//           user: "Jane Doe",
//           content: "I agree with this post!",
//           likes: 2,
//           dislikes: 0,
//           commentId: 1,
//           datePosted: "September 14, 2016",
//           replies: [
//             {
//               id: 1,
//               user: "Scott Something",
//               content: "I agree with this comment!",
//               likes: 2,
//               dislikes: 0,
//               datePosted: "September 14, 2016",
//             },
//             {
//               id: 2,
//               user: "Emilia Clarke",
//               content: "I agree with this comment!",
//               likes: 2,
//               dislikes: 0,
//               datePosted: "September 14, 2016",
//             },
//           ],
//         },
//       ],
//     },
//     {
//       id: 2,
//       user: "Jane Doe",
//       content: "This is another post",
//       likes: 2,
//       dislikes: 0,
//       datePosted: "September 14, 2016",
//       comments: [],
//     },
//   ];

//   const toggleComments = (postId) => {
//     setShowComments((prev) => ({ ...prev, [postId]: !prev[postId] }));
//   };

//   const renderReplies = (replies) => {
//     return replies.map((reply) => (
//       <Card
//         key={reply.id}
//         sx={{
//           ml: 2,
//           width: 700,
//           display: "flex",
//           justifyContent: "center",
//           flexDirection: "column",
//           mb: 0.75,
//           boxShadow: "0",
//           backgroundColor: "rgba(239, 140, 203, 0.3)",
//         }}
//       >
//         <CardHeader
//           avatar={<Avatar sx={{ bgcolor: "#7389ea" }}>{reply.user[0]}</Avatar>}
//           title={reply.user}
//           subheader={reply.datePosted}
//         />
//         <CardContent sx={{ py: 0.4 }}>
//           <Typography
//             variant="body2"
//             color="text.secondary"
//             sx={{ fontFamily: "SF Pro Display Light", fontSize: "1.05rem" }}
//           >
//             {reply.content}
//           </Typography>
//         </CardContent>
//         <CardActions disableSpacing>
//           <IconButton aria-label="like post">
//             <ThumbUpIcon />
//           </IconButton>
//           <Typography sx={{ color: "#808080", fontSize: "2" }}>
//             {reply.likes}
//           </Typography>
//           <IconButton aria-label="dislike post">
//             <ThumbDownIcon />
//           </IconButton>
//           <Typography sx={{ color: "#808080", fontSize: "2" }}>
//             {reply.dislikes}
//           </Typography>
//           <IconButton aria-label="comment">
//             {/* <CommentIcon /> */}
//             <Typography sx={{ color: "#808080", fontSize: "2" }}>
//               Reply
//             </Typography>
//           </IconButton>
//         </CardActions>
//       </Card>
//     ));
//   };

//   const renderComments = (comments, postId) => {
//     return showComments[postId]
//       ? comments.map((comment) => (
//           <Card
//             key={comment.id}
//             sx={{
//               ml: 2,
//               width: 750,
//               display: "flex",
//               justifyContent: "center",
//               flexDirection: "column",
//               mb: 0.75,
//               paddingBottom: 0.75,
//               boxShadow: "0",
//               // border: "1px solid red",
//               // borderRadius: "20px",
//               backgroundColor: "rgba(239, 140, 203, 0.3)",
//             }}
//           >
//             <CardHeader
//               avatar={
//                 <Avatar sx={{ bgcolor: "#7389ea" }}>{comment.user[0]}</Avatar>
//               }
//               title={comment.user}
//               subheader={comment.datePosted}
//             />
//             <CardContent sx={{ py: 0.4 }}>
//               <Typography
//                 variant="body2"
//                 color="text.secondary"
//                 sx={{ fontFamily: "SF Pro Display Light", fontSize: "1.05rem" }}
//               >
//                 {comment.content}
//               </Typography>
//             </CardContent>
//             <CardActions disableSpacing>
//               <IconButton aria-label="like post">
//                 <ThumbUpIcon />
//               </IconButton>
//               <Typography sx={{ color: "#808080", fontSize: "2" }}>
//                 {comment.likes}
//               </Typography>
//               <IconButton aria-label="dislike post">
//                 <ThumbDownIcon />
//               </IconButton>
//               <Typography sx={{ color: "#808080", fontSize: "2" }}>
//                 {comment.dislikes}
//               </Typography>
//               <IconButton aria-label="comment">
//                 {/* <CommentIcon /> */}
//                 <Typography sx={{ color: "#808080", fontSize: "2" }}>
//                   Reply
//                 </Typography>
//               </IconButton>
//             </CardActions>
//             {/* Replies */}
//             {renderReplies(comment.replies)}
//           </Card>
//         ))
//       : null;
//   };

//   const renderPosts = () => {
//     return posts.map((post) => (
//       <Card
//         sx={{
//           width: 800,
//           display: "flex",
//           justifyContent: "center",
//           flexDirection: "column",
//           mb: 0.75,
//           paddingBottom: 1,
//           boxShadow: "0",
//           // borderBottom: "1px solid #A9A9A9",
//           // borderRadius: "20px",
//           borderRadius: 0,
//           // mode: "dark",
//           backgroundColor: "rgba(239, 140, 203, 0.3)",
//           // backgroundColor: "rgba(204, 119, 173, 0.5)",
//         }}
//         key={post.id}
//       >
//         <CardHeader
//           avatar={<Avatar sx={{ bgcolor: "#7389ea" }}>{post.user[0]}</Avatar>}
//           title={post.user}
//           subheader={post.datePosted}
//           sx={{ fontFamily: "SF Pro Display Light" }}
//         />
//         <CardContent sx={{ py: 0.5 }}>
//           <Typography
//             variant="body2"
//             color="text.secondary"
//             sx={{ fontFamily: "SF Pro Display Light", fontSize: "1.05rem" }}
//           >
//             {post.content}
//           </Typography>
//         </CardContent>
//         <CardActions disableSpacing>
//           <IconButton aria-label="like post">
//             <ThumbUpIcon />
//           </IconButton>
//           <Typography sx={{ color: "#808080", fontSize: "2" }}>
//             {post.likes}
//           </Typography>
//           <IconButton aria-label="dislike post">
//             <ThumbDownIcon />
//           </IconButton>
//           <Typography sx={{ color: "#808080", fontSize: "2" }}>
//             {post.dislikes}
//           </Typography>
//           <IconButton
//             aria-label="comment"
//             sx={{ ml: "auto" }}
//             onClick={() => toggleComments(post.id)}
//           >
//             <CommentIcon />
//           </IconButton>
//         </CardActions>
//         {/* Comments */}
//         {renderComments(post.comments, post.id)}
//       </Card>
//     ));
//   };
//   return (
//     <Box
//       sx={{
//         display: "flex",
//         flexDirection: "column",
//         alignItems: "center",
//         margin: "0 auto", // Center horizontally
//         mt: 2, // Add some top margin
//       }}
//     >
//       <div>{renderPosts()}</div>
//     </Box>
//   );
// }
