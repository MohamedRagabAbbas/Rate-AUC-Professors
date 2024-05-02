import React, { useState, useEffect } from "react";
import {
  Typography,
  Card,
  CardHeader,
  Avatar,
  IconButton,
  CardContent,
  CardActions,
  TextField,
  Button,
} from "@mui/material";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import ThumbDownIcon from "@mui/icons-material/ThumbDown";
import CommentIcon from "@mui/icons-material/Comment";
import Comment from "./comment";
// import feed.css
import "./feed.css";

export default function Post({ post, userColors }) {
  const [expandedPostId, setExpandedPostId] = useState(null);
  const [commentText, setCommentText] = useState("");
  console.log(post.comments);
  const tempComments = post.comments.map((comment) => (
    <Comment key={comment.id} comment={comment} userColors={userColors} />
  ));
  const [existingComments, setExistingComments] = useState(tempComments);
  // const [renderAgain, setRenderAgain] = useState(false);
  console.log("existing", existingComments);
  //TOMORROW: TRY CHANGING THE EXISTING COMMENTS WHEN POSTING A COMMENT AND ADD A TIMPSSTAMP TO THE COMMENT OBJECT
  const toggleComments = (postId) => {
    setExpandedPostId(postId === expandedPostId ? null : postId);
  };

  const handleCommentChange = (event) => {
    setCommentText(event.target.value);
  };

  const handlePostComment = async () => {
    try {
      const response = await fetch(
        `http://localhost:5243/api/Comment/add?userName=c5825d88-af41-4157-ad97-18353455d806`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            content: commentText,
            feedId: post.id,
          }),
        }
      );

      if (response.ok) {
        console.log("response::::", response);
        let newComment = await response.json();
        console.log("newComment", newComment.data);
        newComment = newComment.data;
        newComment.userName = post.userName;
        newComment.likes = 0;
        newComment.dislikes = 0;
        newComment.replies = [];
        setExistingComments([
          ...existingComments,
          <Comment
            key={newComment.id}
            comment={newComment}
            userColors={userColors}
          />,
        ]);
        setCommentText("");
      } else {
        console.error("Failed to post comment:", response.statusText);
      }
    } catch (error) {
      console.error("Failed to post comment:", error.message);
    }
  };

  const renderCommentInput = () => {
    return (
      <div style={{ margin: "10px 0" }}>
        <TextField
          id="comment-text"
          label="Comment..."
          multiline
          rows={3}
          variant="outlined"
          value={commentText}
          onChange={handleCommentChange}
          fullWidth
          sx={{ mb: 1 }}
        />
        <button className="custom-button" onClick={handlePostComment}>
          Post Comment
        </button>
      </div>
    );
  };
  const renderComments = (comments) => {
    console.log("comments", comments);
    // return comments.map((comment) => (
    //   <Comment key={comment.id} comment={comment} userColors={userColors} />
    // ));
    return existingComments;
  };

  // useEffect(() => {
  //   const tempComments = post.comments.map((comment) => (
  //     <Comment key={comment.id} comment={comment} userColors={userColors} />
  //   ));
  //   setExistingComments(tempComments);
  // }, [renderAgain]);

  return (
    <div key={post.id} style={{ borderBottom: "1px solid #909090" }}>
      <Card
        sx={{
          width: "100%",
          display: "flex",
          justifyContent: "center",
          flexDirection: "column",
          paddingBottom: 1,
          boxShadow: "0",
        }}
      >
        <CardHeader
          avatar={
            <Avatar sx={{ bgcolor: userColors[post.userId] }}>
              {post.userName[0]}
            </Avatar>
          }
          title={post.userName}
          subheader={post.timestamp.split("T")[0]}
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
          <Typography
            sx={{
              color: "#808080",
              fontSize: "2",
              textDecoration: "underline",
              cursor: "pointer",
            }}
            onClick={() => toggleComments(post.id)}
          >
            {post.comments.length === 0
              ? "0 comments"
              : `${post.comments.length} comment${
                  post.comments.length > 1 ? "s" : ""
                }`}
          </Typography>
        </CardActions>
      </Card>
      {/* Render comment input if clicked on iconbutton comment*/}
      {expandedPostId === post.id && renderCommentInput()}
      {/* Render expanded comments if post is expanded */}
      {expandedPostId === post.id && renderComments(post.comments)}
    </div>
  );
}
