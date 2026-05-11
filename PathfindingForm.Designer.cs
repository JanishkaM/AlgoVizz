namespace AlgoVizz
{
    partial class PathfindingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.FlowLayoutPanel toolbar;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.ComboBox speedComboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button clearPathButton;
        private System.Windows.Forms.Button resetGridButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label drawLabel;
        private System.Windows.Forms.Label speedLabel;

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
            drawPanel = new Panel();
            toolbar = new FlowLayoutPanel();
            drawLabel = new Label();
            speedComboBox = new ComboBox();
            speedLabel = new Label();
            startButton = new Button();
            clearPathButton = new Button();
            resetGridButton = new Button();
            statusLabel = new Label();
            modeComboBox = new ComboBox();
            toolbar.SuspendLayout();
            SuspendLayout();
            // 
            // drawPanel
            // 
            drawPanel.BackColor = Color.White;
            drawPanel.Dock = DockStyle.Fill;
            drawPanel.Location = new Point(0, 56);
            drawPanel.Name = "drawPanel";
            drawPanel.Size = new Size(990, 585);
            drawPanel.TabIndex = 0;
            drawPanel.Paint += DrawPanel_Paint;
            drawPanel.MouseClick += DrawPanel_MouseClick;
            // 
            // toolbar
            // 
            toolbar.Controls.Add(statusLabel);
            toolbar.Controls.Add(drawLabel);
            toolbar.Controls.Add(modeComboBox);
            toolbar.Controls.Add(speedLabel);
            toolbar.Controls.Add(speedComboBox);
            toolbar.Controls.Add(startButton);
            toolbar.Controls.Add(clearPathButton);
            toolbar.Controls.Add(resetGridButton);
            toolbar.Dock = DockStyle.Top;
            toolbar.Location = new Point(0, 0);
            toolbar.Name = "toolbar";
            toolbar.Padding = new Padding(8);
            toolbar.Size = new Size(990, 56);
            toolbar.TabIndex = 1;
            toolbar.Paint += DrawPanel_Paint;
            // 
            // drawLabel
            // 
            drawLabel.AutoSize = true;
            drawLabel.Location = new Point(84, 8);
            drawLabel.Name = "drawLabel";
            drawLabel.Size = new Size(37, 15);
            drawLabel.TabIndex = 0;
            drawLabel.Text = "Draw:";
            // 
            // speedComboBox
            // 
            speedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            speedComboBox.FormattingEnabled = true;
            speedComboBox.Items.AddRange(new object[] { "Slow", "Normal", "Fast" });
            speedComboBox.Location = new Point(311, 11);
            speedComboBox.Name = "speedComboBox";
            speedComboBox.Size = new Size(110, 23);
            speedComboBox.TabIndex = 3;
            speedComboBox.SelectedIndexChanged += SpeedComboBox_SelectedIndexChanged;
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Location = new Point(263, 8);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(42, 15);
            speedLabel.TabIndex = 2;
            speedLabel.Text = "Speed:";
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.Location = new Point(427, 11);
            startButton.Name = "startButton";
            startButton.Size = new Size(70, 25);
            startButton.TabIndex = 4;
            startButton.Text = "Start BFS";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // clearPathButton
            // 
            clearPathButton.AutoSize = true;
            clearPathButton.Location = new Point(503, 11);
            clearPathButton.Name = "clearPathButton";
            clearPathButton.Size = new Size(76, 25);
            clearPathButton.TabIndex = 5;
            clearPathButton.Text = "Clear Path";
            clearPathButton.UseVisualStyleBackColor = true;
            clearPathButton.Click += ClearPathButton_Click;
            // 
            // resetGridButton
            // 
            resetGridButton.AutoSize = true;
            resetGridButton.Location = new Point(585, 11);
            resetGridButton.Name = "resetGridButton";
            resetGridButton.Size = new Size(73, 25);
            resetGridButton.TabIndex = 6;
            resetGridButton.Text = "Reset Grid";
            resetGridButton.UseVisualStyleBackColor = true;
            resetGridButton.Click += ResetGridButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(11, 8);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(67, 15);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "Mode: Wall";
            // 
            // modeComboBox
            // 
            modeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Items.AddRange(new object[] { "Wall", "Start", "End", "Erase" });
            modeComboBox.Location = new Point(127, 11);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(130, 23);
            modeComboBox.TabIndex = 1;
            modeComboBox.SelectedIndexChanged += ModeComboBox_SelectedIndexChanged;
            // 
            // PathfindingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 641);
            Controls.Add(drawPanel);
            Controls.Add(toolbar);
            Name = "PathfindingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pathfinding Visualizer - BFS";
            toolbar.ResumeLayout(false);
            toolbar.PerformLayout();
            ResumeLayout(false);
        }
    }
}