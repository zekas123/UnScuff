#nullable disable
using System;
using System.IO;
using System.Windows.Forms;

namespace UnScuff
{
    public partial class Form1 : Form
    {
        string Changet = "";
        int Kpl = 0;
        string ChangetWithTime = "";
        int ChangetTime = 0;
        System.Windows.Forms.Timer reminderTimer;
        private bool isForm2Open = false;
        private static Form2 form2Instance;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private string dateFile = "lastdate.txt";

        public Form1()
        {
            InitializeComponent();
        }

        public void SetForm2Closed()
        {
            isForm2Open = false;
            form2Instance = null;
        }

        private void CheckAndResetDaily()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string lastDate = "";

            if (File.Exists(dateFile))
            {
                lastDate = File.ReadAllText(dateFile).Trim();
            }

            if (lastDate != today)
            {
                if (File.Exists("progress.txt"))
                {
                    File.Delete("progress.txt");
                    File.WriteAllText("progress.txt", "");
                }

                File.WriteAllText(dateFile, today);

                if (form2Instance != null && !form2Instance.IsDisposed)
                {
                    for (int i = 0; i < form2Instance.GetCheckedListBox().Items.Count; i++)
                    {
                        form2Instance.GetCheckedListBox().SetItemChecked(i, false);
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    Console.Beep(800, 300);
                    Console.Beep(600, 300);
                }
            }
        }

        private void OpenForm2()
        {
            if (form2Instance == null || form2Instance.IsDisposed)
            {
                form2Instance = new Form2();
                form2Instance.FormClosed += (s, e) => { form2Instance = null; isForm2Open = false; };
                form2Instance.Show();
                this.Hide();
                isForm2Open = true;
            }
            else
            {
                form2Instance.Activate();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("achivment.txt"))
            {
                File.Create("achivment.txt").Close();
            }
            if (!File.Exists("timers.txt"))
            {
                File.Create("timers.txt").Close();
            }

            CheckAndResetDaily();

            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Interval = 7200000;
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();

            trayIcon = new NotifyIcon();
            trayIcon.Icon = SystemIcons.Warning;
            trayIcon.Text = "Anti-Scuff - DO YOUR TASKS!";
            trayIcon.Visible = true;

            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Open", null, (s, ev) => { this.Show(); this.WindowState = FormWindowState.Normal; OpenForm2(); });
            trayMenu.Items.Add("Exit", null, (s, ev) => { trayIcon.Visible = false; Application.Exit(); });
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.DoubleClick += (s, ev) => { this.Show(); this.WindowState = FormWindowState.Normal; OpenForm2(); };

            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                trayIcon.ShowBalloonTip(2000, "Anti-Scuff", "Still running! Complete your tasks!", ToolTipIcon.Warning);
            }
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            if (isForm2Open)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep(1000, 500);
                    System.Threading.Thread.Sleep(200);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Beep(800, 300);
                    Console.Beep(400, 300);
                    System.Threading.Thread.Sleep(100);
                }
                OpenForm2();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (isForm2Open)
            {
                Console.Beep(1000, 500);
                Console.Beep(800, 500);
            }
            else
            {
                OpenForm2();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Kpl > 0 && ChangetTime > 0)
            {
                MessageBox.Show("Take your time", "Fill them in one by one.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!string.IsNullOrWhiteSpace(Changet) && Kpl > 0)
            {
                string line = $"{Changet}:{Kpl}";
                File.AppendAllText("achivment.txt", line + Environment.NewLine);

                textBox1.Clear();
                numericUpDown1.Value = 0;
                Changet = "";
                Kpl = 0;
            }
            else if (!string.IsNullOrWhiteSpace(ChangetWithTime) && ChangetTime > 0)
            {
                string line = $"{ChangetWithTime}:{ChangetTime}";
                File.AppendAllText("timers.txt", line + Environment.NewLine);

                textBox2.Clear();
                numericUpDown2.Value = 0;
                ChangetWithTime = "";
                ChangetTime = 0;
            }
            else
            {
                MessageBox.Show("Write achivment", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Changet = textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Kpl = (int)numericUpDown1.Value;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ChangetWithTime = textBox2.Text;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ChangetTime = (int)numericUpDown2.Value;
        }
    }
}