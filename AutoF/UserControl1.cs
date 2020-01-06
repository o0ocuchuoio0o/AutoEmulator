using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace AutoF
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        [DllImport("user32.dll")]
        public static extern long SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;

        private void UserControl1_Load(object sender, EventArgs e)
        {
           
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ChangZhi\LDPlayer\dnplayer.exe";
            p.StartInfo.Arguments = "index =1";
            p.Start();
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.panel1.Handle);
            SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
            MoveWindow(p.MainWindowHandle, 0, -35, 367, 654, true);
        }
    }
}
