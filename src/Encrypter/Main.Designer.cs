namespace Encrypter
{
    partial class Main
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
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.tbPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword2 = new System.Windows.Forms.TextBox();
            this.btnSelectFileDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileDirPath = new System.Windows.Forms.TextBox();
            this.cbDeleteOriginalFileDir = new System.Windows.Forms.CheckBox();
            this.cbShreadFileDir = new System.Windows.Forms.CheckBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.pbPasswordMatch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Location = new System.Drawing.Point(12, 9);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(53, 13);
            this.lblPassword1.TabIndex = 0;
            this.lblPassword1.Text = "Password";
            // 
            // tbPassword1
            // 
            this.tbPassword1.Location = new System.Drawing.Point(105, 10);
            this.tbPassword1.Name = "tbPassword1";
            this.tbPassword1.PasswordChar = '*';
            this.tbPassword1.Size = new System.Drawing.Size(172, 20);
            this.tbPassword1.TabIndex = 1;
            this.tbPassword1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Check Password";
            // 
            // tbPassword2
            // 
            this.tbPassword2.Location = new System.Drawing.Point(105, 36);
            this.tbPassword2.Name = "tbPassword2";
            this.tbPassword2.PasswordChar = '*';
            this.tbPassword2.Size = new System.Drawing.Size(172, 20);
            this.tbPassword2.TabIndex = 3;
            this.tbPassword2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword2_KeyPress);
            // 
            // btnSelectFileDir
            // 
            this.btnSelectFileDir.Location = new System.Drawing.Point(230, 79);
            this.btnSelectFileDir.Name = "btnSelectFileDir";
            this.btnSelectFileDir.Size = new System.Drawing.Size(47, 23);
            this.btnSelectFileDir.TabIndex = 4;
            this.btnSelectFileDir.Text = "Open";
            this.btnSelectFileDir.UseVisualStyleBackColor = true;
            this.btnSelectFileDir.Click += new System.EventHandler(this.btnSelectFileDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected file/directory";
            // 
            // tbFileDirPath
            // 
            this.tbFileDirPath.Location = new System.Drawing.Point(12, 81);
            this.tbFileDirPath.Name = "tbFileDirPath";
            this.tbFileDirPath.ReadOnly = true;
            this.tbFileDirPath.Size = new System.Drawing.Size(212, 20);
            this.tbFileDirPath.TabIndex = 6;
            // 
            // cbDeleteOriginalFileDir
            // 
            this.cbDeleteOriginalFileDir.AutoSize = true;
            this.cbDeleteOriginalFileDir.Enabled = false;
            this.cbDeleteOriginalFileDir.Location = new System.Drawing.Point(12, 107);
            this.cbDeleteOriginalFileDir.Name = "cbDeleteOriginalFileDir";
            this.cbDeleteOriginalFileDir.Size = new System.Drawing.Size(161, 17);
            this.cbDeleteOriginalFileDir.TabIndex = 7;
            this.cbDeleteOriginalFileDir.Text = "Delete original when finished";
            this.cbDeleteOriginalFileDir.UseVisualStyleBackColor = true;
            this.cbDeleteOriginalFileDir.CheckedChanged += new System.EventHandler(this.cbDeleteOriginalFileDir_CheckedChanged);
            // 
            // cbShreadFileDir
            // 
            this.cbShreadFileDir.AutoSize = true;
            this.cbShreadFileDir.Enabled = false;
            this.cbShreadFileDir.Location = new System.Drawing.Point(12, 130);
            this.cbShreadFileDir.Name = "cbShreadFileDir";
            this.cbShreadFileDir.Size = new System.Drawing.Size(115, 17);
            this.cbShreadFileDir.TabIndex = 8;
            this.cbShreadFileDir.Text = "Shread on deletion";
            this.cbShreadFileDir.UseVisualStyleBackColor = true;
            this.cbShreadFileDir.CheckedChanged += new System.EventHandler(this.cbShreadFileDir_CheckedChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 158);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(81, 26);
            this.btnEncrypt.TabIndex = 9;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(99, 158);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(81, 26);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // pbPasswordMatch
            // 
            this.pbPasswordMatch.Image = global::Encrypter.Properties.Resources.cross;
            this.pbPasswordMatch.InitialImage = null;
            this.pbPasswordMatch.Location = new System.Drawing.Point(283, 36);
            this.pbPasswordMatch.Name = "pbPasswordMatch";
            this.pbPasswordMatch.Size = new System.Drawing.Size(21, 21);
            this.pbPasswordMatch.TabIndex = 11;
            this.pbPasswordMatch.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 196);
            this.Controls.Add(this.pbPasswordMatch);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.cbShreadFileDir);
            this.Controls.Add(this.cbDeleteOriginalFileDir);
            this.Controls.Add(this.tbFileDirPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectFileDir);
            this.Controls.Add(this.tbPassword2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword1);
            this.Controls.Add(this.lblPassword1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(336, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(336, 234);
            this.Name = "Main";
            this.Text = "Encrypter";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordMatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.TextBox tbPassword1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword2;
        private System.Windows.Forms.Button btnSelectFileDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileDirPath;
        private System.Windows.Forms.CheckBox cbDeleteOriginalFileDir;
        private System.Windows.Forms.CheckBox cbShreadFileDir;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.PictureBox pbPasswordMatch;
    }
}

