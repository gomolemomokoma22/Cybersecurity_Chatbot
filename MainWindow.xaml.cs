using System.Windows;

namespace CyberSecurityChatbot
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenQuiz_Click(object sender, RoutedEventArgs e)
        {
            QuizGame quiz = new QuizGame();
            quiz.Show();
            this.Close();
        }

        private void OpenChatbotInteraction_Click(object sender, RoutedEventArgs e)
        {
            Chats chat = new Chats();
            chat.Show();
            this.Close();
        }

        private void OpenActivityLog_Click(object sender, RoutedEventArgs e)
        {
            ActivityLog log = new ActivityLog();
            log.Show();
            this.Close();
        }

        private void OpenTaskAssistant_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow task = new TaskWindow();
            task.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
