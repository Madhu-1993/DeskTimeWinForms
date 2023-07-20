using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskTimeWinForms
{
    public partial class Login : Form
    {
        private string logFilePath = @"C:/log/logs.txt";
        private StreamWriter logStreamWriter;
        public Login()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Open the log file in append mode
            logStreamWriter = File.AppendText(logFilePath);

            // Start tracking URL and app usage
            StartTracking();

        }
        private void StartTracking()
        {
            // Start a timer to periodically check the active process
            Timer timer = new Timer();
            timer.Interval = 1000; // Check every 1 second
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private void btnsignin_Click(object sender, EventArgs e)
        {
            User_LogTime user_Log = new User_LogTime();
            user_Log.Show();
            this.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the active process
            Process activeProcess = GetActiveProcess();

            if (activeProcess != null)
            {
                // Check if the active process is a browser
                if (IsBrowserProcess(activeProcess))
                {
                    // Get the URL being visited
                    string url = GetActiveBrowserURL(activeProcess);

                    // Log the URL
                    LogData("URL: " + url);
                }
                else
                {
                    // Log the active process name
                    LogData("Process: " + activeProcess.ProcessName);
                }
            }
        }


        private Process GetActiveProcess()
        {
            IntPtr foregroundWindowHandle = NativeMethods.GetForegroundWindow();
            int activeProcessId;
            NativeMethods.GetWindowThreadProcessId(foregroundWindowHandle, out activeProcessId);

            return Process.GetProcessById(activeProcessId);
        }
        private bool IsBrowserProcess(Process process)
        {
            string[] browserNames = { "chrome", "firefox", "iexplore", "edge" }; // Add more browser names as needed

            string processName = process.ProcessName.ToLower();
            foreach (string browserName in browserNames)
            {
                if (processName.Contains(browserName))
                    return true;
            }

            return false;
        }
        private string GetActiveBrowserURL(Process process)
        {
            // Implement logic to retrieve the active browser's URL based on the browser type
            // This might involve accessing the browser's active tab or history
            // Refer to the browser-specific APIs or libraries for more details

            // Return a dummy URL for demonstration purposes
            return "https://example.com";
        }

        private void LogData(string data)
        {
            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {data}";

            // Write the log entry to the log file
            logStreamWriter.WriteLine(logEntry);
            logStreamWriter.Flush(); // Flush the stream to ensure data is written immediately

            // Optionally, display the log entry in a TextBox or ListBox in the Windows Form
            logTextBox.Items.Add(logEntry + Environment.NewLine);
        }
    }

    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);
    }
}





    
