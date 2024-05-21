import fetch from 'node-fetch';

const API_URL = "https://api-inference.huggingface.co/models/SamLowe/roberta-base-go_emotions";
const headers = {
    "Authorization": "Bearer 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",
    "Content-Type": "application/json"
};

const sentimentToEmoji = {
    "admiration": "👍",
    "amusement": "😂",
    "anger": "😡",
    "annoyance": "😒",
    "approval": "👌",
    "caring": "🤗",
    "confusion": "😕",
    "curiosity": "🤔",
    "desire": "😍",
    "disappointment": "😞",
    "disapproval": "👎",
    "disgust": "🤢",
    "embarrassment": "😳",
    "excitement": "😆",
    "fear": "😱",
    "gratitude": "🙏",
    "grief": "😭",
    "joy": "😊",
    "love": "❤️",
    "nervousness": "😬",
    "optimism": "😄",
    "pride": "😌",
    "realization": "💡",
    "relief": "😅",
    "remorse": "😔",
    "sadness": "😢",
    "surprise": "😲"
};

const query = async (payload) => {
    const response = await fetch(API_URL, {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(payload)
    });
    return response.json();
};

const getSentimentEmoji = async (sentence) => {
    const output = await query({ inputs: sentence });
    const sentimentLabel = output[0][0].label;
    const emoji = sentimentToEmoji[sentimentLabel] || "❓";
    return emoji;
};

export default getSentimentEmoji;

// Example usage:
// const inputSentence = "Really good! Definitely go for her. The class could be a bit demanding but you will learn a lot.";

// getSentimentEmoji(inputSentence).then((emoji) => {
//     console.log(`Predicted Sentiment: ${emoji}`);
// });
