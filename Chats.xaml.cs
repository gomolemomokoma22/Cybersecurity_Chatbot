using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace CyberSecurityChatbot
{
    public partial class Chats : Window
    {
        private List<string> ignoreWords = new List<string> {
            "tell", "about", "me", "what", "how", "is", "your", "can", "help", "define"
        };

        private Dictionary<string, string> memory = new Dictionary<string, string>();

        private string[] questions = {
            "password", "phishing", "browsing", "firewall", "malware", "ransomware",
            "vpn", "2fa", "update", "backups", "cybersecurity",
            "how are you", "what is your purpose", "what can i ask you about"
        };

        private string[] responses = {
            "Password is a secret sequence of characters, typically alphanumeric, used to authenticate user's identity.",
            "Phishing is a type of cyberattack that uses fraudulent communication to steal sensitive data.",
            "Safe browsing helps protect against internet threats before they reach your device.",
            "A firewall acts as a barrier between a trusted internal network and untrusted external networks.",
            "Malware is intrusive software created to damage or disable computers and systems.",
            "Ransomware encrypts your files and demands payment for their release—backups are key!",
            "A VPN masks your IP and encrypts data for safe browsing online.",
            "2FA uses two steps to verify your identity, improving security.",
            "Updates fix security holes and improve system stability.",
            "Backups prevent permanent data loss—always back up critical data.",
            "Cybersecurity defends systems and data from digital attacks.",
            "I'm doing great! Always here to help you stay safe online.",
            "My purpose is to help you learn about cybersecurity and stay protected.",
            "Ask me anything about cybersecurity: phishing, firewalls, VPNs, and more!"
        };

        private string userName = "";
        private bool nameAsked = false;

        public Chats()
        {
            InitializeComponent();
            _ = AddBotMessageWithTyping("Welcome to your Cybersecurity Assistant!");
            _ = AddBotMessageWithTyping("Before we start, what's your name?");
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userText)) return;

            AddUserMessage(userText);

            string botResponse;

            if (!nameAsked)
            {
                userName = char.ToUpper(userText[0]) + userText.Substring(1);
                nameAsked = true;
                botResponse = $"Nice to meet you, {userName}! How can I help you with cybersecurity today?";
            }
            else
            {
                chat_history.SaveToHistory($"{userName}: {userText}");
                botResponse = await ProcessInputAsync(userText);
                chat_history.SaveToHistory($"Bot: {botResponse}");
            }

            await AddBotMessageWithTyping(botResponse);
            UserInput.Clear();
        }

        private async Task<string> ProcessInputAsync(string input)
        {
            await Task.Delay(1);
            input = input.ToLower().Trim();

            if (input.StartsWith("i'm interested in") || input.StartsWith("im interested in"))
            {
                string interest = input.Replace("i'm interested in", "").Replace("im interested in", "").Trim();
                if (!string.IsNullOrEmpty(interest))
                {
                    memory_recall.recall("interest_" + interest, interest);
                    return $"Great, {userName}! I'll remember that you're interested in {interest}. Stay informed!";
                }
            }

            if (input.Contains("worried about"))
            {
                string topic = input.Substring(input.IndexOf("worried about") + "worried about".Length).Trim();
                memory_recall.recall("concern_" + topic, topic);
                return $"Thanks for sharing, {userName}. You're right to be concerned about {topic}. Stay vigilant!";
            }

            if (input.Contains("what did i say"))
            {
                var interests = memory_recall.GetAllKeys().FindAll(k => k.StartsWith("interest_"));
                if (interests.Count == 0) return "You haven't mentioned any interests yet.";
                return $"Earlier you said you're interested in: {string.Join(", ", interests.ConvertAll(k => memory_recall.get(k)))}.";
            }

            if (input.StartsWith("give me a tip about"))
            {
                string topic = input.Replace("give me a tip about", "").Trim();
                string tip = keyword_recognition.checkKeyword(topic);
                return !string.IsNullOrEmpty(tip) ? tip : $"Sorry {userName}, I don't have a tip about {topic}.";
            }

            for (int i = 0; i < questions.Length; i++)
                if (input == questions[i]) return responses[i];

            string keywordResponse = keyword_recognition.checkKeyword(input);
            if (!string.IsNullOrEmpty(keywordResponse) && !keywordResponse.StartsWith("I'm not sure"))
                return keywordResponse;

            string sentimentResponse = sentiment_detector.detectSentiment(input);
            if (!string.IsNullOrEmpty(sentimentResponse)) return sentimentResponse;

            foreach (var key in memory_recall.GetAllKeys())
                if (input.Contains(key)) return memory_recall.get(key);

            if (!keyword_recognition.cyberTopic(input))
                return $"Hmm, {userName}, that doesn’t sound like a cybersecurity question. Try asking about phishing, scams, or VPNs.";

            foreach (string word in input.Split(' '))
            {
                if (ignoreWords.Contains(word)) continue;
                for (int i = 0; i < questions.Length; i++)
                    if (word.Contains(questions[i]) || questions[i].Contains(word))
                        return responses[i];
            }

            return $"Oops {userName}, I couldn't quite get that. Can you rephrase it?";
        }

        private void AddUserMessage(string message)
        {
            TextBlock text = new TextBlock
            {
                Text = $"You: {message}",
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };
            ChatPanel.Children.Add(text);
        }

        private async Task AddBotMessageWithTyping(string message)
        {
            TextBlock botText = new TextBlock
            {
                Text = "Bot: ",
                Foreground = Brushes.LightBlue,
                Margin = new Thickness(5)
            };
            ChatPanel.Children.Add(botText);

            foreach (char c in message)
            {
                botText.Text += c;
                await Task.Delay(25);
                DoEvents();
            }
        }

        private void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(delegate (object f)
                {
                    ((DispatcherFrame)f).Continue = false;
                    return null;
                }), frame);
            Dispatcher.PushFrame(frame);
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}

