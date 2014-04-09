using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ctstreamer
{
    public partial class frmServerInfo : Form
    {
        private Form1 parent;
        public frmServerInfo()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        public frmServerInfo(Form1 parent) : this()
        {
            this.parent = parent;
        }
        private void frmServerInfo_Load(object sender, EventArgs e)
        {
            try
            {
                Form1.ServerInfo info = new Form1.ServerInfo(" ");
                info = parent.loadFromFile();
                txtUsername.Text = info.username;
                txtpassword.Text = info.password;
                txtserver.Text = info.loginUrl.Substring(0,info.loginUrl.LastIndexOf("/"));
            }
            catch
            {
            }
        }

        private void btnset_Click(object sender, EventArgs e)
        {
            Form1.ServerInfo info = new Form1.ServerInfo(" ");
            info.username = txtUsername.Text;
            info.password = txtpassword.Text;
            info.loginUrl = txtserver.Text + "/login.php";
            info.loginQuery = "username=" + info.username + "&password=" + info.password;
            info.uploadUrl = txtserver.Text + "/simupdate.php";
            info.pollUrl = txtserver.Text + "/streampoll.php";
            info.pollData = " ";
            parent.setServerInfo(info);
            this.Close();
        }
    }
}
