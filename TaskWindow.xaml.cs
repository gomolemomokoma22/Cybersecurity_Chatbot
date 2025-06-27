using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace CyberSecurityChatbot
{
    public partial class TaskWindow : Window
    {
        private List<string> tasks = new List<string>();
        private readonly string taskFilePath = "tasks.txt";

        public TaskWindow()
        {
            InitializeComponent();

            if (File.Exists(taskFilePath))
            {
                var savedTasks = File.ReadAllLines(taskFilePath);
                tasks.AddRange(savedTasks);
                foreach (var task in savedTasks)
                    TaskList.Items.Add(task);
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string desc = DescriptionInput.Text;
            string reminder = ReminderDate.SelectedDate?.ToShortDateString() ?? "No Date";

            if (!string.IsNullOrWhiteSpace(title))
            {
                string task = $"\uD83D\uDCCC {title} - {desc} (Remind on: {reminder})";
                tasks.Add(task);
                TaskList.Items.Add(task);
                File.AppendAllLines(taskFilePath, new[] { task });

                TitleInput.Clear();
                DescriptionInput.Clear();
                ReminderDate.SelectedDate = null;
            }
            else
            {
                MessageBox.Show("Please enter a task title.", "Missing Title", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearTasks_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Clear all tasks?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                tasks.Clear();
                TaskList.Items.Clear();
                if (File.Exists(taskFilePath)) File.Delete(taskFilePath);
            }
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
