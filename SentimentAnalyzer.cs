using System;
using System.Collections.Generic;

namespace CybersecurityChatbotPart2
{
    public class SentimentAnalyzer
    {
        private Dictionary<string, string> sentimentResponses;
        private List<string> positiveWords;
        private List<string> negativeWords;

        // Constructor
        public SentimentAnalyzer()
        {
            // Initialize positive sentiment words
            positiveWords = new List<string>
            {
                "happy", "good", "great", "excellent", "interested", "curious",
                "excited", "helpful", "thanks", "thank", "appreciate"
            };

            // Initialize negative sentiment words
            negativeWords = new List<string>
            {
                "worried", "concerned", "scared", "afraid", "confused",
                "difficult", "hard", "frustrated", "annoyed", "angry"
            };

            // Initialize sentiment-specific responses
            sentimentResponses = new Dictionary<string, string>
            {
                {"positive", "I'm glad I could help! Cybersecurity is fascinating, and it's great that you're interested."},
                {"negative", "I understand this can feel overwhelming. Let's break it down into manageable steps to keep you safe online."},
                {"worried", "It's completely understandable to be concerned about online security. That's why I'm here to help you stay protected."},
                {"confused", "Cybersecurity can be complex, but we can take it step by step. What specifically seems unclear?"},
                {"curious", "That's a great question! I'm happy to explain more about this cybersecurity topic."}
            };
        }

        // Analyze sentiment from user input
        public string AnalyzeSentiment(string input)
        {
            string lowercaseInput = input.ToLower();

            // Check for specific emotions first
            if (lowercaseInput.Contains("worried") || lowercaseInput.Contains("concerned") ||
                lowercaseInput.Contains("scared") || lowercaseInput.Contains("afraid"))
            {
                return "worried";
            }

            if (lowercaseInput.Contains("confused") || lowercaseInput.Contains("don't understand") ||
                lowercaseInput.Contains("unclear"))
            {
                return "confused";
            }

            if (lowercaseInput.Contains("curious") || lowercaseInput.Contains("interested") ||
                lowercaseInput.Contains("tell me more"))
            {
                return "curious";
            }

            // General sentiment analysis
            int positiveScore = 0;
            int negativeScore = 0;

            foreach (string word in positiveWords)
            {
                if (lowercaseInput.Contains(word))
                {
                    positiveScore++;
                }
            }

            foreach (string word in negativeWords)
            {
                if (lowercaseInput.Contains(word))
                {
                    negativeScore++;
                }
            }

            if (positiveScore > negativeScore)
            {
                return "positive";
            }
            else if (negativeScore > positiveScore)
            {
                return "negative";
            }

            return "neutral";
        }

        // Get appropriate response for a detected sentiment
        public string GetSentimentResponse(string sentiment)
        {
            if (sentimentResponses.ContainsKey(sentiment))
            {
                return sentimentResponses[sentiment];
            }

            return null; // No specific response for this sentiment
        }
    }
}