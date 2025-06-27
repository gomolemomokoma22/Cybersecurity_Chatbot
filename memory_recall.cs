using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    public class memory_recall
    {
        public memory_recall()
        {
        }

        // Dictionary to store memory key-value pairs
        private static Dictionary<string, string> memory = new Dictionary<string, string>();

        // Store a memory value (case-insensitive key)
        public static void recall(string key, string value)
        {
            string normalizedKey = key.ToLower();
            memory[normalizedKey] = value;
        }

        // Retrieve a memory value
        public static string get(string key)
        {
            string normalizedKey = key.ToLower();
            return memory.ContainsKey(normalizedKey) ? memory[normalizedKey] : null;
        }

        // Get all memory keys
        public static List<string> GetAllKeys()
        {
            return new List<string>(memory.Keys);
        }

        // Clear all stored memory (optional feature)
        public static void ClearMemory()
        {
            memory.Clear();
        }

        // Return all key-value memory as string for debugging or display
        public static string DisplayMemory()
        {
            if (memory.Count == 0)
                return "I don't remember anything yet.";

            string output = "Here’s what I remember:\n";
            foreach (var pair in memory)
            {
                output += $"- {pair.Key}: {pair.Value}\n";
            }
            return output;
        }
    }
}