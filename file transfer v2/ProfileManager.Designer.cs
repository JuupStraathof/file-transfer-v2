
namespace file_transfer_v2
{
    partial class ProfileManager
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
            this.CmbSelectProfile = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSelectSourcePath = new System.Windows.Forms.Button();
            this.BtnSelectTargetPath = new System.Windows.Forms.Button();
            this.BtnSelectFiles = new System.Windows.Forms.Button();
            this.BtnEditProfile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TxtProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LsvSelectedFiles = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileExtention = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnNewProfile = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbSelectProfile
            // 
            this.CmbSelectProfile.FormattingEnabled = true;
            this.CmbSelectProfile.Location = new System.Drawing.Point(6, 21);
            this.CmbSelectProfile.Name = "CmbSelectProfile";
            this.CmbSelectProfile.Size = new System.Drawing.Size(121, 24);
            this.CmbSelectProfile.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbSelectProfile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a Profile";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LsvSelectedFiles);
            this.groupBox2.Controls.Add(this.BtnSelectFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File selection";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.BtnSelectTargetPath);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.BtnSelectSourcePath);
            this.groupBox3.Location = new System.Drawing.Point(12, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Path selection";
            // 
            // BtnSelectSourcePath
            // 
            this.BtnSelectSourcePath.Location = new System.Drawing.Point(436, 27);
            this.BtnSelectSourcePath.Name = "BtnSelectSourcePath";
            this.BtnSelectSourcePath.Size = new System.Drawing.Size(93, 23);
            this.BtnSelectSourcePath.TabIndex = 4;
            this.BtnSelectSourcePath.Text = "Select path";
            this.BtnSelectSourcePath.UseVisualStyleBackColor = true;
            // 
            // BtnSelectTargetPath
            // 
            this.BtnSelectTargetPath.Location = new System.Drawing.Point(436, 61);
            this.BtnSelectTargetPath.Name = "BtnSelectTargetPath";
            this.BtnSelectTargetPath.Size = new System.Drawing.Size(93, 23);
            this.BtnSelectTargetPath.TabIndex = 5;
            this.BtnSelectTargetPath.Text = "Select path";
            this.BtnSelectTargetPath.UseVisualStyleBackColor = true;
            // 
            // BtnSelectFiles
            // 
            this.BtnSelectFiles.Location = new System.Drawing.Point(436, 21);
            this.BtnSelectFiles.Name = "BtnSelectFiles";
            this.BtnSelectFiles.Size = new System.Drawing.Size(93, 52);
            this.BtnSelectFiles.TabIndex = 6;
            this.BtnSelectFiles.Text = "Select files";
            this.BtnSelectFiles.UseVisualStyleBackColor = true;
            // 
            // BtnEditProfile
            // 
            this.BtnEditProfile.Location = new System.Drawing.Point(6, 22);
            this.BtnEditProfile.Name = "BtnEditProfile";
            this.BtnEditProfile.Size = new System.Drawing.Size(75, 62);
            this.BtnEditProfile.TabIndex = 7;
            this.BtnEditProfile.Text = "Edit profile";
            this.BtnEditProfile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 22);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(138, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 22);
            this.textBox2.TabIndex = 9;
            // 
            // TxtProfileName
            // 
            this.TxtProfileName.Location = new System.Drawing.Point(6, 23);
            this.TxtProfileName.Name = "TxtProfileName";
            this.TxtProfileName.Size = new System.Drawing.Size(128, 22);
            this.TxtProfileName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select source path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select target path";
            // 
            // LsvSelectedFiles
            // 
            this.LsvSelectedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileExtention});
            this.LsvSelectedFiles.GridLines = true;
            this.LsvSelectedFiles.HideSelection = false;
            this.LsvSelectedFiles.Location = new System.Drawing.Point(6, 21);
            this.LsvSelectedFiles.Name = "LsvSelectedFiles";
            this.LsvSelectedFiles.Size = new System.Drawing.Size(424, 163);
            this.LsvSelectedFiles.TabIndex = 0;
            this.LsvSelectedFiles.UseCompatibleStateImageBehavior = false;
            this.LsvSelectedFiles.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "File name";
            this.FileName.Width = 178;
            // 
            // FileExtention
            // 
            this.FileExtention.Text = "File extention";
            this.FileExtention.Width = 228;
            // 
            // BtnNewProfile
            // 
            this.BtnNewProfile.Location = new System.Drawing.Point(119, 21);
            this.BtnNewProfile.Name = "BtnNewProfile";
            this.BtnNewProfile.Size = new System.Drawing.Size(75, 62);
            this.BtnNewProfile.TabIndex = 11;
            this.BtnNewProfile.Text = "New profile";
            this.BtnNewProfile.UseVisualStyleBackColor = true;
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.BtnNewProfile);
            this.GroupBox.Controls.Add(this.BtnEditProfile);
            this.GroupBox.Location = new System.Drawing.Point(578, 78);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(200, 100);
            this.GroupBox.TabIndex = 12;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Actions";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtProfileName);
            this.groupBox5.Location = new System.Drawing.Point(163, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(140, 60);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "profile name";
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProfileManager";
            this.Text = "ProfileManager";
            this.Load += new System.EventHandler(this.ProfileManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupBox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbSelectProfile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView LsvSelectedFiles;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileExtention;
        private System.Windows.Forms.Button BtnSelectFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnSelectTargetPath;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BtnSelectSourcePath;
        private System.Windows.Forms.Button BtnEditProfile;
        private System.Windows.Forms.TextBox TxtProfileName;
        private System.Windows.Forms.Button BtnNewProfile;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}