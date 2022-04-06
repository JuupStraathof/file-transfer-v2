
namespace file_transfer_v2
{
    partial class FrmSelectProfile
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEditProfile = new System.Windows.Forms.Button();
            this.BtnCopyFiles = new System.Windows.Forms.Button();
            this.CmbSelectProfile = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnEditProfile);
            this.groupBox1.Controls.Add(this.BtnCopyFiles);
            this.groupBox1.Controls.Add(this.CmbSelectProfile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "select a profile";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BtnEditProfile
            // 
            this.BtnEditProfile.Location = new System.Drawing.Point(7, 115);
            this.BtnEditProfile.Name = "BtnEditProfile";
            this.BtnEditProfile.Size = new System.Drawing.Size(130, 38);
            this.BtnEditProfile.TabIndex = 2;
            this.BtnEditProfile.Text = "Profile manager";
            this.BtnEditProfile.UseVisualStyleBackColor = true;
            this.BtnEditProfile.Click += new System.EventHandler(this.BtnEditProfile_Click);
            // 
            // BtnCopyFiles
            // 
            this.BtnCopyFiles.Location = new System.Drawing.Point(7, 71);
            this.BtnCopyFiles.Name = "BtnCopyFiles";
            this.BtnCopyFiles.Size = new System.Drawing.Size(130, 38);
            this.BtnCopyFiles.TabIndex = 1;
            this.BtnCopyFiles.Text = "Copy files";
            this.BtnCopyFiles.UseVisualStyleBackColor = true;
            this.BtnCopyFiles.Click += new System.EventHandler(this.BtnCopyFiles_Click);
            // 
            // CmbSelectProfile
            // 
            this.CmbSelectProfile.FormattingEnabled = true;
            this.CmbSelectProfile.Location = new System.Drawing.Point(7, 31);
            this.CmbSelectProfile.Name = "CmbSelectProfile";
            this.CmbSelectProfile.Size = new System.Drawing.Size(130, 24);
            this.CmbSelectProfile.TabIndex = 0;
            this.CmbSelectProfile.SelectedIndexChanged += new System.EventHandler(this.CmbSelectProfile_SelectedIndexChanged);
            // 
            // FrmSelectProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 183);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSelectProfile";
            this.Text = "Select Profile";
            this.Load += new System.EventHandler(this.FrmSelectProfile_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEditProfile;
        private System.Windows.Forms.Button BtnCopyFiles;
        private System.Windows.Forms.ComboBox CmbSelectProfile;
    }
}

