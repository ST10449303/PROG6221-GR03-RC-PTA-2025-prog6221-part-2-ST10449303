using System;

namespace CybersecurityChatbotPart2
{
    public class ConversationManager
    {
        private string currentTopic;
        private bool expectingFollowUp;
        private bool alreadyRespondedToTopic;

        // Constructor
        public ConversationManager()
        {
            currentTopic = "general";
            expectingFollowUp = false;
            alreadyRespondedToTopic = false;
        }

        // Set the current conversation topic
        public void SetCurrentTopic(string topic)
        {
            // Only change the topic if it's different
            if (currentTopic != topic)
            {
                currentTopic = topic;
                alreadyRespondedToTopic = false;
            }
        }

        // Get the current conversation topic
        public string GetCurrentTopic()
        {
            return currentTopic;
        }

        // Set whether the bot should expect a follow-up
        public void ExpectFollowUp(bool expect)
        {
            expectingFollowUp = expect;
            if (!expect)
            {
                // When disabling follow-up, also mark as already responded
                alreadyRespondedToTopic = true;
            }
        }

        // Check if the bot is expecting a follow-up
        public bool IsExpectingFollowUp()
        {
            // If we've already responded to this topic, don't expect follow-up
            if (alreadyRespondedToTopic)
            {
                expectingFollowUp = false;
                return false;
            }
            return expectingFollowUp;
        }

        // Handle follow-up based on the current topic
        public string HandleFollowUp(string input)
        {

            // Exit early if we're not expecting follow-up or already responded  
            if (!expectingFollowUp || alreadyRespondedToTopic)
            {
                return null;
            }

            alreadyRespondedToTopic = true;

            // Keep the cases the same - just return the appropriate response
            switch (currentTopic)
            {
                case "password":
                    if (input.ToLower().Contains("password manager") || input.ToLower().Contains("manager"))
                    {
                        return "Password managers securely store all your passwords in an encrypted vault. They can also generate strong, unique passwords for you. Popular options include LastPass, 1Password, and Bitwarden.";
                    }
                    else if (input.ToLower().Contains("two-factor") || input.ToLower().Contains("2fa"))
                    {
                        return "Two-factor authentication adds an extra layer of security by requiring something you know (password) and something you have (like your phone). This prevents attackers from accessing your accounts even if they get your password.";
                    }
                    else
                    {
                        return "For better password security, you might want to know about password managers or two-factor authentication. Which one interests you?";
                    }

                case "phishing":
                    if (input.ToLower().Contains("recognize") || input.ToLower().Contains("identify"))
                    {
                        return "To recognize phishing emails, look for: unexpected attachments, poor grammar, urgent language, suspicious sender addresses, and links that don't match legitimate URLs when you hover over them.";
                    }
                    else if (input.ToLower().Contains("what to do") || input.ToLower().Contains("if phished"))
                    {
                        return "If you think you've been phished: 1) Don't click any links or download attachments, 2) Report the email as phishing to your email provider, 3) If you've already entered credentials, change your passwords immediately, 4) Monitor your accounts for suspicious activity.";
                    }
                    else
                    {
                        return "Would you like to know more about how to recognize phishing attempts or what to do if you think you've been phished?";
                    }

                case "privacy":
                    if (input.ToLower().Contains("social media") || input.ToLower().Contains("facebook") || input.ToLower().Contains("instagram"))
                    {
                        return "For social media privacy: 1) Review privacy settings regularly, 2) Limit who can see your posts, 3) Be careful with tagged photos, 4) Disable location sharing, 5) Consider what personal information is visible on your profile.";
                    }
                    else if (input.ToLower().Contains("browser") || input.ToLower().Contains("online"))
                    {
                        return "For better online privacy: 1) Use private browsing modes, 2) Consider privacy-focused browsers like Firefox or Brave, 3) Use a VPN for sensitive activities, 4) Clear cookies regularly, 5) Be mindful of permissions you grant to websites and apps.";
                    }
                    else
                    {
                        return "I can tell you about social media privacy settings or general online privacy practices. Which would you like to know more about?";
                    }

                case "scam":
                    return "Common online scams include fake shopping sites, romance scams, tech support scams, and cryptocurrency scams. Always research before making purchases or investments, and never share personal information with unverified contacts.";

                case "malware":
                    return "To protect against malware: 1) Keep your software updated, 2) Use reputable antivirus software, 3) Be careful what you download, 4) Avoid clicking suspicious links, 5) Back up your data regularly.";

                default:
                    return null;
            }
        }

        public void ResetAfterQuiz()
        {
            currentTopic = "general";
            expectingFollowUp = false;
            alreadyRespondedToTopic = true;
        }
    }
}
