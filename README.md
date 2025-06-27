CyberSecurity Chatbot (WPF Desktop App)



CyberSecurity Chatbot is a user-friendly WPF desktop application developed in C#.
It serves as a digital assistant that educates users on cybersecurity awareness, assists with tasks and reminders, allows interactive chat, and includes a fun quiz to reinforce security knowledge.

This application was built as part of a software development portfolio project (Part 1, 2, and 3 combined) and showcases GUI design, chatbot logic, file handling, user memory, and simulated NLP behavior.

---

 Features

 Chatbot Interaction
- Simulates human-like conversations.
- Uses keyword recognition, sentiment detection, and memory recall.
- Responds to topics like phishing, malware, passwords, VPNs, and more.
- Greets user by name and remembers interests.
- Allows the user to type `exit` to leave the chat at any time.

 Task Manager
- Add cybersecurity-related tasks and reminders.
- Stores and loads tasks from a persistent text file (`tasks.txt`).
- Option to clear or reset tasks.
- Back button to return to the main menu.

Activity Log
- Displays:
  - Chat history
  - Memory recall (saved interests or concerns)
  - Action logs (e.g., when features are used)
- Option to clear each log type.

Quiz Game
- 10-question multiple-choice cybersecurity quiz.
- Randomized question navigation.
- Scores user performance at the end.

 Technologies Used

- **C# / .NET (WPF Framework)**
- **XAML** for GUI layout and styling
- **File I/O** for saving/loading user data
- **OOP Principles** (modular class design)
- **Simulated NLP** for chatbot logic

---

How to Run

1. Open the solution in **Visual Studio**.
2. Restore any missing NuGet packages (if used).
3. Set `CyberSecurityChatbot` as the startup project.
4. Build and run (`F5`).
5. Navigate the chatbot, quiz, tasks, and logs via the sidebar.

---

## 📌 Notes

- All data (chat history, memory, tasks) is saved locally in `.txt` files.
- The chatbot is not connected to any external AI service – all responses are simulated via keywords, memory, and conditions.
- Designed with a consistent dark theme and modern UX.





Developer

- **Name:** Gomolemo
- **Program:** Software Development Portfolio
- **Modules Applied:** Programming 2A, Information Security, Systems Analysis & Design

