#nullable disable
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UnScuff
{
    public partial class Form2 : Form
    {
        private string progressFile = "progress.txt";
        private List<int> remainingCounts = new List<int>();
        private List<string> achievementNames = new List<string>();
        private List<int> targetCounts = new List<int>();

        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form2_FormClosing;
        }

        public CheckedListBox GetCheckedListBox()
        {
            return checkedListBox1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveProgress();

            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 != null)
            {
                form1.SetForm2Closed();
                form1.Show();
            }
            else
            {
                form1 = new Form1();
                form1.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadAchievements();
            LoadTimers();
            LoadProgress();
            UpdateChecklistDisplay();
        }

        private void LoadAchievements()
        {
            if (File.Exists("achivment.txt"))
            {
                string[] lines = File.ReadAllLines("achivment.txt");
                foreach (string line in lines)
                {
                    if (line.Contains(":"))
                    {
                        string[] parts = line.Split(':');
                        string name = parts[0];
                        int target = int.Parse(parts[1]);

                        achievementNames.Add(name);
                        targetCounts.Add(target);
                        remainingCounts.Add(target);
                    }
                }
            }
        }

        private void UpdateChecklistDisplay()
        {
            checkedListBox1.Items.Clear();
            for (int i = 0; i < achievementNames.Count; i++)
            {
                string displayText = $"{achievementNames[i]} — осталось: {remainingCounts[i]} / {targetCounts[i]}";
                checkedListBox1.Items.Add(displayText);

                // Отмечаем как выполненный если осталось 0
                if (remainingCounts[i] <= 0)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            int selectedIndex = checkedListBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < remainingCounts.Count)
            {
                if (remainingCounts[selectedIndex] > 0)
                {
                    remainingCounts[selectedIndex]--;
                    UpdateChecklistDisplay();
                    SaveProgress();
                    CheckAllCompleted();

                    // Звук при выполнении
                    if (remainingCounts[selectedIndex] == 0)
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                    {
                        Console.Beep(500, 100);
                    }
                }
                else
                {
                    MessageBox.Show("Already completed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Select an achievement first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadProgress()
        {
            if (File.Exists(progressFile))
            {
                string[] lines = File.ReadAllLines(progressFile);
                for (int i = 0; i < lines.Length && i < remainingCounts.Count; i++)
                {
                    remainingCounts[i] = int.Parse(lines[i]);
                }
            }
        }

        private void SaveProgress()
        {
            List<string> progress = new List<string>();
            for (int i = 0; i < remainingCounts.Count; i++)
            {
                progress.Add(remainingCounts[i].ToString());
            }
            File.WriteAllLines(progressFile, progress);
        }

        private void CheckAllCompleted()
        {
            bool allCompleted = true;
            for (int i = 0; i < remainingCounts.Count; i++)
            {
                if (remainingCounts[i] > 0)
                {
                    allCompleted = false;
                    break;
                }
            }

            if (allCompleted && remainingCounts.Count > 0)
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("ALL ACHIEVEMENTS COMPLETED! Great job!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void LoadTimers()
        {
            if (!File.Exists("timers.txt")) return;

            string[] lines = File.ReadAllLines("timers.txt");
            int y = 50;

            foreach (string line in lines)
            {
                if (line.Contains(":"))
                {
                    string[] parts = line.Split(':');
                    string name = parts[0];
                    int minutes = int.Parse(parts[1]);

                    Label lblName = new Label();
                    lblName.Text = name;
                    lblName.Location = new Point(330, y);
                    lblName.Size = new Size(100, 25);
                    this.Controls.Add(lblName);

                    Label lblTime = new Label();
                    lblTime.Text = $"{minutes}:00";
                    lblTime.Location = new Point(440, y);
                    lblTime.Size = new Size(50, 25);
                    this.Controls.Add(lblTime);

                    Button btnStart = new Button();
                    btnStart.Text = "Start";
                    btnStart.Location = new Point(500, y);
                    btnStart.Size = new Size(60, 25);
                    this.Controls.Add(btnStart);

                    int seconds = minutes * 60;
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000;

                    btnStart.Click += (s, ev) =>
                    {
                        if (timer.Enabled)
                        {
                            timer.Stop();
                            btnStart.Text = "Start";
                        }
                        else
                        {
                            timer.Start();
                            btnStart.Text = "Stop";
                        }
                    };

                    timer.Tick += (s, ev) =>
                    {
                        seconds--;
                        int mins = seconds / 60;
                        int secs = seconds % 60;
                        lblTime.Text = $"{mins:D2}:{secs:D2}";

                        if (seconds <= 0)
                        {
                            timer.Stop();
                            btnStart.Text = "Done!";
                            MessageBox.Show($"{name} completed!");
                        }
                    };

                    y += 40;
                }
            }
        }
    }
}