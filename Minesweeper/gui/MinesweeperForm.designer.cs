using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace Minesweeper {
    partial class MinesweeperForm {
        private IContainer components = null;

        // ====== Control Elements =========
        private MenuStrip MenuStrip;
        private ToolStripMenuItem DifficultySetting;
        private ToolStripMenuItem EasyDifficulty;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem NormalDifficulty;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem HardDifficulty;
        private Panel GameField;
        private Panel MenuPanel;
        private Label TimeLabel;
        private Label MineLabel;
        private Button ResetButton;
        private Button PauseButton;
        private Label GameStatusLabel;
        private Timer GameTimer;
        // ===================================
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new Container();
            this.MenuStrip = new MenuStrip();
            this.DifficultySetting = new ToolStripMenuItem();
            this.EasyDifficulty = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.NormalDifficulty = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.HardDifficulty = new ToolStripMenuItem();
            this.GameField = new Panel();
            this.GameStatusLabel = new Label();
            this.MenuPanel = new Panel();
            this.ResetButton = new Button();
            this.PauseButton = new Button();
            this.TimeLabel = new Label();
            this.MineLabel = new Label();
            this.GameTimer = new Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = SystemColors.ActiveBorder;
            this.MenuStrip.Dock = DockStyle.Left;
            this.MenuStrip.Items.AddRange(new ToolStripItem[] {
            this.DifficultySetting});
            this.MenuStrip.Location = new Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new Size(106, 470);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(this.DifficultySetting_Click);
            // 
            // DifficultySetting
            // 
            this.DifficultySetting.BackColor = SystemColors.ActiveBorder;
            this.DifficultySetting.DropDownItems.AddRange(new ToolStripItem[] {
            this.EasyDifficulty,
            this.toolStripSeparator1,
            this.NormalDifficulty,
            this.toolStripSeparator2,
            this.HardDifficulty});
            this.DifficultySetting.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.DifficultySetting.Name = "DifficultySetting";
            this.DifficultySetting.Size = new Size(93, 27);
            this.DifficultySetting.Text = "Difficulty";
            this.DifficultySetting.Click += new EventHandler(this.DifficultySetting_Click);
            // 
            // EasyDifficulty
            // 
            this.EasyDifficulty.BackColor = SystemColors.Control;
            this.EasyDifficulty.Name = "EasyDifficulty";
            this.EasyDifficulty.Size = new Size(144, 28);
            this.EasyDifficulty.Text = "Easy";
            this.EasyDifficulty.Click += new EventHandler(this.EasyDifficulty_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(141, 6);
            // 
            // NormalDifficulty
            // 
            this.NormalDifficulty.Name = "NormalDifficulty";
            this.NormalDifficulty.Size = new Size(144, 28);
            this.NormalDifficulty.Text = "Normal";
            this.NormalDifficulty.Click += new EventHandler(this.NormalDifficulty_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(141, 6);
            // 
            // HardDifficulty
            // 
            this.HardDifficulty.Name = "HardDifficulty";
            this.HardDifficulty.Size = new Size(144, 28);
            this.HardDifficulty.Text = "Hard";
            this.HardDifficulty.Click += new EventHandler(this.HardDifficulty_Click);
            // 
            // GameField
            // 
            this.GameField.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.GameField.AutoSize = true;
            this.GameField.BackColor = SystemColors.ControlDark;
            this.GameField.BorderStyle = BorderStyle.Fixed3D;
            this.GameField.Location = new Point(12, 113);
            this.GameField.Name = "GameField";
            this.GameField.Size = new Size(324, 345);
            this.GameField.TabIndex = 0;
            // 
            // GameStatusLabel
            // 
            this.GameStatusLabel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.GameStatusLabel.BackColor = SystemColors.ControlDarkDark;
            this.GameStatusLabel.BorderStyle = BorderStyle.FixedSingle;
            this.GameStatusLabel.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.GameStatusLabel.ForeColor = Color.Yellow;
            this.GameStatusLabel.Location = new Point(48, 199);
            this.GameStatusLabel.Name = "GameStatusLabel";
            this.GameStatusLabel.Size = new Size(251, 173);
            this.GameStatusLabel.TabIndex = 0;
            this.GameStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.GameStatusLabel.Visible = false;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.MenuPanel.AutoSize = true;
            this.MenuPanel.BackColor = SystemColors.ControlDark;
            this.MenuPanel.BorderStyle = BorderStyle.Fixed3D;
            this.MenuPanel.Controls.Add(this.ResetButton);
            this.MenuPanel.Controls.Add(this.PauseButton);
            this.MenuPanel.Controls.Add(this.TimeLabel);
            this.MenuPanel.Controls.Add(this.MineLabel);
            this.MenuPanel.Location = new Point(12, 41);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new Size(324, 66);
            this.MenuPanel.TabIndex = 2;
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Bottom)));
            this.ResetButton.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new Point(165, 17);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new Size(76, 32);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new EventHandler(this.ResetButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Bottom)));
            this.PauseButton.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.Location = new Point(76, 17);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new Size(76, 32);
            this.PauseButton.TabIndex = 4;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new EventHandler(this.PauseButton_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Right)));
            this.TimeLabel.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TimeLabel.BorderStyle = BorderStyle.Fixed3D;
            this.TimeLabel.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TimeLabel.Location = new Point(240, 12);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new Size(76, 39);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "000";
            this.TimeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MineLabel
            // 
            this.MineLabel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
            this.MineLabel.BackColor = Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MineLabel.BorderStyle = BorderStyle.Fixed3D;
            this.MineLabel.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.MineLabel.ForeColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MineLabel.Location = new Point(3, 12);
            this.MineLabel.Name = "MineLabel";
            this.MineLabel.Size = new Size(76, 39);
            this.MineLabel.TabIndex = 2;
            this.MineLabel.Text = "000";
            this.MineLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new EventHandler(this.GameTimer_Tick);
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = SystemColors.ActiveBorder;
            this.ClientSize = new Size(346, 470);
            this.Controls.Add(this.GameStatusLabel);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.MenuStrip);
            this.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}

