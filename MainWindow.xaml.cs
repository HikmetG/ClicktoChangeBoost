using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics;
using System.Windows.Automation;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Minimized;
            Visibility = Visibility.Hidden;
            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("C:\\Users\\hikme\\source\\repos\\WpfApp2\\WpfApp2\\463172.ico");
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += NotifyIcon_Click;
            notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Exit", System.Drawing.Image.FromFile("C:\\Users\\hikme\\source\\repos\\WpfApp2\\WpfApp2\\463172.ico"), clickExit);
        }
        private void clickExit(object? sender, EventArgs e)
        {
            Close();
        }
        private void NotifyIcon_Click(object? sender, EventArgs e)
        {
            string batchFilePath = "\"C:\\Users\\hikme\\Desktop\\ChangeBoostModee.bat\""; // Replace with the path to your .bat file

            // Create a new process to run the batch file
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe"; // Use the Windows Command Prompt
            process.StartInfo.Arguments = $"/C {batchFilePath}"; // Pass the batch file as an argument
            process.StartInfo.UseShellExecute = false; // Required to redirect standard output
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();

            // Read and display the output (optional)
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);

            process.WaitForExit();
            process.Close();
            
            
        }
    }
}
