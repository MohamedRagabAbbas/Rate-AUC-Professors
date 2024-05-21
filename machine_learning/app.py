from transformers import AutoTokenizer, AutoModelForSequenceClassification
import torch

# Load pre-trained model and tokenizer
model_name = "distilbert-base-uncased"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForSequenceClassification.from_pretrained(model_name)

# Define input text
text = "This is a sample sentence for sentiment analysis."

# Tokenize the input text
inputs = tokenizer(text, return_tensors="pt")

# Perform inference
outputs = model(**inputs)
logits = outputs.logits
predicted_class = logits.argmax().item()

# Interpret the results
sentiment_labels = ["negative", "neutral", "positive"]
predicted_sentiment = sentiment_labels[predicted_class]

# Output the predicted sentiment
print("Predicted Sentiment:", predicted_sentiment)
