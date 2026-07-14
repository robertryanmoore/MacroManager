namespace MacroManager
{
    partial class DbSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            btnConfirmDb = new Button();
            btnCancelDb = new Button();
            lblDb = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "WineMS2_accolade", "WineMS2_AWR", "WineMS2_bfe", "WineMS2_dedoorns", "WineMS2_kleinezalze", "WineMS2_lamotta", "WineMS2_steenberg", "WineMS2_stellenboschvineyards" });
            comboBox1.Location = new Point(101, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 23);
            comboBox1.TabIndex = 0;
            // 
            // btnConfirmDb
            // 
            btnConfirmDb.Location = new Point(12, 45);
            btnConfirmDb.Name = "btnConfirmDb";
            btnConfirmDb.Size = new Size(75, 23);
            btnConfirmDb.TabIndex = 1;
            btnConfirmDb.Text = "OK";
            btnConfirmDb.UseVisualStyleBackColor = true;
            btnConfirmDb.Click += btnConfirmDb_Click;
            // 
            // btnCancelDb
            // 
            btnCancelDb.Location = new Point(101, 45);
            btnCancelDb.Name = "btnCancelDb";
            btnCancelDb.Size = new Size(75, 23);
            btnCancelDb.TabIndex = 2;
            btnCancelDb.Text = "Cancel";
            btnCancelDb.UseVisualStyleBackColor = true;
            // 
            // lblDb
            // 
            lblDb.AutoSize = true;
            lblDb.Location = new Point(12, 15);
            lblDb.Name = "lblDb";
            lblDb.Size = new Size(83, 15);
            lblDb.TabIndex = 3;
            lblDb.Text = "Select Databse";
            // 
            // DbSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 82);
            Controls.Add(lblDb);
            Controls.Add(btnCancelDb);
            Controls.Add(btnConfirmDb);
            Controls.Add(comboBox1);
            Name = "DbSelector";
            Text = "Database Selector";
            Load += DbSelector_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button btnConfirmDb;
        private Button btnCancelDb;
        private Label lblDb;
    }
}