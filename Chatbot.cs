using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;

namespace CybersecurityChatbotPart2
{
    public class Chatbot
    {
        // Console styling
        private ConsoleColor defaultColor;
        private ConsoleColor botColor = ConsoleColor.Green;
        private ConsoleColor userColor = ConsoleColor.Cyan;
        private ConsoleColor errorColor = ConsoleColor.Red;
        private ConsoleColor headerColor = ConsoleColor.Yellow;

        // Components for Part 2
        private UserMemory userMemory;
        private KeywordRecognizer keywordRecognizer;
        private ResponseGenerator responseGenerator;
        private SentimentAnalyzer sentimentAnalyzer;
        private ConversationManager conversationManager;
        private ErrorHandler errorHandler;
        private Random random;

        // Constructor
        public Chatbot()
        {
            defaultColor = Console.ForegroundColor;

            // Initialize Part 2 components
            userMemory = new UserMemory();
            keywordRecognizer = new KeywordRecognizer();
            responseGenerator = new ResponseGenerator();
            sentimentAnalyzer = new SentimentAnalyzer();
            conversationManager = new ConversationManager();
            errorHandler = new ErrorHandler();
            random = new Random();
        }

        // Main method to start the chatbot
        public void Start()
        {
            // Start with Part 1 functionality
            PlayGreeting();
            DisplayAsciiLogo();
            GreetUser();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n═════════════════════════════════════════════");
            Console.WriteLine("Let's test your knowledge on cybersecurity threats.\n");
            Console.WriteLine("═════════════════════════════════════════════\n");

            AskPhishingQuestion();
            AskPasswordQuestion();
            AskSuspiciousLinkQuestion();
            AskSocialEngineeringQuestion();
            AskPublicWiFiQuestion();


            RunConversationLoop();
            

            Console.WriteLine("\nThank you for participating! Stay safe online.");

            // Then transition to Part 2's conversation loop

        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error playing greeting: " + e.Message);
            }
        }

        private void DisplayAsciiLogo()
        {
            string asciiLogo = @"
        ╔════════════════════════════════╗
        ║  CYBERSECURITY AWARENESS BOT   ║
        ║ [🔒 Secure Your Digital Life 🔒] ║
        ╚════════════════════════════════╝";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(asciiLogo);
            Console.ResetColor();
            Thread.Sleep(1000); // Shorter delay for better user experience
        }


        private void GreetUser()
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\n═════════════════════════════════════════════");
            Console.WriteLine("\nHello! Welcome to the Cybersecurity Awareness Chatbot v2.0");
            Console.WriteLine("═════════════════════════════════════════════\n");
            Console.ResetColor();

            Console.Write("What's your name? ");
            Console.ForegroundColor = userColor;
            string name = Console.ReadLine()?.Trim() ?? "Guest";

            // Store user's name in memory (Part 2 feature)
            userMemory.SetUserName(name);

            Console.WriteLine($"Nice to meet you, {name}!\n");
            Console.ResetColor();

            Console.ForegroundColor = userColor;
            string feeling = Console.ReadLine()?.Trim() ?? "";
            Console.ResetColor();

            // Respond to how they're feeling
            Console.WriteLine("How are you feeling today? (good/bad/neutral): ");
            Console.ReadLine();

            Console.ForegroundColor = botColor;
            if (feeling.ToLower().Contains("good") || feeling.ToLower().Contains("fine") ||
                feeling.ToLower().Contains("great") || feeling.ToLower().Contains("well"))
            {
                Console.WriteLine("That's great to hear! I'm here to help you learn about cybersecurity.");
            }
            else if (feeling.ToLower().Contains("bad") || feeling.ToLower().Contains("not") ||
                     feeling.ToLower().Contains("terrible"))
            {
                Console.WriteLine("I'm sorry to hear that. Perhaps learning about cybersecurity will help take your mind off things.");
            }
            else
            {
                Console.WriteLine("Thanks for sharing. I'm here to help you learn about cybersecurity.");
            }


            Console.Write("Is this your first time hearing about cybersecurity? (yes/no): ");
            string response = Console.ReadLine()?.ToLower() ?? "no";
            if (response == "yes")
            {
                Console.WriteLine("\nThat's great! You're about to learn some important cybersecurity tips.\n");
            }
            else
            {
                Console.WriteLine("\nAwesome! Let's refresh your knowledge on cybersecurity.\n");
            }

            // Part 1 features - simple introduction to cybersecurity
            Console.WriteLine("Let's talk about cybersecurity and how to stay safe online.");
            Console.WriteLine("Type 'exit' or 'quit' when you want to end our conversation.");
            Console.WriteLine("Type 'help' to see what else I can do.");
            Console.ResetColor();

            // Add basic cybersecurity tips from Part 1
            ProvideBasicCybersecurityTips();
            conversationManager.SetCurrentTopic("general");
            conversationManager.ExpectFollowUp(false);
        }

        private void ProvideBasicCybersecurityTips()
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\n═════════════════════════════════════════════");
            Console.WriteLine("Here are a few Cybersecurity Tips you should know:\n");
            Console.WriteLine("═════════════════════════════════════════════\n");
            Console.ResetColor();

            ProvidePasswordSafetyTips();
            ProvidePhishingAwarenessTips();
            ProvideSafeBrowsingTips();

            

            Console.WriteLine("\nPress Enter to continue to the interactive chat...");
            Console.ReadLine();
        }

        private void ProvidePasswordSafetyTips()
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\nPassword Safety Tips");
            Console.ResetColor();
            Console.WriteLine("Passwords are the first line of defense for your online security.");
            Console.WriteLine("a. Use at least 12 characters with a mix of letters, numbers, and symbols.");
            Console.WriteLine("b. Use a unique password for each account.");
            Console.WriteLine("c. Consider using a password manager.");
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        private void ProvidePhishingAwarenessTips()
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\nPhishing Awareness");
            Console.ResetColor();
            Console.WriteLine("Phishing is when attackers try to trick you into revealing personal information.");
            Console.WriteLine("a. Be cautious of emails or messages that create a sense of urgency.");
            Console.WriteLine("b. Never click on suspicious links.");
            Console.WriteLine("c. Always verify the source of emails.");
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        private void ProvideSafeBrowsingTips()
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\nSafe Browsing Tips");
            Console.ResetColor();
            Console.WriteLine("a. Avoid entering personal information on unknown websites.");
            Console.WriteLine("b. Keep your antivirus software updated.");

        }

        // Main conversation loop for Part 2
        private void RunConversationLoop()
        {

            // Display the cybersecurity awareness tips header

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n═════════════════════════════════════════════");
            Console.WriteLine("Cybersecurity Awareness Tips.\n");
            Console.WriteLine("═════════════════════════════════════════════\n");

            Console.WriteLine("Type give me e.g password tip to get a proper respond! ");

            bool continueChatting = true;

            while (continueChatting)
            {
                Console.ForegroundColor = userColor;
                Console.Write("\nUser: ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;
                Console.ResetColor();

                // Handle exit commands
                if (input.ToLower() == "exit" || input.ToLower() == "quit" || input.ToLower() == "bye")
                {
                    Console.ForegroundColor = botColor;
                    Console.WriteLine("Chatbot: Goodbye, {0}! Stay safe online!", userMemory.GetUserName());
                    Console.ResetColor();
                    continueChatting = false;
                    continue;
                }

                // Handle empty input
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Chatbot: " + errorHandler.HandleEmptyInput());
                    Console.ResetColor();
                    continue;
                }

                // Process the input and generate a response
                string response = GenerateResponse(input);

                // Display the response with a typing effect
                Console.ForegroundColor = botColor;
                Console.WriteLine("Chatbot: ");
                TypeWriterEffect(response);
                Console.ResetColor();
            }
        }


        // Generate a response based on user input
        private string GenerateResponse(string input)
        {
            // Check for follow-up if expecting one
            if (conversationManager.IsExpectingFollowUp())
            {
                string followUpResponse = conversationManager.HandleFollowUp(input);
                if (followUpResponse != null)
                {
                    // If this is a follow-up to a previous topic, provide a response
                    return followUpResponse;
                }
                // If not a direct follow-up, continue with normal processing
            }

            // Check for user interests/topics that should be remembered
            CheckForInterests(input);

            // Analyze sentiment
            string sentiment = sentimentAnalyzer.AnalyzeSentiment(input);
            string sentimentResponse = sentimentAnalyzer.GetSentimentResponse(sentiment);

            // Check for help command
            if (input.ToLower() == "help" || input.ToLower() == "commands" || input.ToLower().Contains("what can you do"))
            {
                return "I'm your Cybersecurity Awareness Assistant! Here's what I can do:\n\n" +
                       "- Answer questions about cybersecurity topics like passwords, phishing, privacy, and scams\n" +
                       "- Provide random tips about cybersecurity (try 'give me a password tip')\n" +
                       "- Type 'quiz' or 'q' to test your cybersecurity knowledge\n" +
                       "- Remember your interests and adapt my responses to them\n" +
                       "- Show you what I've learned about you (try 'what do you know about me')\n\n" +
                       "Just ask me anything about staying safe online, and I'll do my best to help!";
            }

            // Check for keywords
            string keywordResponse = keywordRecognizer.GetResponse(input, random);
            if (keywordResponse != null)
            {
                // Update conversation topic based on recognized keyword
                bool topicSet = false;
                foreach (string keyword in new[] { "password", "phishing", "privacy", "scam", "malware" })
                {
                    if (input.ToLower().Contains(keyword))
                    {
                        conversationManager.SetCurrentTopic(keyword);
                        conversationManager.ExpectFollowUp(true);
                        topicSet = true;
                        break;
                    }
                }

                // If we have a sentiment to address, combine it with the keyword response
                if (sentimentResponse != null && sentiment != "neutral")
                {
                    return $"{sentimentResponse} {keywordResponse}";
                }

                return keywordResponse;
            }

            // Check for greetings
            if (input.ToLower().Contains("hello") || input.ToLower().Contains("hi") ||
                input.ToLower() == "hey" || input.ToLower().Contains("how are you"))
            {
                return responseGenerator.GetRandomGreeting(input);
            }

            // Check for specific topic requests
            if (input.ToLower().Contains("phishing tip"))
            {
                conversationManager.SetCurrentTopic("phishing");
                conversationManager.ExpectFollowUp(true);
                return responseGenerator.GetRandomPhishingTip();
            }

            if (input.ToLower().Contains("password tip"))
            {
                conversationManager.SetCurrentTopic("password");
                conversationManager.ExpectFollowUp(true);
                return responseGenerator.GetRandomPasswordTip();
            }

            // Check if user is asking about what they've told us
            if (input.ToLower().Contains("what have i told you") ||
                input.ToLower().Contains("what do you know about me"))
            {
                return userMemory.GetUserSummary();
            }

            // If we have a sentiment response, use it
            if (sentimentResponse != null && sentiment != "neutral")
            {
                return $"{sentimentResponse} Is there a specific cybersecurity topic you'd like to learn more about?";
            }

            // Default response if nothing else matches
            return errorHandler.GetDefaultResponse();
        }

        // Check for and store user interests
        private void CheckForInterests(string input)
        {
            string lowercaseInput = input.ToLower();

            // Check for expressions of interest
            if (lowercaseInput.Contains("interested in") || lowercaseInput.Contains("learn about") ||
                lowercaseInput.Contains("tell me more"))
            {
                foreach (string topic in new[] { "password", "phishing", "privacy", "security", "malware", "scam" })
                {
                    if (lowercaseInput.Contains(topic))
                    {
                        userMemory.AddUserInterest(topic);
                        break;
                    }
                }
            }
        }

        // Create a typing effect for more natural output
        private void TypeWriterEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }

        // Quiz methods from Part 1
        private void RunSimpleCybersecurityQuiz()
        {
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\n═════════════════════════════════════════════");
            Console.WriteLine("Let's test your knowledge on cybersecurity threats.\n");
            Console.WriteLine("═════════════════════════════════════════════\n");
            Console.ResetColor();

            int score = 0;
            score += AskPhishingQuestion() ? 1 : 0;
            score += AskPasswordQuestion() ? 1 : 0;
            score += AskSuspiciousLinkQuestion() ? 1 : 0;

            Console.ForegroundColor = botColor;
            Console.WriteLine($"\nYou scored {score} out of 3!");
            if (score == 3)
                Console.WriteLine("Excellent! You have a good understanding of basic cybersecurity principles.");
            else if (score >= 1)
                Console.WriteLine("Good effort! Keep learning about cybersecurity to stay safe online.");
            else
                Console.WriteLine("It looks like you could benefit from learning more about cybersecurity.");
            Console.ResetColor();

            // Tell the user the quiz is complete
            Console.ForegroundColor = botColor;
            Console.WriteLine("\nI hope you enjoyed the quiz! Do you have any questions about the topics we covered?");
            Console.ResetColor();

            // Clear any existing conversation state
            conversationManager.ResetAfterQuiz();
        }

        private bool AskPhishingQuestion()
        {
            Console.ForegroundColor = botColor;
            Console.WriteLine("\n1. You receive an email from your bank asking you to update your account details by clicking on a link. What do you do?");
            Console.ResetColor();
            Console.WriteLine("    A) Click the link immediately.");
            Console.WriteLine("    B) Verify the email by contacting the bank directly.");

            string choice;
            do
            {
                Console.Write("Enter your choice (A/B): ");
                Console.ForegroundColor = userColor;
                choice = Console.ReadLine()?.ToUpper()?.Trim() ?? "";
                Console.ResetColor();

                if (choice != "A" && choice != "B")
                {
                    Console.WriteLine("Invalid choice. Please enter A or B.");
                }
            } while (choice != "A" && choice != "B");

            bool correct = (choice == "B");

            Console.ForegroundColor = correct ? ConsoleColor.Green : ConsoleColor.Red;
            if (choice == "A")
                Console.WriteLine("\nWarning: This could be a phishing attempt! Always verify with your bank before clicking on any suspicious links.");
            else if (choice == "B")
                Console.WriteLine("\nGreat choice! Verifying with the bank directly helps prevent phishing scams.");
            Console.ResetColor();

            return correct;
        }

        private bool AskPasswordQuestion()
        {
            Console.ForegroundColor = botColor;
            Console.WriteLine("\n2. Which of these passwords is the most secure?");
            Console.ResetColor();
            Console.WriteLine("    A) Password123");
            Console.WriteLine("    B) P@$$w0rd");
            Console.WriteLine("    C) Yt6$h&9m!LrQ");

            string choice;
            do
            {
                Console.Write("Enter your choice (A/B/C): ");
                Console.ForegroundColor = userColor;
                choice = Console.ReadLine()?.ToUpper()?.Trim() ?? "";
                Console.ResetColor();

                if (choice != "A" && choice != "B" && choice != "C")
                {
                    Console.WriteLine("Invalid choice. Please enter A, B, or C.");
                }
            } while (choice != "A" && choice != "B" && choice != "C");

            bool correct = (choice == "C");

            Console.ForegroundColor = correct ? ConsoleColor.Green : ConsoleColor.Red;
            if (choice == "A" || choice == "B")
                Console.WriteLine("\nWeak password! Always use long, unique passwords with a mix of letters, numbers, and symbols.");
            else if (choice == "C")
                Console.WriteLine("\nExcellent! Strong passwords help keep your accounts secure.");
            Console.ResetColor();

            return correct;
        }

        private bool AskSuspiciousLinkQuestion()
        {
            Console.ForegroundColor = botColor;
            Console.WriteLine("\n3. You receive a message from an unknown number saying you won a prize and need to click a link to claim it. What do you do?");
            Console.ResetColor();
            Console.WriteLine("    A) Click the link to claim the prize.");
            Console.WriteLine("    B) Ignore the message and report it as spam.");

            string choice;
            do
            {
                Console.Write("Enter your choice (A/B): ");
                Console.ForegroundColor = userColor;
                choice = Console.ReadLine()?.ToUpper()?.Trim() ?? "";
                Console.ResetColor();

                if (choice != "A" && choice != "B")
                {
                    Console.WriteLine("Invalid choice. Please enter A or B.");
                }
            } while (choice != "A" && choice != "B");

            bool correct = (choice == "B");

            Console.ForegroundColor = correct ? ConsoleColor.Green : ConsoleColor.Red;
            if (choice == "A")
                Console.WriteLine("\nWarning: This is a common scam! Never click on suspicious links.");
            else if (choice == "B")
                Console.WriteLine("\nWell done! Ignoring and reporting such messages helps protect against scams.");
            Console.ResetColor();

            return correct;
        }

        static void AskSocialEngineeringQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n4. A caller claims to be from IT support and asks for your password to fix an issue. What do you do?");
            Console.ResetColor();
            Console.WriteLine("    A) Give them your password.");
            Console.WriteLine("    B) Refuse and verify with IT.");
            string choice;
            do
            {
                Console.Write("Enter your choice (A/B): ");
                choice = Console.ReadLine()?.ToUpper();

                if (choice != "A" && choice != "B")
                {
                    Console.WriteLine("Invalid choice. Please enter A or B.");
                }
            } while (choice != "A" && choice != "B");

            if (choice == "A")
                Console.WriteLine("\nNever share your password! Legitimate IT support will never ask for it.");
            else if (choice == "B")
                Console.WriteLine("\nGood job! Always verify with your IT department.");
        }

        static void AskPublicWiFiQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n5. You need to check your bank account, but you're using free public Wi-Fi. What should you do?");
            Console.ResetColor();
            Console.WriteLine("    A) Log in anyway, it's convenient.");
            Console.WriteLine("    B) Use a VPN or wait until you're on a secure network.");
            string choice;
            do
            {
                Console.Write("Enter your choice (A/B): ");
                choice = Console.ReadLine()?.ToUpper();

                if (choice != "A" && choice != "B")
                {
                    Console.WriteLine("Invalid choice. Please enter A or B.");
                }
            } while (choice != "A" && choice != "B");

            if (choice == "A")
                Console.WriteLine("\nPublic Wi-Fi is not secure! Avoid accessing sensitive accounts in public networks.");
            else if (choice == "B")
                Console.WriteLine("\nSmart choice! A VPN adds security, and using a trusted network is always best.");
        }
    }

    

    }

