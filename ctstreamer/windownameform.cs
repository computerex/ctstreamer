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
    public partial class frmTargetName : Form
    {
        private Form1 parent; 
        public frmTargetName()
        {
            InitializeComponent();
            txttargetwindow.Focus() ;
        }
        public frmTargetName(Form1 parent) : this()
        {
            this.parent = parent;
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            setwindow();
        }
        private void setwindow()
        {
            IntPtr hwnd = Form1.FindWindowByCaption(IntPtr.Zero, txttargetwindow.Text);
            if (Form1.IsWindow(hwnd) == 0)
            {
                MessageBox.Show("Please enter a valid window");
                return;
            }
            parent.setWindow(hwnd);
            this.Close();
        }
        private void frmTargetName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                setwindow();
                e.Handled = true;
            }
        }
    }
}
