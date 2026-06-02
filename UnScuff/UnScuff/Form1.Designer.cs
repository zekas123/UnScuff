namespace UnScuff
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Start = new Button();
            textBox1 = new TextBox();
            AddTarget = new Button();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // Start
            // 
            Start.Location = new Point(248, 384);
            Start.Name = "Start";
            Start.Size = new Size(163, 45);
            Start.TabIndex = 0;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(61, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(225, 22);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // AddTarget
            // 
            AddTarget.Location = new Point(248, 304);
            AddTarget.Name = "AddTarget";
            AddTarget.Size = new Size(163, 59);
            AddTarget.TabIndex = 2;
            AddTarget.Text = "AddTarget";
            AddTarget.UseVisualStyleBackColor = true;
            AddTarget.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 45);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 3;
            label1.Text = "Targets:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(312, 84);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(73, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(312, 45);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 5;
            label2.Text = "Count";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(61, 142);
            label3.Name = "label3";
            label3.Size = new Size(225, 25);
            label3.TabIndex = 6;
            label3.Text = "Targets with Time";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Calibri", 9F);
            textBox2.Location = new Point(61, 186);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(225, 22);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(312, 186);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(73, 23);
            numericUpDown2.TabIndex = 8;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 15.75F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(305, 142);
            label4.Name = "label4";
            label4.Size = new Size(106, 25);
            label4.TabIndex = 9;
            label4.Text = "Time m:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 450);
            Controls.Add(label4);
            Controls.Add(numericUpDown2);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(AddTarget);
            Controls.Add(textBox1);
            Controls.Add(Start);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Start;
        private TextBox textBox1;
        private Button AddTarget;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private NumericUpDown numericUpDown2;
        private Label label4;
    }
}
