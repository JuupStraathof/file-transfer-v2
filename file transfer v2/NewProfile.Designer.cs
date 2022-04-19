
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
            this.components = new System.ComponentModel.Container();
            this.TxtNewProfileName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCreateNewProfile = new System.Windows.Forms.Button();
            this.LblError = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtNewProfileName
            // 
            this.TxtNewProfileName.Location = new System.Drawing.Point(6, 38);
            this.TxtNewProfileName.Name = "TxtNewProfileName";
            this.TxtNewProfileName.Size = new System.Drawing.Size(193, 22);
            this.TxtNewProfileName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblError);
            this.groupBox1.Controls.Add(this.BtnCreateNewProfile);
            this.groupBox1.Controls.Add(this.TxtNewProfileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "profile name";
            // 
            // BtnCreateNewProfile
            // 
            this.BtnCreateNewProfile.Location = new System.Drawing.Point(6, 66);
            this.BtnCreateNewProfile.Name = "BtnCreateNewProfile";
            this.BtnCreateNewProfile.Size = new System.Drawing.Size(193, 50);
            this.BtnCreateNewProfile.TabIndex = 2;
            this.BtnCreateNewProfile.Text = "Create new profile";
            this.BtnCreateNewProfile.UseVisualStyleBackColor = true;
            this.BtnCreateNewProfile.Click += new System.EventHandler(this.BtnCreateNewProfile_Click);
            // 
            // LblError
            // 
            this.LblError.AutoSize = true;
            this.LblError.Location = new System.Drawing.Point(6, 18);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(0, 17);
            this.LblError.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NewProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 152);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewProfile";
            this.Text = "NewProfile";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNewProfileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCreateNewProfile;
        private System.Windows.Forms.Label LblError;
        private System.Windows.Forms.Timer timer1;
    }
}