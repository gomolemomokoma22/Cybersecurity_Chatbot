using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    public class random_response
    {
        public random_response()
        {
        }
           // Static dictionary to store tips by category
        private static Dictionary<string, List<string>> tipCategories = new Dictionary<string, List<string>>()
        {
            {
                "phishing", new List<string>()
                {
                    "Be cautious of emails from unknown sources asking for personal information.",
                    "Always check the sender's email address to ensure it's legitimate.",
                    "Watch for spelling and grammar errors—phishing emails often contain them.",
                    "Never click on suspicious links or download unexpected attachments."
                }
            },
            {
                "malware", new List<string>()
                {
                    "Keep software up-to-date and regularly update your Operating System.",
                    "Install and use antivirus software and keep it updated.",
                    "Only download software from trusted sources."
                }
            },
            {
                "firewall", new List<string>()
                {
                    "Always activate the firewall to block unauthorized access.",
                    "Adjust firewall settings to allow or block specific programs."
                }
            },
              { "password", new List<string> {
                    "Use long, complex passwords with symbols and numbers.",
                     "Never reuse passwords across different sites.",
                     "Enable two-factor authentication for all accounts."
    
              }
            },
            {
                "2fa", new List<string>()
                {
                    "Use 2FA whenever possible to add an extra layer of security.",
                    "Consider authenticator apps like Google Authenticator."
                }
            }
        };

        //returns a random tip for a given category
        public static string GetRandomTip(string category)
        {

            if (tipCategories.ContainsKey(category.ToLower()))
            {
                var list = tipCategories[category.ToLower()];
                Random random = new Random();
                return list[random.Next(list.Count)];
            }
            return "Sorry, I do not have a tip for that right now";
            

        }

    }
}