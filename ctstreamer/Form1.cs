using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace ctstreamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern int IsWindow(IntPtr wnd);
        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMax);
        [DllImport("ctstreamerlib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void initstreamer(IntPtr hwnd, [MarshalAs(UnmanagedType.LPStr)] string username, 
                                                     [MarshalAs(UnmanagedType.LPStr)] string pwd,
                                                     [MarshalAs(UnmanagedType.LPStr)] string uploadurl, 
                                                     [MarshalAs(UnmanagedType.LPStr)] string loginurl,
                                                     [MarshalAs(UnmanagedType.LPStr)] string logindata,
                                                     [MarshalAs(UnmanagedType.LPStr)] string pollurl, 
                                                     [MarshalAs(UnmanagedType.LPStr)] string polldata);
        [DllImport("ctstreamerlib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void changeWindow(IntPtr newWindow);
        [DllImport("ctstreamerlib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cleanup();
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("ctstreamerlib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stream();
        [DllImport("ctstreamerlib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int timeoutvalue();
        [DllImport("ctstreamerlib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int setres(int width, int height);
        [DllImport("user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        private IntPtr targethwnd;
        private bool selecting;
        public ServerInfo info; 
        public struct ServerInfo
        {
            public ServerInfo(String init)
            {
                uploadUrl = loginQuery = loginUrl = pollData = pollUrl = username = password = init;
            }
            public string uploadUrl, loginUrl, loginQuery, pollUrl, pollData, username, password;
        }
        private void dump_info()
        {
            StreamWriter sw = new StreamWriter("settings.txt", false, Encoding.ASCII);
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", info.uploadUrl, info.loginUrl, info.loginQuery, info.pollUrl, info.pollData, info.username, info.password);
            sw.Close();
        }
        public void getSettings()
        {
            frmServerInfo fm = new frmServerInfo(this);
            fm.ShowDialog();
        }
        public void setServerInfo(ServerInfo info)
        {
            this.info = info; 
        }
        public ServerInfo loadFromFile()
        {
            ServerInfo info = new ServerInfo(" ");
            String line;
            StreamReader file = new StreamReader("settings.txt");
            line = file.ReadLine();
            file.Close();
            string[] data = line.Split(",".ToCharArray());
            info.uploadUrl = data[0];
            info.loginUrl = data[1];
            info.loginQuery = data[2];
            info.pollUrl = data[3];
            info.pollData = data[4];
            info.username = data[5];
            info.password = data[6];
            return info;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // read settings from file
            try
            {
                info = loadFromFile();
            }
            catch
            {
                getSettings();
            }
            targethwnd = GetDesktopWindow();
            selecting=false;
            initstreamer(targethwnd, info.username, info.password, info.uploadUrl, info.loginUrl, info.loginQuery, info.pollUrl, info.pollData);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = timeoutvalue();
        }
        public void setWindow(IntPtr newWindow)
        {
            targethwnd = newWindow;
            StringBuilder name = new StringBuilder(256);
            GetWindowText(targethwnd, name, 256);
            lblwindow.Text = name.ToString();
            selecting = false;
            btnSelect.Text = "Select Window";
            changeWindow(targethwnd);
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            stream();
            timer1.Interval = timeoutvalue();
        }

        private void btntogglestream_Click(object sender, EventArgs e)
        {
            if (IsWindow(targethwnd) == 0 && !timer1.Enabled )
            {
                MessageBox.Show("Please select a valid window before streaming");
                return;
            }
            timer1.Enabled = !timer1.Enabled;
            //timer2.Enabled = timer1.Enabled;
            btntogglestream.Text = (timer1.Enabled ? "Stop" : "Start");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (selecting)
            {
                System.Threading.Thread.Sleep(1000);
                setWindow(GetForegroundWindow());
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (selecting)
            {
                btnSelect.Text = "Select Window";
                selecting = false;
            }
            else
            {
                btnSelect.Text = "Stop Selection";
                selecting = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            cleanup();
            dump_info();
        }

        private void btnDesktop_Click(object sender, EventArgs e)
        {
            targethwnd = GetDesktopWindow();
            lblwindow.Text = "Desktop";
            changeWindow(targethwnd);
        }

        private void btnwindowname_Click(object sender, EventArgs e)
        {
            frmTargetName frm = new frmTargetName(this);
            frm.ShowDialog();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            getSettings();
            initstreamer(targethwnd, info.username, info.password, info.uploadUrl, info.loginUrl, info.loginQuery, info.pollUrl, info.pollData);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int width = int.Parse(txtresx.Text);
            int height = int.Parse(txtresy.Text);
            if (width <= 0 || height <= 0)
            {
                MessageBox.Show("enter a valid resolution");
                return;
            }
            setres(width, height);
        }
    }
}
