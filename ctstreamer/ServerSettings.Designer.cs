namespace ctstreamer
{
    partial class frmServerInfo
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.btnset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "username";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(118, 22);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(100, 20);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.Text = "password";
            this.txtpassword.UseSystemPasswordChar = true;
            // 
            // txtserver
            // 
            this.txtserver.Location = new System.Drawing.Point(12, 48);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(100, 20);
            this.txtserver.TabIndex = 2;
            this.txtserver.Text = "server";
            // 
            // btnset
            // 
            this.btnset.Location = new System.Drawing.Point(12, 89);
            this.btnset.Name = "btnset";
            this.btnset.Size = new System.Drawing.Size(100, 23);
            this.btnset.TabIndex = 3;
            this.btnset.Text = "OK";
            this.btnset.UseVisualStyleBackColor = true;
            this.btnset.Click += new System.EventHandler(this.btnset_Click);
            // 
            // frmServerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 124);
            this.Controls.Add(this.btnset);
            this.Controls.Add(this.txtserver);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtUsername);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServerInfo";
            this.Text = "Server Info";
            this.Load += new System.EventHandler(this.frmServerInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Button btnset;
    }
}