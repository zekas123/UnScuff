namespace UnScuff
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkedListBox1 = new CheckedListBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnDecrement = new Button();
            this.SuspendLayout();

            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new Point(20, 50);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new Size(280, 350);
            this.checkedListBox1.TabIndex = 0;

            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.label1.Location = new Point(20, 20);
            this.label1.Text = "Checklist (remaining)";

            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.label2.Location = new Point(330, 20);
            this.label2.Text = "Timers (minutes)";

            this.btnDecrement.Text = "-1 (Mark one done)";
            this.btnDecrement.Location = new Point(20, 410);
            this.btnDecrement.Size = new Size(280, 40);
            this.btnDecrement.Click += new EventHandler(this.btnDecrement_Click);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(620, 470);
            this.Controls.Add(this.btnDecrement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form2";
            this.Text = "Anti-Scuff";
            this.Load += new EventHandler(this.Form2_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private CheckedListBox checkedListBox1;
        private Label label1;
        private Label label2;
        private Button btnDecrement;
    }
}