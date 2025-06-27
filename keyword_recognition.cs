using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityChatbot
{
    public class keyword_recognition
    {
        public keyword_recognition()
        {
        }
        //uses a dictionary
        private static Dictionary<string, List< string> > keywordResponses = new Dictionary<string, List<string>>()
        {
                 { "password", new List<string> {
                "Use a mix of letters, numbers, and symbols in your password.",
                "Never reuse the same password across multiple sites.",
                "Consider using a password manager."
            }},
            { "scam", new List<string> {
                "Always verify links and don’t share personal information with unknown sources.",
                "Scammers often impersonate legitimate services. Be cautious.",
                "Double-check suspicious messages before responding."
            }},
            { "privacy", new List<string> {
                "Adjust your privacy settings on social media regularly.",
                "Avoid oversharing personal details online.",
                "Be selective with the permissions you give to apps."
            }},
            { "phishing", new List<string> {
                "Phishing emails often look legitimate. Always check the sender’s address.",
                "Never click links from unknown emails.",
                "Report suspicious emails to your IT department immediately."
            }},
            { "malware", new List<string> {
                "Avoid downloading files from untrusted sources.",
                "Keep your antivirus software up to date.",
                "Be cautious of unexpected attachments in emails."
            }},
            { "firewall", new List<string> {
                "A firewall blocks unauthorized access to your network.",
                "Always keep your firewall enabled for extra protection."
            }},
            { "vpn", new List<string> {
                "A VPN encrypts your internet connection for privacy.",
                "Use a VPN when connected to public Wi-Fi to avoid tracking."
            }},
            { "encryption", new List<string> {
                "Encryption protects your data from unauthorized access.",
                "Use encrypted messaging apps for sensitive communication."
            }},
            { "2fa", new List<string> {
                "Two-Factor Authentication adds an extra layer of security.",
                "Enable 2FA wherever possible to protect your accounts."
            }},
            { "ransomware", new List<string> {
                "Ransomware locks your files until you pay a ransom. Don’t give in.",
                "Regular backups can protect you from ransomware attacks."
            }},
            { "update", new List<string> {
                "Keep your software updated to fix known security vulnerabilities.",
                "Enable automatic updates when possible."
            }},
            { "antivirus", new List<string> {
                "Antivirus software helps detect and remove threats.",
                "Schedule regular scans to stay protected."
            }},
            { "breach", new List<string> {
                "A data breach means your information was exposed. Change your passwords immediately.",
                "Use services like HaveIBeenPwned to check for breaches."
            }},
            { "hack", new List<string> {
                "If you suspect you’ve been hacked, disconnect from the internet and scan your system.",
                "Change passwords and check account activity immediately."
            }}
        };

        //checks if input contain any relevant cybersecurity topic keywords
        public static bool cyberTopic(string input)
        {
            string[] Topics = keywordResponses.Keys.ToArray();

            foreach(var topic in Topics)
            {
                if (input.ToLower().Contains(topic))
                {
                    return true;
                }
            }
            return false;
        }

        //return a tip based on default response
        public static string checkKeyword(string input)
        {
            input = input.ToLower();
            foreach (var keyword in keywordResponses.Keys)
            {
                if(input.Contains(keyword))
                {
                    var responses = keywordResponses[keyword];
                    Random rm = new Random();
                    return responses[rm.Next(responses.Count)];
                }
               
            }

            return "I'm not sure I understand that. Could you ask about a cybersecurity topic?";
        }
    }
}
