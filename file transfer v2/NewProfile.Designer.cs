
namespace file_transfer_v2
{
    partial class NewProfile
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
            this.TxtProjectName = new System.Windows.Forms.TextBox();
            this.LsvSelectedFiles = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileExtention = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.BtnSourcePath = new System.Windows.Forms.Button();
            this.BtnTargetPath = new System.Windows.Forms.Button();
            this.BtnSelectFiles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCreateProfile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtProjectName
            // 
            this.TxtProjectName.Location = new System.Drawing.Point(106, 27);
            this.TxtProjectName.Name = "TxtProjectName";
            this.TxtProjectName.Size = new System.Drawing.Size(181, 22);
            this.TxtProjectName.TabIndex = 0;
            // 
            // LsvSelectedFiles
            // 
            this.LsvSelectedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileExtention});
            this.LsvSelectedFiles.GridLines = true;
            this.LsvSelectedFiles.HideSelection = false;
            this.LsvSelectedFiles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LsvSelectedFiles.Location = new System.Drawing.Point(6, 30);
            this.LsvSelectedFiles.Name = "LsvSelectedFiles";
            this.LsvSelectedFiles.Size = new System.Drawing.Size(345, 152);
            this.LsvSelectedFiles.TabIndex = 1;
            this.LsvSelectedFiles.UseCompatibleStateImageBehavior = false;
            this.LsvSelectedFiles.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "File name";
            this.FileName.Width = 221;
            // 
            // FileExtention
            // 
            this.FileExtention.Text = "File extention";
            this.FileExtention.Width = 114;
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(106, 68);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.ReadOnly = true;
            this.txtSourcePath.Size = new System.Drawing.Size(181, 22);
            this.txtSourcePath.TabIndex = 2;
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Location = new System.Drawing.Point(106, 106);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.ReadOnly = true;
            this.txtTargetPath.Size = new System.Drawing.Size(181, 22);
            this.txtTargetPath.TabIndex = 3;
            // 
            // BtnSourcePath
            // 
            this.BtnSourcePath.Location = new System.Drawing.Point(293, 66);
            this.BtnSourcePath.Name = "BtnSourcePath";
            this.BtnSourcePath.Size = new System.Drawing.Size(42, 23);
            this.BtnSourcePath.TabIndex = 4;
            this.BtnSourcePath.Text = "...";
            this.BtnSourcePath.UseVisualStyleBackColor = true;
            this.BtnSourcePath.Click += new System.EventHandler(this.BtnSourcePath_Click);
            // 
            // BtnTargetPath
            // 
            this.BtnTargetPath.Location = new System.Drawing.Point(293, 105);
            this.BtnTargetPath.Name = "BtnTargetPath";
            this.BtnTargetPath.Size = new System.Drawing.Size(42, 23);
            this.BtnTargetPath.TabIndex = 5;
            this.BtnTargetPath.Text = "...";
            this.BtnTargetPath.UseVisualStyleBackColor = true;
            this.BtnTargetPath.Click += new System.EventHandler(this.BtnTargetPath_Click);
            // 
            // BtnSelectFiles
            // 
            this.BtnSelectFiles.Location = new System.Drawing.Point(366, 30);
            this.BtnSelectFiles.Name = "BtnSelectFiles";
            this.BtnSelectFiles.Size = new System.Drawing.Size(104, 57);
            this.BtnSelectFiles.TabIndex = 6;
            this.BtnSelectFiles.Text = "Select files";
            this.BtnSelectFiles.UseVisualStyleBackColor = true;
            this.BtnSelectFiles.Click += new System.EventHandler(this.BtnSelectFiles_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtProjectName);
            this.groupBox1.Controls.Add(this.txtSourcePath);
            this.groupBox1.Controls.Add(this.BtnTargetPath);
            this.groupBox1.Controls.Add(this.txtTargetPath);
            this.groupBox1.Controls.Add(this.BtnSourcePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 148);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "target path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "project name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "source path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LsvSelectedFiles);
            this.groupBox2.Controls.Add(this.BtnSelectFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 197);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select files";
            // 
            // BtnCreateProfile
            // 
            this.BtnCreateProfile.Location = new System.Drawing.Point(498, 312);
            this.BtnCreateProfile.Name = "BtnCreateProfile";
            this.BtnCreateProfile.Size = new System.Drawing.Size(124, 48);
            this.BtnCreateProfile.TabIndex = 9;
            this.BtnCreateProfile.Text = "Create new profile";
            this.BtnCreateProfile.UseVisualStyleBackColor = true;
            this.BtnCreateProfile.Click += new System.EventHandler(this.BtnCreateProfile_Click);
            // 
            // NewProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 369);
            this.Controls.Add(this.BtnCreateProfile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewProfile";
            this.Text = "NewProfile";
            this.Load += new System.EventHandler(this.NewProfile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtProjectName;
        private System.Windows.Forms.ListView LsvSelectedFiles;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Button BtnSourcePath;
        private System.Windows.Forms.Button BtnTargetPath;
        private System.Windows.Forms.Button BtnSelectFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileExtention;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCreateProfile;
    }
}