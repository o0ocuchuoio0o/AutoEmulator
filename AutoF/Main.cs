using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoF
{
    public partial class Main : Form
    {
        public Main()
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

        private void btnchaymayao_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++)
            {
                Test a = new Test();
                flowLayoutPanel.Controls.Add(a);
                Process p = new Process();
                p.StartInfo.FileName = @"C:\ChangZhi\LDPlayer\dnplayer.exe";
                p.StartInfo.Arguments = "index ="+i.ToString();
                p.Start();
                p.WaitForInputIdle();
                Thread.Sleep(3000);
                SetParent(p.MainWindowHandle, a.Handle);
                SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                MoveWindow(p.MainWindowHandle, 0, 0, 320, 480, true);
                Thread.Sleep(1000);
            }


        }

    
        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnpathLDplay_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.exe)|*.exe";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select path elumator";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                txtpathldplayer.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("PathLDPlayer");
                cf.AppSettings.Settings.Add("PathLDPlayer", txtpathldplayer.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void btntaoemulator_Click(object sender, EventArgs e)
        {

        }

        private void btnrandomconfig_Click(object sender, EventArgs e)
        {

        }

        private void btnrunemulator_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            #region // tat sau khi dang nhap thanh cong
            try
            {
                foreach (Process proc in Process.GetProcessesByName("dnplayer"))
                {
                    proc.Kill();
                }
            }
            catch { }
            #endregion
        }

        private void btnloginmobile_Click(object sender, EventArgs e)
        {

        }
    }
}
