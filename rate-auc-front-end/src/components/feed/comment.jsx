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
import Reply from "./reply";

export default function Comment({ comment, userColors }) {
  const renderReplies = (replies) => {
    console.log("replies", replies);
    replies.map((reply) => {
      reply.userColor = userColors[reply.userId];
    });
    return replies.map((reply) => {
      return <Reply key={reply.id} reply={reply} />;
    });
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
  );
}
