using System;
using System.Collections.Generic;

namespace CybersecurityChatbotPart2
{
    public class ErrorHandler
    {
        private List<string> defaultResponses;
        private Random random;

        // Constructor
        public ErrorHandler()
        {
            random = new Random();

            defaultResponses = new List<string>
            {
                "I'm not sure I understand. Could you rephrase that?",
                "I didn't quite catch that. Could you try asking in a different way?",
                "I'm still learning about cybersecurity. Could you be more specific?",
                "I don't have information about that yet. Can I help with something else related to cybersecurity?",
                "That's an interesting question, but I'm not sure how to answer. Could you try asking something else about online security?"
            };
        }

        // Get a default response when input is not recognized
        public string GetDefaultResponse()
        {
            return defaultResponses[random.Next(defaultResponses.Count)];
        }

        // Handle empty input
        public string HandleEmptyInput()
        {
            return "I didn't receive any input. Please type a question or comment about cybersecurity.";
        }

        // Handle overly long input
        public string HandleTooLongInput()
        {
            return "That's quite a detailed message! Could you break it down into shorter questions so I can better assist you?";
        }
    }
}