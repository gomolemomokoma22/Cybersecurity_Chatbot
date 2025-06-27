using System;
using System.IO;

namespace CyberSecurityChatbot
{
    public class chat_history
    {
        private static string filePath = "history.txt";

        public static void SaveToHistory(string message)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public static string GetLastConversation()
        {
            if (!File.Exists(filePath)) return "No previous conversation found.";

            var lines = File.ReadAllLines(filePath);
            return lines.Length > 0 ? lines[^1] : "No previous conversation found.";
        }
    }
}
