using System;
using System.IO;
using System.Windows;

namespace CyberSecurityChatbot
{
    public partial class ActivityLog : Window
    {
        private string historyPath = "history.txt";
        private string memoryPath = "memory.txt";
        private string activityLogPath = "activity_log.txt";

        public ActivityLog()
        {
            InitializeComponent();
            LoadChatHistory();
            LoadMemory();
            LoadActionLog();
        }

        private void LoadChatHistory()
        {
            ChatHistoryList.Items.Clear();

            if (File.Exists(historyPath))
            {
                foreach (var line in File.ReadAllLines(historyPath))
                {
                    ChatHistoryList.Items.Add(line);
                }
            }
            else
            {
                ChatHistoryList.Items.Add("No chat history found.");
            }
        }

        private void LoadMemory()
        {
            MemoryList.Items.Clear();

            if (File.Exists(memoryPath))
            {
                foreach (var line in File.ReadAllLines(memoryPath))
                {
                    MemoryList.Items.Add(line);
                }
            }
            else
            {
                MemoryList.Items.Add("No memory entries found.");
            }
        }

        private void LoadActionLog()
        {
            ActionLogList.Items.Clear();

            if (File.Exists(activityLogPath))
            {
                foreach (var line in File.ReadAllLines(activityLogPath))
                {
                    ActionLogList.Items.Add(line);
                }
            }
            else
            {
                ActionLogList.Items.Add("No activity log found.");
            }
        }

        private void ClearHistory_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(historyPath))
            {
                File.WriteAllText(historyPath, "");
                LoadChatHistory();
                MessageBox.Show("Chat history cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearMemory_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(memoryPath))
            {
                File.WriteAllText(memoryPath, "");
                LoadMemory();
                MessageBox.Show("Memory cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearActionLog_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(activityLogPath))
            {
                File.WriteAllText(activityLogPath, "");
                LoadActionLog();
                MessageBox.Show("Activity log cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

    }
}
 