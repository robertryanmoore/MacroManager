namespace MacroManager
{
    partial class ChanPopUp
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
            checkedListBox1 = new CheckedListBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 18);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(339, 368);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 404);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(339, 34);
            btnSave.TabIndex = 1;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChanPopUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 450);
            Controls.Add(btnSave);
            Controls.Add(checkedListBox1);
            Name = "ChanPopUp";
            Text = "ChanPopUp";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Button btnSave;
    }
}