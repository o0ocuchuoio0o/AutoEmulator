using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
                exmap.ExeConfigFilename = @"AutoF.exe.config";
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
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewListReupMobi.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewListReupMobi.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewListReupMobi.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewListReupMobi.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    table.Rows.Add(id);
                }

            }
            if (table.Rows.Count > 0)
            {

                #region //copy template
                foreach (DataRow row in table.Rows)
                {
                    //int idmail = int.Parse(row["ID"].ToString());
                    //DataTable thongtinkenh = new DataTable();
                    //daWS_FakeAuto tt = new daWS_FakeAuto();
                    //thongtinkenh = tt.ChiTietMail(idmail);
                    //DataRow rthongtin = thongtinkenh.Rows[0];
                    //string linkkenhreup = rthongtin["LinkKenhReUp"].ToString();
                    //string ngonngugoc = rthongtin["NgonNguGoc"].ToString();
                    //string ngonnguthay = rthongtin["NgonNguThay"].ToString();
                    //string mail = rthongtin["Mail"].ToString();
                    //string pass = rthongtin["Pass"].ToString();
                    //string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();
                    //string themtieude = rthongtin["ThemTieuDe"].ToString();
                    //string bottieude = rthongtin["BotTieuDe"].ToString();
                    //string themmota = rthongtin["ThemMoTa"].ToString();
                    //string themtag = rthongtin["ThemTag"].ToString();
                    //int soluongup = int.Parse(rthongtin["SoLuongVideoUp"].ToString());
                    //try
                    //{
                    //    #region // trước khi đọc file tắt hết ứng dụng 
                    //    try
                    //    {
                    //        foreach (Process proc in Process.GetProcessesByName("dnplayer"))
                    //        {
                    //            proc.Kill();
                    //        }
                    //    }
                    //    catch { }
                    //    #endregion

                    //    #region đọc các file config random của hệ thống
                    //    string path = txtpathldplayer.Text.Replace("dnplayer.exe", "");
                    //    string pathconfig = path + @"vms\config\leidian" + idmail.ToString() + ".config";                      
                    //    #endregion
                    //    #region // đọc dữ liệu template config

                    //    string pathtemplate = Application.StartupPath + @"\TemplateEmulator\leidian0.config";
                    //    string texttemplate = File.ReadAllText(pathtemplate);
                      
                    //    #endregion
                    //    File.Copy(pathtemplate, pathconfig, true);

                    //    #region // thuc hien copy cac file may ao
                    //    string path_vm = path + @"vms\leidian" + idmail.ToString();
                    //    //hamxoafile(path_vm);
                    //    //string path_vmconfig = Application.StartupPath + @"\TemplateEmulator\leidian0";
                    //    //CopyFolder(@path_vmconfig, path_vm);
                    //    #endregion                     
                    //    if (MessageBox.Show("Done! Can you next login?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    //     == DialogResult.Yes)
                    //    {
                    //        Process p = new Process();
                    //        p.StartInfo.FileName = txtpathldplayer.Text;
                    //        p.StartInfo.Arguments = "index =" + idmail.ToString();
                    //        p.Start();
                    //        Thread.Sleep(2000);
                    //        p.WaitForInputIdle();
                    //        SetParent(p.MainWindowHandle, this.panelmobile.Handle);
                    //        SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                    //        MoveWindow(p.MainWindowHandle, 0, -35, 367, 654, true);
                    //        Thread.Sleep(2000);
                    //    }

                    //}
                    //catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần tạo emulator", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
