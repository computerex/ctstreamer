namespace ctstreamer
{
    partial class frmTargetName
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.txttargetwindow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "target window";
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(366, 25);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 23);
            this.btnsubmit.TabIndex = 2;
            this.btnsubmit.Text = "Enter";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // txttargetwindow
            // 
            this.txttargetwindow.AcceptsReturn = true;
            this.txttargetwindow.Location = new System.Drawing.Point(12, 25);
            this.txttargetwindow.Name = "txttargetwindow";
            this.txttargetwindow.Size = new System.Drawing.Size(348, 20);
            this.txttargetwindow.TabIndex = 1;
            // 
            // frmTargetName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 62);
            this.Controls.Add(this.txttargetwindow);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTargetName";
            this.Text = "Enter target window name";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTargetName_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.TextBox txttargetwindow;
    }
}