namespace AlgoVizz
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
            panel1 = new Panel();
            button1 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            button2 = new Button();
            comboBox3 = new ComboBox();
            button3 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(860, 577);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint_1;
            // 
            // button1
            // 
            button1.Location = new Point(10, 595);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 1;
            button1.Text = "Generate Random";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "10", "20", "30", "40" });
            comboBox1.Location = new Point(878, 25);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Insertion Sort", "Merge Sort" });
            comboBox2.Location = new Point(878, 81);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(180, 23);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(878, 191);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 285);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged_2;
            // 
            // button2
            // 
            button2.Location = new Point(157, 595);
            button2.Name = "button2";
            button2.Size = new Size(142, 23);
            button2.TabIndex = 5;
            button2.Text = "Start Animation";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Slow", "Normal", "Fast" });
            comboBox3.Location = new Point(878, 140);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(180, 23);
            comboBox3.TabIndex = 6;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged_1;
            // 
            // button3
            // 
            button3.Location = new Point(305, 595);
            button3.Name = "button3";
            button3.Size = new Size(135, 23);
            button3.TabIndex = 7;
            button3.Text = "Manual Input";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(878, 482);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(180, 66);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(609, 595);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(449, 23);
            textBox3.TabIndex = 9;
            textBox3.TextChanged += textBox3_TextChanged;
            textBox3.Enter += textBox3_Enter_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(878, 7);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 10;
            label1.Text = "Array Size";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(878, 63);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 11;
            label2.Text = "Algorithm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(878, 122);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 12;
            label3.Text = "Speed";
            label3.Click += label3_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImageAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(992, 574);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 13;
            label4.Text = "Array Input";
            label4.TextAlign = ContentAlignment.TopRight;
            label4.Click += label4_Click;
            // 
            // button4
            // 
            button4.Location = new Point(446, 595);
            button4.Name = "button4";
            button4.Size = new Size(157, 23);
            button4.TabIndex = 14;
            button4.Text = "Pathfinding (BFS)";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 630);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(comboBox3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "AlgoVizz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Button button2;
        private ComboBox comboBox3;
        private Button button3;
        private Button button4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
