using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CyberSecurityChatbot
{
    public partial class QuizGame : Window
    {
        private class Question
        {
            public string Text { get; set; }
            public List<string> Options { get; set; }
            public int CorrectIndex { get; set; }
        }

        private List<Question> quizQuestions = new List<Question>();
        private int currentQuestionIndex = 0;
        private int score = 0;

        public QuizGame()
        {
            InitializeComponent();
            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            quizQuestions.Add(new Question
            {
                Text = "What is the purpose of a firewall?",
                Options = new List<string> { "Send spam", "Block unauthorized access", "Increase speed", "Monitor users" },
                CorrectIndex = 1
            });
            quizQuestions.Add(new Question
            {
                Text = "Which is an example of a strong password?",
                Options = new List<string> { "password123", "12345678", "Summer2024", "A!9x#T3k" },
                CorrectIndex = 3
            });
            quizQuestions.Add(new Question
            {
                Text = "What does 2FA stand for?",
                Options = new List<string> { "Two File Authentication", "Two-Factor Authentication", "Two-Faced Account", "Second Firewall Access" },
                CorrectIndex = 1
            });
            quizQuestions.Add(new Question
            {
                Text = "Phishing emails typically aim to...",
                Options = new List<string> { "Speed up your device", "Steal personal information", "Upgrade your browser", "Play music" },
                CorrectIndex = 1
            });
            quizQuestions.Add(new Question
            {
                Text = "What is malware?",
                Options = new List<string> { "An email virus", "Software that protects data", "Malicious software", "Firewall hardware" },
                CorrectIndex = 2
            });
            quizQuestions.Add(new Question
            {
                Text = "What is the safest type of network?",
                Options = new List<string> { "Public Wi-Fi", "Wired network", "Unsecured Bluetooth", "Open hotspot" },
                CorrectIndex = 1
            });
            quizQuestions.Add(new Question
            {
                Text = "Which one is a good cybersecurity practice?",
                Options = new List<string> { "Clicking random links", "Sharing your passwords", "Updating software regularly", "Ignoring antivirus alerts" },
                CorrectIndex = 2
            });
            quizQuestions.Add(new Question
            {
                Text = "Which tool scans your system for threats?",
                Options = new List<string> { "Notepad", "Firewall", "Antivirus", "Paint" },
                CorrectIndex = 2
            });
            quizQuestions.Add(new Question
            {
                Text = "Which of these is a phishing red flag?",
                Options = new List<string> { "Greetings with your real name", "Professional grammar", "Urgent request for credentials", "Secure HTTPS site" },
                CorrectIndex = 2
            });
            quizQuestions.Add(new Question
            {
                Text = "What's the best response to a suspicious email?",
                Options = new List<string> { "Click the link to check", "Ignore and delete", "Forward it to friends", "Reply asking who it is" },
                CorrectIndex = 1
            });
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex >= quizQuestions.Count)
            {
                ShowFinalScore();
                return;
            }

            var q = quizQuestions[currentQuestionIndex];
            QuestionText.Text = $"Q{currentQuestionIndex + 1}: {q.Text}";
            OptionA.Content = q.Options[0];
            OptionB.Content = q.Options[1];
            OptionC.Content = q.Options[2];
            OptionD.Content = q.Options[3];

            OptionA.IsChecked = false;
            OptionB.IsChecked = false;
            OptionC.IsChecked = false;
            OptionD.IsChecked = false;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int selected = -1;
            if (OptionA.IsChecked == true) selected = 0;
            else if (OptionB.IsChecked == true) selected = 1;
            else if (OptionC.IsChecked == true) selected = 2;
            else if (OptionD.IsChecked == true) selected = 3;

            if (selected == -1)
            {
                MessageBox.Show("Please select an answer before continuing.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selected == quizQuestions[currentQuestionIndex].CorrectIndex)
            {
                score++;
            }

            currentQuestionIndex++;
            DisplayQuestion();
        }

        private void ShowFinalScore()
        {
            string message = $"Your final score: {score} / {quizQuestions.Count}\n";

            if (score >= 8)
                message += "Excellent! You have strong cybersecurity knowledge.";
            else if (score >= 5)
                message += "Good effort. Keep learning and stay cyber-safe!";
            else
                message += "Needs improvement. Consider reviewing cybersecurity basics.";

            MessageBox.Show(message, "Quiz Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
