using System;
using System.Collections.Generic;
using System.Text;

namespace CybersecurityChatbotPart2
{
    public class UserMemory
    {
        // Dictionary to store user information
        private Dictionary<string, string> userInfo;

        // List to track user interests
        private List<string> userInterests;

        // Constructor
        public UserMemory()
        {
            userInfo = new Dictionary<string, string>();
            userInterests = new List<string>();
        }

        // Store user name
        public void SetUserName(string name)
        {
            userInfo["name"] = name;
        }

        // Get user name
        public string GetUserName()
        {
            return userInfo.ContainsKey("name") ? userInfo["name"] : "user";
        }

        // Store a user interest
        public void AddUserInterest(string interest)
        {
            if (!userInterests.Contains(interest.ToLower()))
            {
                userInterests.Add(interest.ToLower());
            }
        }

        // Check if user is interested in a topic
        public bool IsUserInterestedIn(string topic)
        {
            return userInterests.Contains(topic.ToLower());
        }

        // Get all user interests
        public List<string> GetUserInterests()
        {
            return userInterests;
        }

        // Store custom user information
        public void StoreInformation(string key, string value)
        {
            userInfo[key] = value;
        }

        // Retrieve custom user information
        public string RetrieveInformation(string key)
        {
            return userInfo.ContainsKey(key) ? userInfo[key] : null;
        }

        // Get a summary of what the bot knows about the user
        public string GetUserSummary()
        {
            StringBuilder summary = new StringBuilder();
            summary.AppendLine($"Here's what I know about you, {GetUserName()}:");

            if (userInterests.Count > 0)
            {
                summary.Append("You're interested in: ");
                summary.AppendLine(string.Join(", ", userInterests));
            }
            else
            {
                summary.AppendLine("You haven't shared any specific interests with me yet.");
            }

            // Add any other stored information
            foreach (var key in userInfo.Keys)
            {
                if (key != "name") // Already included name above
                {
                    summary.AppendLine($"{key}: {userInfo[key]}");
                }
            }

            return summary.ToString();
        }
    }
}