import React, { useState } from "react";
import "./feed.css";
import {
  Typography,
  Card,
  CardHeader,
  Avatar,
  IconButton,
  CardContent,
  CardActions,
} from "@mui/material";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import ThumbDownIcon from "@mui/icons-material/ThumbDown";
import CommentIcon from "@mui/icons-material/Comment";
import Comment from "./comment";

export default function Post({ post, userColors }) {
  const [expandedPostId, setExpandedPostId] = useState(null);

  const toggleComments = (postId) => {
    setExpandedPostId(postId === expandedPostId ? null : postId);
  };

  const renderComments = (comments) => {
    console.log("comments", comments);
    return comments.map((comment) => (
      <Comment key={comment.id} comment={comment} userColors={userColors} />
    ));
  };

  return (
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
          <IconButton aria-label="comment" sx={{ ml: "auto" }}>
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
      {/* Render expanded comments if post is expanded */}
      {expandedPostId === post.id && renderComments(post.comments)}
    </div>
  );
}
