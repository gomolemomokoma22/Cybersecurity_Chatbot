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


        private Dictionary<string, string> memory = new();
        private string userName = string.Empty;


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


        public Chats()
        {
            InitializeComponent();
            _ = AskForUserName();
        }

        private async Task AskForUserName()
        {
            await AddBotMessageWithTyping("Hello! What is your name?");
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userText)) return;

            if (userText.ToLower() == "exit")
            {
                await AddBotMessageWithTyping($"Goodbye {userName}, stay safe online!");
                await Task.Delay(1000);
                new MainWindow().Show();
                this.Close();
                return;
            }

            AddUserMessage(userText);
            chat_history.SaveToHistory("User: " + userText);

            if (string.IsNullOrEmpty(userName))
            {
                userName = userText;
                await AddBotMessageWithTyping($"Welcome, {userName}! How can I help you today?");
                UserInput.Clear();
                return;
            }

            string botResponse = await ProcessInputAsync(userText);

            await AddBotMessageWithTyping(botResponse);
            chat_history.SaveToHistory("Bot: " + botResponse);

            UserInput.Clear();
        }

        private async Task<string> ProcessInputAsync(string input)
        {
            await Task.Delay(1);
            input = input.ToLower().Trim();

            foreach (string word in input.Split(' '))
            {
                if (ignoreWords.Contains(word)) continue;
                for (int i = 0; i < questions.Length; i++)
                {
                    if (word.Contains(questions[i]) || questions[i].Contains(word))
                        return responses[i];
                }
            }

            return "Sorry, I couldn't understand. Try rephrasing your cybersecurity question.";
        }

        private void AddUserMessage(string message)
        {
            ChatPanel.Children.Add(new TextBlock
            {
                Text = $"{userName}: {message}",
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            });
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
                new DispatcherOperationCallback(f =>
                {
                    ((DispatcherFrame)f).Continue = false;
                    return null;
                }), frame);
            Dispatcher.PushFrame(frame);
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}