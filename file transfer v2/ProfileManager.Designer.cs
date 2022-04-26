
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileManager));
            this.CmbSelectProfile = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDateTimeFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PbSaveProfile = new System.Windows.Forms.PictureBox();
            this.PbAddNewProfile = new System.Windows.Forms.PictureBox();
            this.PbDeleteProfile = new System.Windows.Forms.PictureBox();
            this.TxtProfileName = new System.Windows.Forms.TextBox();
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
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSaveProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAddNewProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDeleteProfile)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbSelectProfile
            // 
            this.CmbSelectProfile.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSelectProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSelectProfile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSelectProfile.FormattingEnabled = true;
            this.CmbSelectProfile.Location = new System.Drawing.Point(7, 47);
            this.CmbSelectProfile.Name = "CmbSelectProfile";
            this.CmbSelectProfile.Size = new System.Drawing.Size(121, 24);
            this.CmbSelectProfile.TabIndex = 0;
            this.CmbSelectProfile.SelectedIndexChanged += new System.EventHandler(this.CmbSelectProfile_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtDateTimeFormat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PbSaveProfile);
            this.groupBox1.Controls.Add(this.PbAddNewProfile);
            this.groupBox1.Controls.Add(this.PbDeleteProfile);
            this.groupBox1.Controls.Add(this.TxtProfileName);
            this.groupBox1.Controls.Add(this.CmbSelectProfile);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Date time format";
            // 
            // TxtDateTimeFormat
            // 
            this.TxtDateTimeFormat.Location = new System.Drawing.Point(278, 49);
            this.TxtDateTimeFormat.Name = "TxtDateTimeFormat";
            this.TxtDateTimeFormat.Size = new System.Drawing.Size(118, 22);
            this.TxtDateTimeFormat.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select a profile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Profile name";
            // 
            // PbSaveProfile
            // 
            this.PbSaveProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbSaveProfile.Image = ((System.Drawing.Image)(resources.GetObject("PbSaveProfile.Image")));
            this.PbSaveProfile.Location = new System.Drawing.Point(621, 21);
            this.PbSaveProfile.Name = "PbSaveProfile";
            this.PbSaveProfile.Size = new System.Drawing.Size(57, 50);
            this.PbSaveProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbSaveProfile.TabIndex = 8;
            this.PbSaveProfile.TabStop = false;
            this.PbSaveProfile.Click += new System.EventHandler(this.PbSaveProfile_Click);
            // 
            // PbAddNewProfile
            // 
            this.PbAddNewProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbAddNewProfile.Image = ((System.Drawing.Image)(resources.GetObject("PbAddNewProfile.Image")));
            this.PbAddNewProfile.Location = new System.Drawing.Point(465, 21);
            this.PbAddNewProfile.Name = "PbAddNewProfile";
            this.PbAddNewProfile.Size = new System.Drawing.Size(57, 50);
            this.PbAddNewProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbAddNewProfile.TabIndex = 13;
            this.PbAddNewProfile.TabStop = false;
            this.PbAddNewProfile.Click += new System.EventHandler(this.PbAddNewProfile_Click);
            // 
            // PbDeleteProfile
            // 
            this.PbDeleteProfile.BackColor = System.Drawing.SystemColors.Control;
            this.PbDeleteProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbDeleteProfile.Image = ((System.Drawing.Image)(resources.GetObject("PbDeleteProfile.Image")));
            this.PbDeleteProfile.Location = new System.Drawing.Point(544, 21);
            this.PbDeleteProfile.Name = "PbDeleteProfile";
            this.PbDeleteProfile.Size = new System.Drawing.Size(57, 50);
            this.PbDeleteProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbDeleteProfile.TabIndex = 8;
            this.PbDeleteProfile.TabStop = false;
            this.PbDeleteProfile.Click += new System.EventHandler(this.PbDeleteProfile_Click);
            // 
            // TxtProfileName
            // 
            this.TxtProfileName.Location = new System.Drawing.Point(137, 49);
            this.TxtProfileName.Name = "TxtProfileName";
            this.TxtProfileName.Size = new System.Drawing.Size(128, 22);
            this.TxtProfileName.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LsvSelectedFiles);
            this.groupBox2.Controls.Add(this.BtnSelectFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 190);
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
            this.LsvSelectedFiles.Size = new System.Drawing.Size(573, 163);
            this.LsvSelectedFiles.TabIndex = 0;
            this.LsvSelectedFiles.UseCompatibleStateImageBehavior = false;
            this.LsvSelectedFiles.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "File name";
            this.FileName.Width = 291;
            // 
            // FileExtention
            // 
            this.FileExtention.Text = "File extention";
            this.FileExtention.Width = 237;
            // 
            // BtnSelectFiles
            // 
            this.BtnSelectFiles.Location = new System.Drawing.Point(585, 21);
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
            this.groupBox3.Location = new System.Drawing.Point(12, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(687, 111);
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
            this.TxtSourcePath.Size = new System.Drawing.Size(495, 22);
            this.TxtSourcePath.TabIndex = 8;
            // 
            // BtnSelectTargetPath
            // 
            this.BtnSelectTargetPath.Location = new System.Drawing.Point(639, 62);
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
            this.TxtTargetPath.Size = new System.Drawing.Size(495, 22);
            this.TxtTargetPath.TabIndex = 9;
            // 
            // BtnSelectSourcePath
            // 
            this.BtnSelectSourcePath.Location = new System.Drawing.Point(639, 25);
            this.BtnSelectSourcePath.Name = "BtnSelectSourcePath";
            this.BtnSelectSourcePath.Size = new System.Drawing.Size(39, 28);
            this.BtnSelectSourcePath.TabIndex = 4;
            this.BtnSelectSourcePath.Text = "...";
            this.BtnSelectSourcePath.UseVisualStyleBackColor = true;
            this.BtnSelectSourcePath.Click += new System.EventHandler(this.BtnSelectSourcePath_Click);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 2500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 412);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProfileManager";
            this.Text = "ProfileManager";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.ProfileManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSaveProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAddNewProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDeleteProfile)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TextBox TxtProfileName;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.PictureBox PbAddNewProfile;
        private System.Windows.Forms.PictureBox PbDeleteProfile;
        private System.Windows.Forms.PictureBox PbSaveProfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDateTimeFormat;
    }
}