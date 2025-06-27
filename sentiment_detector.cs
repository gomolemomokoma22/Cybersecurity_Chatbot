using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    public class sentiment_detector
    {
        public sentiment_detector()
        {
        }
        private static Dictionary<string, List<string>> emotions = new Dictionary<string, List<string>>()
        {
            { "worried", new List<string>{ "worried", "nervous", "scared", "anxious", "fear" } },
            { "happy", new List<string>{ "great", "thanks", "good", "happy", "excited" } },
            { "sad", new List<string>{ "sad", "down", "depressed", "unhappy" } },
            { "angry", new List<string>{ "angry", "mad", "furious", "annoyed" } },
            { "bored", new List<string>{ "bored", "meh", "tired", "lazy" } },
            { "confused", new List<string>{ "confused", "lost", "unsure", "uncertain" } }
        };

        // Assurance responses per emotion
        private static Dictionary<string, string> emotionResponses = new Dictionary<string, string>()
        {
            { "worried", "Don't worry, I'm here to help!" },
            { "happy", "I'm glad to hear that!" },
            { "sad", "I'm sorry to hear that. I'm here for you." },
            { "angry", "I understand. Taking a break or securing your digital space can help." },
            { "bored", "Boredom is the perfect time to level up your cyber skills!" },
            { "confused", "It's okay to feel confused. Let's explore some cyber topics together." }
        };

        //analyzes input to detect mood and suggest relevant cybersecurity tip
        public static string detectSentiment(string input)
        {
            input = input.ToLower();
            string assurance = "";
            string tip = "";


            // Detect mood
            foreach (var pair in emotions)
            {
                foreach (var keyword in pair.Value)
                {
                    if (input.Contains(keyword))
                    {
                        assurance = emotionResponses[pair.Key];
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(assurance)) break;
            }

            //  Threat category detection
            if (input.Contains("scam") || input.Contains("phishing"))
            {
                tip = random_response.GetRandomTip("phishing");
            }
            else if (input.Contains("malware") || input.Contains("virus"))
            {
                tip = random_response.GetRandomTip("malware");
            }
            else if (input.Contains("password"))
            {
                tip = random_response.GetRandomTip("password");
            }
            
            else if (input.Contains("firewall"))
            {
                tip = random_response.GetRandomTip("firewall");
            }
            else if (input.Contains("2fa"))
            {
                tip = random_response.GetRandomTip("2fa");
            }

            // Combine reassurance + tip
            if (!string.IsNullOrEmpty(assurance) && !string.IsNullOrEmpty(tip))
            {
                return $"{assurance} Here's something to help: {tip}";
            }

            else if (!string.IsNullOrEmpty(assurance))
            {
                return assurance;

            }

            else if (!string.IsNullOrEmpty(tip))
            {
                return $"Here's a helpful tip: {tip}";
            }

            return "Lets continue chatting & learning how to stay safe online "; // Let chatbot continue with keyword or fallback
        }
    }
}