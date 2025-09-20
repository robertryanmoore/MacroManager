namespace MacroManager
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlSong = new Panel();
            label6 = new Label();
            lblSet = new Label();
            lblIntro = new Label();
            lblLeader = new Label();
            lblSong = new Label();
            btnPrev = new Button();
            btnNext = new Button();
            lblNextSong = new Label();
            lblNextLeader = new Label();
            lblNextIntro = new Label();
            lblNextSet = new Label();
            pnlNext = new Panel();
            label7 = new Label();
            panel3 = new Panel();
            tbxPassword = new TextBox();
            lblX32pw = new Label();
            tbxX32IP = new TextBox();
            lblX32 = new Label();
            btnSaveSettings = new Button();
            lblMode = new Label();
            lblSettings = new Label();
            cmbMode = new ComboBox();
            pnlMacro = new Panel();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn10 = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btnRotR = new Button();
            btn1 = new Button();
            btn4 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnRotL = new Button();
            notifyIcon = new NotifyIcon(components);
            pnlSong.SuspendLayout();
            pnlNext.SuspendLayout();
            panel3.SuspendLayout();
            pnlMacro.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSong
            // 
            pnlSong.BorderStyle = BorderStyle.FixedSingle;
            pnlSong.Controls.Add(label6);
            pnlSong.Controls.Add(lblSet);
            pnlSong.Controls.Add(lblIntro);
            pnlSong.Controls.Add(lblLeader);
            pnlSong.Controls.Add(lblSong);
            pnlSong.Location = new Point(8, 6);
            pnlSong.Margin = new Padding(4);
            pnlSong.Name = "pnlSong";
            pnlSong.Size = new Size(632, 197);
            pnlSong.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 15);
            label6.Name = "label6";
            label6.Size = new Size(126, 34);
            label6.TabIndex = 4;
            label6.Text = "CURRENT";
            // 
            // lblSet
            // 
            lblSet.AutoSize = true;
            lblSet.Location = new Point(31, 143);
            lblSet.Name = "lblSet";
            lblSet.Size = new Size(53, 32);
            lblSet.TabIndex = 3;
            lblSet.Text = "Set:";
            // 
            // lblIntro
            // 
            lblIntro.AutoSize = true;
            lblIntro.Font = new Font("Segoe UI", 12F);
            lblIntro.Location = new Point(31, 111);
            lblIntro.Margin = new Padding(4, 0, 4, 0);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(76, 32);
            lblIntro.TabIndex = 2;
            lblIntro.Text = "Intro: ";
            // 
            // lblLeader
            // 
            lblLeader.AutoSize = true;
            lblLeader.Font = new Font("Segoe UI", 12F);
            lblLeader.Location = new Point(31, 79);
            lblLeader.Margin = new Padding(4, 0, 4, 0);
            lblLeader.Name = "lblLeader";
            lblLeader.Size = new Size(90, 32);
            lblLeader.TabIndex = 1;
            lblLeader.Text = "Leader:";
            // 
            // lblSong
            // 
            lblSong.AutoSize = true;
            lblSong.Font = new Font("Segoe UI", 12F);
            lblSong.Location = new Point(31, 47);
            lblSong.Margin = new Padding(4, 0, 4, 0);
            lblSong.Name = "lblSong";
            lblSong.Size = new Size(81, 32);
            lblSong.TabIndex = 0;
            lblSong.Text = "Song: ";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(8, 416);
            btnPrev.Margin = new Padding(4);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(146, 44);
            btnPrev.TabIndex = 2;
            btnPrev.Text = "Prev";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(162, 416);
            btnNext.Margin = new Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(146, 44);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += button2_Click;
            // 
            // lblNextSong
            // 
            lblNextSong.AutoSize = true;
            lblNextSong.Font = new Font("Segoe UI", 12F);
            lblNextSong.Location = new Point(31, 47);
            lblNextSong.Margin = new Padding(4, 0, 4, 0);
            lblNextSong.Name = "lblNextSong";
            lblNextSong.Size = new Size(81, 32);
            lblNextSong.TabIndex = 0;
            lblNextSong.Text = "Song: ";
            // 
            // lblNextLeader
            // 
            lblNextLeader.AutoSize = true;
            lblNextLeader.Font = new Font("Segoe UI", 12F);
            lblNextLeader.Location = new Point(31, 79);
            lblNextLeader.Margin = new Padding(4, 0, 4, 0);
            lblNextLeader.Name = "lblNextLeader";
            lblNextLeader.Size = new Size(90, 32);
            lblNextLeader.TabIndex = 1;
            lblNextLeader.Text = "Leader:";
            // 
            // lblNextIntro
            // 
            lblNextIntro.AutoSize = true;
            lblNextIntro.Font = new Font("Segoe UI", 12F);
            lblNextIntro.Location = new Point(31, 111);
            lblNextIntro.Margin = new Padding(4, 0, 4, 0);
            lblNextIntro.Name = "lblNextIntro";
            lblNextIntro.Size = new Size(76, 32);
            lblNextIntro.TabIndex = 2;
            lblNextIntro.Text = "Intro: ";
            // 
            // lblNextSet
            // 
            lblNextSet.AutoSize = true;
            lblNextSet.Location = new Point(31, 143);
            lblNextSet.Name = "lblNextSet";
            lblNextSet.Size = new Size(53, 32);
            lblNextSet.TabIndex = 3;
            lblNextSet.Text = "Set:";
            // 
            // pnlNext
            // 
            pnlNext.AccessibleDescription = "";
            pnlNext.BorderStyle = BorderStyle.FixedSingle;
            pnlNext.Controls.Add(label7);
            pnlNext.Controls.Add(lblNextSet);
            pnlNext.Controls.Add(lblNextIntro);
            pnlNext.Controls.Add(lblNextLeader);
            pnlNext.Controls.Add(lblNextSong);
            pnlNext.Location = new Point(8, 211);
            pnlNext.Margin = new Padding(4);
            pnlNext.Name = "pnlNext";
            pnlNext.Size = new Size(632, 197);
            pnlNext.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 13);
            label7.Name = "label7";
            label7.Size = new Size(78, 34);
            label7.TabIndex = 5;
            label7.Text = "NEXT";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(tbxPassword);
            panel3.Controls.Add(lblX32pw);
            panel3.Controls.Add(tbxX32IP);
            panel3.Controls.Add(lblX32);
            panel3.Controls.Add(btnSaveSettings);
            panel3.Controls.Add(lblMode);
            panel3.Controls.Add(lblSettings);
            panel3.Controls.Add(cmbMode);
            panel3.Location = new Point(647, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 402);
            panel3.TabIndex = 5;
            // 
            // tbxPassword
            // 
            tbxPassword.Location = new Point(128, 173);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PasswordChar = '*';
            tbxPassword.Size = new Size(157, 39);
            tbxPassword.TabIndex = 7;
            // 
            // lblX32pw
            // 
            lblX32pw.AutoSize = true;
            lblX32pw.Location = new Point(14, 173);
            lblX32pw.Name = "lblX32pw";
            lblX32pw.Size = new Size(96, 32);
            lblX32pw.TabIndex = 6;
            lblX32pw.Text = "X32 PW";
            // 
            // tbxX32IP
            // 
            tbxX32IP.Location = new Point(128, 124);
            tbxX32IP.Name = "tbxX32IP";
            tbxX32IP.Size = new Size(157, 39);
            tbxX32IP.TabIndex = 5;
            // 
            // lblX32
            // 
            lblX32.AutoSize = true;
            lblX32.Location = new Point(14, 127);
            lblX32.Name = "lblX32";
            lblX32.Size = new Size(80, 32);
            lblX32.TabIndex = 4;
            lblX32.Text = "X32 IP";
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(14, 340);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(271, 49);
            btnSaveSettings.TabIndex = 3;
            btnSaveSettings.Text = "SAVE";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(14, 79);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(83, 32);
            lblMode.TabIndex = 2;
            lblMode.Text = "MODE";
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSettings.Location = new Point(76, 15);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(125, 32);
            lblSettings.TabIndex = 1;
            lblSettings.Text = "SETTINGS";
            lblSettings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMode
            // 
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.FlatStyle = FlatStyle.System;
            cmbMode.FormattingEnabled = true;
            cmbMode.Items.AddRange(new object[] { "Camp", "HBC", "Home", "Sunday" });
            cmbMode.Location = new Point(103, 71);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(182, 40);
            cmbMode.Sorted = true;
            cmbMode.TabIndex = 0;
            cmbMode.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pnlMacro
            // 
            pnlMacro.Controls.Add(btn7);
            pnlMacro.Controls.Add(btn6);
            pnlMacro.Controls.Add(btn5);
            pnlMacro.Controls.Add(btn10);
            pnlMacro.Controls.Add(btn9);
            pnlMacro.Controls.Add(btn8);
            pnlMacro.Controls.Add(btnRotR);
            pnlMacro.Controls.Add(btn1);
            pnlMacro.Controls.Add(btn4);
            pnlMacro.Controls.Add(btn2);
            pnlMacro.Controls.Add(btn3);
            pnlMacro.Controls.Add(btnRotL);
            pnlMacro.Location = new Point(5, 8);
            pnlMacro.Name = "pnlMacro";
            pnlMacro.Size = new Size(635, 399);
            pnlMacro.TabIndex = 6;
            // 
            // btn7
            // 
            btn7.Location = new Point(440, 203);
            btn7.Name = "btn7";
            btn7.Size = new Size(172, 75);
            btn7.TabIndex = 16;
            btn7.Text = "Spots 25%";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(239, 208);
            btn6.Name = "btn6";
            btn6.Size = new Size(172, 75);
            btn6.TabIndex = 15;
            btn6.Text = "Spots 50%";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(35, 203);
            btn5.Name = "btn5";
            btn5.Size = new Size(172, 75);
            btn5.TabIndex = 14;
            btn5.Text = "Spots";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn10
            // 
            btn10.Location = new Point(440, 298);
            btn10.Name = "btn10";
            btn10.Size = new Size(172, 75);
            btn10.TabIndex = 13;
            btn10.Text = "unbound";
            btn10.UseVisualStyleBackColor = true;
            btn10.Click += btn10_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(239, 304);
            btn9.Name = "btn9";
            btn9.Size = new Size(172, 75);
            btn9.TabIndex = 12;
            btn9.Text = "Next";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(35, 304);
            btn8.Name = "btn8";
            btn8.Size = new Size(172, 75);
            btn8.TabIndex = 11;
            btn8.Text = "Previous";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btnRotR
            // 
            btnRotR.Location = new Point(239, 14);
            btnRotR.Name = "btnRotR";
            btnRotR.Size = new Size(172, 75);
            btnRotR.TabIndex = 8;
            btnRotR.Text = "Vol Up";
            btnRotR.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.Location = new Point(440, 14);
            btn1.Name = "btn1";
            btn1.Size = new Size(172, 75);
            btn1.TabIndex = 7;
            btn1.Text = "Smoke";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(440, 110);
            btn4.Name = "btn4";
            btn4.Size = new Size(172, 75);
            btn4.TabIndex = 4;
            btn4.Text = "Laser R";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(35, 110);
            btn2.Name = "btn2";
            btn2.Size = new Size(172, 75);
            btn2.TabIndex = 3;
            btn2.Text = "Lasers";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(239, 110);
            btn3.Name = "btn3";
            btn3.Size = new Size(172, 75);
            btn3.TabIndex = 2;
            btn3.Text = "Laser L";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btnRotL
            // 
            btnRotL.Location = new Point(35, 14);
            btnRotL.Name = "btnRotL";
            btnRotL.Size = new Size(172, 75);
            btnRotL.TabIndex = 1;
            btnRotL.Text = "Vol Down";
            btnRotL.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            notifyIcon.Text = "notifyIcon1";
            notifyIcon.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 469);
            Controls.Add(pnlMacro);
            Controls.Add(panel3);
            Controls.Add(pnlNext);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(pnlSong);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Macro Manager";
            pnlSong.ResumeLayout(false);
            pnlSong.PerformLayout();
            pnlNext.ResumeLayout(false);
            pnlNext.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlMacro.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlSong;
        private Button btnPrev;
        private Label lblSong;
        private Button btnNext;
        private Label lblIntro;
        private Label lblLeader;
        private Label lblSet;
        private Label label6;
        private Label lblNextSong;
        private Label lblNextLeader;
        private Label lblNextIntro;
        private Label lblNextSet;
        private Panel pnlNext;
        private Label label7;
        private Panel panel3;
        private Label lblSettings;
        private ComboBox cmbMode;
        private Label lblMode;
        private Button btnSaveSettings;
        private Label lblX32;
        private Label lblX32pw;
        private TextBox tbxX32IP;
        private TextBox tbxPassword;
        private Panel pnlMacro;
        private Button btnRotR;
        private Button btn1;
        private Button btn4;
        private Button btn2;
        private Button btn3;
        private Button btnRotL;
        private Button btn5;
        private Button btn10;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private NotifyIcon notifyIcon;
    }
}
