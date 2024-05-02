import React, { useEffect, useState } from "react";
import "./feed.css";
import {
  Typography,
  Card,
  CardHeader,
  Avatar,
  IconButton,
  CardContent,
  CardActions,
  TextField,
} from "@mui/material";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import ThumbDownIcon from "@mui/icons-material/ThumbDown";
import Reply from "./reply";

export default function Comment({ comment, userColors }) {
  const [replyText, setReplyText] = useState("");
  const [isReplying, setIsReplying] = useState(false);
  const [existingReplies, setExistingReplies] = useState(
    comment.replies.map((reply) => <Reply key={reply.id} reply={reply} />)
  );

  useEffect(() => {
    setExistingReplies(
      comment.replies.map((reply) => <Reply key={reply.id} reply={reply} />)
    );
  }, [comment.replies]);

  const renderReplies = (replies) => {
    // console.log("replies", replies);
    // replies.map((reply) => {
    //   reply.userColor = userColors[reply.userId];
    // });
    // return replies.map((reply) => {
    //   return <Reply key={reply.id} reply={reply} />;
    // });
    return existingReplies;
  };

  function handleReply() {
    setIsReplying(!isReplying);
  }
  const handleReplyChange = (event) => {
    setReplyText(event.target.value);
  };
  const handleReplySubmit = async () => {
    try {
      const response = await fetch(
        `http://localhost:5243/api/Reply/add?userId=9a0c1326-fdb9-4744-869b-190f8bc60d07`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            content: replyText,
            commentId: comment.id,
          }),
        }
      );

      if (response.ok) {
        console.log("Reply posted successfully");
        let newReply = await response.json();
        newReply = newReply.data;
        newReply.userName = comment.userName;
        newReply.likes = 0;
        newReply.dislikes = 0;
        const updatedReplies = [
          ...existingReplies,
          <Reply key={newReply.id} reply={newReply} />,
        ];
        setExistingReplies(updatedReplies);
        setReplyText("");
        setIsReplying(false);
      } else {
        console.error("Failed to post reply:", response.statusText);
      }
    } catch (error) {
      console.error("Failed to post reply:", error.message);
    }
  };

  return (
    <div>
      <Card
        key={comment.id}
        sx={{
          ml: 10,
          display: "flex",
          justifyContent: "center",
          flexDirection: "column",
          mb: 0.75,
          paddingBottom: 0.75,
          boxShadow: "0",
          backgroundColor: "rgba(156,128,196, 0.5)",
          borderRadius: "15px",
        }}
      >
        {/* Render comment content */}
        <CardHeader
          avatar={
            <Avatar sx={{ bgcolor: userColors[comment.userId] }}>
              {comment.userName[0] &&
                console.log("comment from inside comment:", comment)}
            </Avatar>
          }
          title={comment.userName}
          subheader={comment.timestamp.split("T")[0]}
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
          <IconButton aria-label="comment" onClick={handleReply}>
            {/* <CommentIcon /> */}
            <Typography sx={{ color: "#808080", fontSize: "2" }}>
              Reply
            </Typography>
          </IconButton>
        </CardActions>
        {/* Render text area for replying */}
        {isReplying && (
          <CardContent>
            <TextField
              id="reply-text"
              label="Reply..."
              multiline
              rows={3}
              variant="outlined"
              value={replyText}
              onChange={handleReplyChange}
              fullWidth
              sx={{ mb: 1 }}
            />
            <button className="custom-button" onClick={handleReplySubmit}>
              Post Reply
            </button>
          </CardContent>
        )}
        {/* Replies */}
      </Card>
      {renderReplies(comment.replies)}
    </div>
  );
}
