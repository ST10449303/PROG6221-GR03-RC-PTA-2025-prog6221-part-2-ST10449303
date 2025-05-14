using System;
using System.Collections.Generic;

namespace CybersecurityChatbotPart2
{
    public class ResponseGenerator
    {
        private Random random;

        // Dictionaries for different types of responses
        private Dictionary<string, List<string>> greetingResponses;
        private Dictionary<string, List<string>> phishingTips;
        private Dictionary<string, List<string>> passwordTips;
        private Dictionary<string, List<string>> scamTips;
        private Dictionary<string, List<string>> malwareTips;
        private Dictionary<string, List<string>> privacyTips;
        private Dictionary<string, List<string>> securityTips;
        private Dictionary<string, List<string>> onlinesafetyTips;

        // Constructor
        public ResponseGenerator()
        {
            random = new Random();

            // Initialize greetings
            greetingResponses = new Dictionary<string, List<string>>
            {
                {"hello", new List<string>{
                    "Hello! How can I help you with cybersecurity today?",
                    "Hi there! Let's talk about keeping you safe online.",
                    "Greetings! I'm your cybersecurity assistant. What would you like to know?"
                }},
                {"how are you", new List<string>{
                    "I'm running smoothly and ready to help you with cybersecurity!",
                    "I'm operating at 100%! How can I assist you today?",
                    "All systems operational! What cybersecurity topic interests you?"
                }},
                {"quiz", new List<string>{
                    "Would you like to take a quick quiz to test your cybersecurity knowledge?",
                    "I have a short quiz that can help you check your understanding of cybersecurity basics. Would you like to try it?",
                    "Taking a quiz is a great way to reinforce your cybersecurity knowledge. Shall we give it a try?"
                }}
            };

            // Initialize phishing tips
            phishingTips = new Dictionary<string, List<string>>
            {
                {"tip", new List<string>{
                    "Always check the sender's email address for legitimacy before clicking links.",
                    "Hover over links to preview the URL before clicking.",
                    "Be suspicious of emails with urgent calls to action or threats.",
                    "Legitimate organizations won't ask for sensitive information via email.",
                    "If an email seems suspicious, contact the organization directly using their official contact information."
                }}
            };

            // Initialize password tips
            passwordTips = new Dictionary<string, List<string>>
            {
                {"tip", new List<string>{
                    "Use a unique password for each account to prevent multiple accounts being compromised.",
                    "A strong password should be at least 12 characters with a mix of numbers, symbols, and both uppercase and lowercase letters.",
                    "Consider using a passphrase - a series of random words - which can be both secure and easier to remember.",
                    "Change passwords regularly, especially for important accounts like banking and email.",
                    "Consider using a password manager to generate and store strong passwords securely."
                }}
            };
        }

        // Get a random greeting response
        public string GetRandomGreeting(string greeting)
        {
            foreach (var key in greetingResponses.Keys)
            {
                if (greeting.ToLower().Contains(key))
                {
                    List<string> responses = greetingResponses[key];
                    return responses[random.Next(responses.Count)];
                }
            }
            return "Hello! I'm your Cybersecurity Awareness Assistant. How can I help you today?";
        }

        // Get a random phishing tip
        public string GetRandomPhishingTip()
        {
            return phishingTips["tip"][random.Next(phishingTips["tip"].Count)];
        }

        // Get a random password tip
        public string GetRandomPasswordTip()
        {
            return passwordTips["tip"][random.Next(passwordTips["tip"].Count)];
        }

        public string GetRandomScamTip()
        {
            return scamTips["tip"][random.Next(scamTips["tip"].Count)];
        }

        public string GetRandomPrivacyTip()
        {
            return privacyTips["tip"][random.Next(privacyTips["tip"].Count)];
        }

        public string GetRandomMalwareTip()
        {
            return malwareTips["tip"][random.Next(malwareTips["tip"].Count)];
        }

        public string GetRandomSecurityTip()
        {
            return securityTips["tip"][random.Next(securityTips["tip"].Count)];
        }
        public string GetRandomOnlineSafetyTip()
        {
            return onlinesafetyTips["tip"][random.Next(onlinesafetyTips["tip"].Count)];
        }

    }
}