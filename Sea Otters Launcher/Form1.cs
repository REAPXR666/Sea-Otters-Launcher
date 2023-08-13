using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Compression;
using System.Diagnostics;

namespace Sea_Otters_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string endpoint = "https://roastedjubilantautosketch.purify-tools.repl.co/";

        private async void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            string newsdl = await client.DownloadStringTaskAsync(new Uri(endpoint + "news.txt"));
            news.Text = newsdl;
            string gamever = await client.DownloadStringTaskAsync(new Uri(endpoint + "version.txt"));
            gameversion.Text = gamever;
            /*
            string autoupdate = File.ReadAllText("AutoUpdate.txt");
            if (autoupdate == "True")
            {
                client.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                client.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*";
                dialog.ShowDialog();
                dlpath = dialog.FileName;
                await client.DownloadFileTaskAsync(new Uri(endpoint + "Game/game.zip"), dialog.FileName);
            }
            */
            
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                guna2Panel4.VerticalScroll.Value = guna2VScrollBar1.Value;
            }
            catch
            {
                MessageBox.Show("Cannot bypass value:" + guna2Panel4.VerticalScroll.Value);
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
            guna2VScrollBar1.Value = guna2Panel4.VerticalScroll.Value;
        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            /*if (bunifuCheckBox1.Checked == true)
            {
                File.WriteAllText("AutoUpdate.txt", "True");
            }
            if (bunifuCheckBox1.Checked == false)
            {
                File.WriteAllText("AutoUpdate.txt", "False");
            }*/
        }
        private static string gamepath()
        {
            string data = File.ReadAllText("GamePath.txt");
            return data;
        }

        string dlpath = "";

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            client.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*";
            dialog.ShowDialog();
            dlpath = dialog.FileName;
            await client.DownloadFileTaskAsync(new Uri(endpoint + "Game/game.zip"), dialog.FileName);
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadstatus.Value = e.ProgressPercentage;
        }
        string gameexe = "";

        private void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                dlfinish.Text = "Downloaded";
                string newfolder = dlpath.Replace(".zip", "");
                ZipFile.ExtractToDirectory(dlpath, newfolder);
                MessageBox.Show(newfolder);
                File.WriteAllText("GamePath.txt", newfolder + "\\sea otter vr\\Sea Otters VR.exe");
            }
            else
            {
                MessageBox.Show("Download failed: " + e.Error.Message);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string path = gamepath();
            Process.Start(path);
        }
    }
}
