
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
            this.components = new System.ComponentModel.Container();
            this.CmbSelectProfile = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LsvSelectedFiles = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileExtention = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnSelectFiles = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSourcePath = new System.Windows.Forms.TextBox();
            this.BtnSelectTargetPath = new System.Windows.Forms.Button();
            this.TxtTargetPath = new System.Windows.Forms.TextBox();
            this.BtnSelectSourcePath = new System.Windows.Forms.Button();
            this.BtnEditProfile = new System.Windows.Forms.Button();
            this.TxtProfileName = new System.Windows.Forms.TextBox();
            this.BtnNewProfile = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbSelectProfile
            // 
            this.CmbSelectProfile.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSelectProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSelectProfile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSelectProfile.FormattingEnabled = true;
            this.CmbSelectProfile.Location = new System.Drawing.Point(6, 21);
            this.CmbSelectProfile.Name = "CmbSelectProfile";
            this.CmbSelectProfile.Size = new System.Drawing.Size(121, 24);
            this.CmbSelectProfile.TabIndex = 0;
            this.CmbSelectProfile.SelectedIndexChanged += new System.EventHandler(this.CmbSelectProfile_SelectedIndexChanged);
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
            this.groupBox2.Size = new System.Drawing.Size(536, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File selection";
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
            this.FileExtention.Width = 237;
            // 
            // BtnSelectFiles
            // 
            this.BtnSelectFiles.Location = new System.Drawing.Point(436, 21);
            this.BtnSelectFiles.Name = "BtnSelectFiles";
            this.BtnSelectFiles.Size = new System.Drawing.Size(93, 52);
            this.BtnSelectFiles.TabIndex = 6;
            this.BtnSelectFiles.Text = "Select files";
            this.BtnSelectFiles.UseVisualStyleBackColor = true;
            this.BtnSelectFiles.Click += new System.EventHandler(this.BtnSelectFiles_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TxtSourcePath);
            this.groupBox3.Controls.Add(this.BtnSelectTargetPath);
            this.groupBox3.Controls.Add(this.TxtTargetPath);
            this.groupBox3.Controls.Add(this.BtnSelectSourcePath);
            this.groupBox3.Location = new System.Drawing.Point(12, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 111);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Path selection";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select source path";
            // 
            // TxtSourcePath
            // 
            this.TxtSourcePath.Location = new System.Drawing.Point(138, 28);
            this.TxtSourcePath.Name = "TxtSourcePath";
            this.TxtSourcePath.ReadOnly = true;
            this.TxtSourcePath.Size = new System.Drawing.Size(292, 22);
            this.TxtSourcePath.TabIndex = 8;
            // 
            // BtnSelectTargetPath
            // 
            this.BtnSelectTargetPath.Location = new System.Drawing.Point(436, 61);
            this.BtnSelectTargetPath.Name = "BtnSelectTargetPath";
            this.BtnSelectTargetPath.Size = new System.Drawing.Size(39, 28);
            this.BtnSelectTargetPath.TabIndex = 5;
            this.BtnSelectTargetPath.Text = "...";
            this.BtnSelectTargetPath.UseVisualStyleBackColor = true;
            this.BtnSelectTargetPath.Click += new System.EventHandler(this.BtnSelectTargetPath_Click);
            // 
            // TxtTargetPath
            // 
            this.TxtTargetPath.Location = new System.Drawing.Point(138, 62);
            this.TxtTargetPath.Name = "TxtTargetPath";
            this.TxtTargetPath.ReadOnly = true;
            this.TxtTargetPath.Size = new System.Drawing.Size(292, 22);
            this.TxtTargetPath.TabIndex = 9;
            // 
            // BtnSelectSourcePath
            // 
            this.BtnSelectSourcePath.Location = new System.Drawing.Point(436, 27);
            this.BtnSelectSourcePath.Name = "BtnSelectSourcePath";
            this.BtnSelectSourcePath.Size = new System.Drawing.Size(39, 28);
            this.BtnSelectSourcePath.TabIndex = 4;
            this.BtnSelectSourcePath.Text = "...";
            this.BtnSelectSourcePath.UseVisualStyleBackColor = true;
            this.BtnSelectSourcePath.Click += new System.EventHandler(this.BtnSelectSourcePath_Click);
            // 
            // BtnEditProfile
            // 
            this.BtnEditProfile.Location = new System.Drawing.Point(554, 317);
            this.BtnEditProfile.Name = "BtnEditProfile";
            this.BtnEditProfile.Size = new System.Drawing.Size(102, 62);
            this.BtnEditProfile.TabIndex = 7;
            this.BtnEditProfile.Text = "save profile";
            this.BtnEditProfile.UseVisualStyleBackColor = true;
            this.BtnEditProfile.Click += new System.EventHandler(this.BtnEditProfile_Click);
            // 
            // TxtProfileName
            // 
            this.TxtProfileName.Location = new System.Drawing.Point(6, 23);
            this.TxtProfileName.Name = "TxtProfileName";
            this.TxtProfileName.Size = new System.Drawing.Size(128, 22);
            this.TxtProfileName.TabIndex = 10;
            // 
            // BtnNewProfile
            // 
            this.BtnNewProfile.Location = new System.Drawing.Point(310, 15);
            this.BtnNewProfile.Name = "BtnNewProfile";
            this.BtnNewProfile.Size = new System.Drawing.Size(75, 62);
            this.BtnNewProfile.TabIndex = 11;
            this.BtnNewProfile.Text = "create new profile";
            this.BtnNewProfile.UseVisualStyleBackColor = true;
            this.BtnNewProfile.Click += new System.EventHandler(this.BtnNewProfile_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(401, 14);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(75, 63);
            this.btnDeleteProject.TabIndex = 12;
            this.btnDeleteProject.Text = "Delete profile";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtProfileName);
            this.groupBox5.Location = new System.Drawing.Point(151, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(140, 60);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "profile name";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 395);
            this.Controls.Add(this.BtnNewProfile);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.BtnEditProfile);
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
        private System.Windows.Forms.TextBox TxtSourcePath;
        private System.Windows.Forms.Button BtnSelectTargetPath;
        private System.Windows.Forms.TextBox TxtTargetPath;
        private System.Windows.Forms.Button BtnSelectSourcePath;
        private System.Windows.Forms.Button BtnEditProfile;
        private System.Windows.Forms.TextBox TxtProfileName;
        private System.Windows.Forms.Button BtnNewProfile;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Timer timer1;
    }
}