using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CyberSecurityChatbot
{
    public partial class TaskWindow : Window
    {
        private List<string> tasks = new List<string>();

        public TaskWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string desc = DescriptionInput.Text;
            string reminder = ReminderDate.SelectedDate.HasValue
                ? ReminderDate.SelectedDate.Value.ToShortDateString()
                : "No Date";

            if (!string.IsNullOrWhiteSpace(title))
            {
                string task = $"📌 {title} - {desc} (Remind on: {reminder})";
                tasks.Add(task);
                TaskList.Items.Add(task);

                TitleInput.Text = "";
                DescriptionInput.Text = "";
                ReminderDate.SelectedDate = null;
            }
            else
            {
                MessageBox.Show("Please enter a task title.", "Missing Title", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


        private void ClearTasks_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all tasks?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                tasks.Clear();
                TaskList.Items.Clear();
            }
        }
    }
}

