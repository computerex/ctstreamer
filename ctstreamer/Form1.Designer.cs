namespace ctstreamer
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btntogglestream = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblwindow = new System.Windows.Forms.Label();
            this.btnDesktop = new System.Windows.Forms.Button();
            this.btnwindowname = new System.Windows.Forms.Button();
            this.btnsettings = new System.Windows.Forms.Button();
            this.txtresx = new System.Windows.Forms.TextBox();
            this.txtresy = new System.Windows.Forms.TextBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btntogglestream
            // 
            this.btntogglestream.Location = new System.Drawing.Point(712, 28);
            this.btntogglestream.Name = "btntogglestream";
            this.btntogglestream.Size = new System.Drawing.Size(75, 20);
            this.btntogglestream.TabIndex = 0;
            this.btntogglestream.Text = "Stream";
            this.btntogglestream.UseVisualStyleBackColor = true;
            this.btntogglestream.Click += new System.EventHandler(this.btntogglestream_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(532, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(174, 20);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select Window";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblwindow
            // 
            this.lblwindow.AutoSize = true;
            this.lblwindow.Location = new System.Drawing.Point(529, 9);
            this.lblwindow.Name = "lblwindow";
            this.lblwindow.Size = new System.Drawing.Size(80, 13);
            this.lblwindow.TabIndex = 2;
            this.lblwindow.Text = "Target Window";
            // 
            // btnDesktop
            // 
            this.btnDesktop.Location = new System.Drawing.Point(448, 28);
            this.btnDesktop.Name = "btnDesktop";
            this.btnDesktop.Size = new System.Drawing.Size(75, 20);
            this.btnDesktop.TabIndex = 4;
            this.btnDesktop.Text = "Desktop";
            this.btnDesktop.UseVisualStyleBackColor = true;
            this.btnDesktop.Click += new System.EventHandler(this.btnDesktop_Click);
            // 
            // btnwindowname
            // 
            this.btnwindowname.Location = new System.Drawing.Point(367, 28);
            this.btnwindowname.Name = "btnwindowname";
            this.btnwindowname.Size = new System.Drawing.Size(75, 20);
            this.btnwindowname.TabIndex = 5;
            this.btnwindowname.Text = "By Name";
            this.btnwindowname.UseVisualStyleBackColor = true;
            this.btnwindowname.Click += new System.EventHandler(this.btnwindowname_Click);
            // 
            // btnsettings
            // 
            this.btnsettings.Location = new System.Drawing.Point(4, 28);
            this.btnsettings.Name = "btnsettings";
            this.btnsettings.Size = new System.Drawing.Size(75, 20);
            this.btnsettings.TabIndex = 6;
            this.btnsettings.Text = "settings";
            this.btnsettings.UseVisualStyleBackColor = true;
            this.btnsettings.Click += new System.EventHandler(this.btnsettings_Click);
            // 
            // txtresx
            // 
            this.txtresx.Location = new System.Drawing.Point(85, 28);
            this.txtresx.Name = "txtresx";
            this.txtresx.Size = new System.Drawing.Size(100, 20);
            this.txtresx.TabIndex = 7;
            this.txtresx.Text = "960";
            // 
            // txtresy
            // 
            this.txtresy.Location = new System.Drawing.Point(191, 28);
            this.txtresy.Name = "txtresy";
            this.txtresy.Size = new System.Drawing.Size(100, 20);
            this.txtresy.TabIndex = 8;
            this.txtresy.Text = "540";
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(294, 28);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(67, 20);
            this.btnupdate.TabIndex = 9;
            this.btnupdate.Text = "update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 67);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.txtresy);
            this.Controls.Add(this.txtresx);
            this.Controls.Add(this.btnsettings);
            this.Controls.Add(this.btnwindowname);
            this.Controls.Add(this.btnDesktop);
            this.Controls.Add(this.lblwindow);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btntogglestream);
            this.Name = "Form1";
            this.Text = "CTStreamer";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btntogglestream;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblwindow;
        private System.Windows.Forms.Button btnDesktop;
        private System.Windows.Forms.Button btnwindowname;
        private System.Windows.Forms.Button btnsettings;
        private System.Windows.Forms.TextBox txtresx;
        private System.Windows.Forms.TextBox txtresy;
        private System.Windows.Forms.Button btnupdate;
    }
}

