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

export default function Reply({ reply }) {
  let colors = ["#6171BA", "#218B8B", "#EF8CCB", "#31B0CD", "#A083C9"];

  return (
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
          <Avatar
          // sx={{ bgcolor: reply.userColor }}
          >
            {reply.userName[0]}
          </Avatar>
        }
        title={reply.userName}
        subheader={reply.timestamp.split("T")[0]}
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
  );
}
