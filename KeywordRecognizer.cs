using System;
using System.Collections.Generic;

namespace CybersecurityChatbotPart2
{
    public class KeywordRecognizer
    {
        private Dictionary<string, List<string>> keywordResponses;

        // Constructor
        public KeywordRecognizer()
        {
            // Initialize the dictionary with keywords and responses
            keywordResponses = new Dictionary<string, List<string>>
            {
                {"password", new List<string>{
                    "Strong passwords are crucial for online security. Use a mix of letters, numbers, and symbols.",
                    "Remember to use unique passwords for each account and change them regularly.",
                    "Consider using a password manager to maintain strong, unique passwords for all your accounts."
                }},
                {"phishing", new List<string>{
                    "Phishing attacks try to trick you into revealing personal information. Always verify the sender.",
                    "Be cautious of emails asking for personal information or containing suspicious links.",
                    "Legitimate organizations won't ask for sensitive information via email."
                }},
                {"privacy", new List<string>{
                    "Regularly review privacy settings on your social media accounts.",
                    "Be careful about what personal information you share online.",
                    "Use privacy-focused browsers and search engines for sensitive searches."
                }},
                {"scam", new List<string>{
                    "If an offer seems too good to be true, it probably is.",
                    "Never send money to someone you've only met online without verifying their identity.",
                    "Be wary of urgent requests that pressure you to act quickly."
                }},
                {"malware", new List<string>{
                    "Keep your software and operating system updated to protect against malware.",
                    "Only download software from trusted sources.",
                    "Use reputable antivirus software and keep it updated."
                }},
                {"security", new List<string>{
                    "Good cybersecurity is about having multiple layers of protection.",
                    "Regular software updates are essential for security - they often patch vulnerabilities.",
                    "Be careful about what information you share online - it could be used against you."
                }},
                {"online safety", new List<string>{
                    "Staying safe online requires awareness and good habits.",
                    "Think before you click on links or download attachments.",
                    "Use strong passwords and two-factor authentication when available."
                }}
            };
        }

        // Get a response based on detected keywords
        public string GetResponse(string input, Random random)
        {
            // Convert input to lowercase for case-insensitive matching
            string lowercaseInput = input.ToLower();

            // Check for keywords in the input
            foreach (var keyword in keywordResponses.Keys)
            {
                if (lowercaseInput.Contains(keyword))
                {
                    // Get the list of possible responses for this keyword
                    List<string> responses = keywordResponses[keyword];

                    // Return a random response from the list
                    return responses[random.Next(responses.Count)];
                }
            }

            // If no keyword is found, return null
            return null;
        }
    }
}