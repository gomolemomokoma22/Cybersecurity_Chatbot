using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace CyberSecurityChatbot
{
    public partial class Chats : Window
    {
        public Chats()
        {
            InitializeComponent();
            _ = AddBotMessageWithTyping("Welcome! I'm your cybersecurity assistant.");
            _ = AddBotMessageWithTyping(chat_history.GetLastConversation());
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userText)) return;

            AddUserMessage(userText);
            chat_history.SaveToHistory("User: " + userText);

            string botResponse = await ProcessInputAsync(userText);

            await AddBotMessageWithTyping(botResponse);
            chat_history.SaveToHistory("Bot: " + botResponse);

            UserInput.Clear();
        }

        private async Task<string> ProcessInputAsync(string input)
        {
            await Task.Delay(1); // Prevent compiler warning

            input = input.ToLower();

            // NLP-based quick actions
            if (input.Contains("start quiz") || input.Contains("take quiz") || input.Contains("launch quiz"))
                return "Sure! Opening the quiz game for you... 🚀";

            if (input.Contains("add task") || input.Contains("reminder") || input.Contains("create task"))
                return "Got it! Opening your Task Manager so you can add a task. 📝";

            if (input.Contains("show tasks") || input.Contains("view tasks"))
                return "Opening your list of saved tasks. 📋";

            if (input.Contains("show log") || input.Contains("activity log"))
                return "Opening your activity log to review previous actions. 📜";

            // Sentiment/keyword fallback
            string sentiment = sentiment_detector.detectSentiment(input);
            if (sentiment == "Lets continue chatting & learning how to stay safe online ")
                sentiment = keyword_recognition.checkKeyword(input);

            return sentiment;
        }

        private void AddUserMessage(string message)
        {
            ChatPanel.Children.Add(new TextBlock
            {
                Text = $"You: {message}",
                Foreground = Brushes.White,
                FontWeight = FontWeights.SemiBold,
                Margin = new Thickness(5),
                FontSize = 14
            });
        }

        private async Task AddBotMessageWithTyping(string message)
        {
            TextBlock botText = new TextBlock
            {
                Text = "Bot: ",
                Foreground = Brushes.LightSkyBlue,
                Margin = new Thickness(5),
                FontSize = 14
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
