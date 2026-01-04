using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WindowsErrorChecker
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer loadingTimer;
        private int loadingDots = 1;

        private CancellationTokenSource scanCts;
        private bool isScanning = false;

        // ===========================MOVE-DRAG==========================
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void EnableDrag(Control c)
        {
            c.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN,
                                (IntPtr)HTCAPTION, IntPtr.Zero);
                }
            };
        }

        public Form1()
        {
            InitializeComponent();
            EnableDrag(this);       
            EnableDrag(Title);    
            EnableDrag(txtcpu);
            EnableDrag(txtgpu);
            EnableDrag(txtram);
            EnableDrag(txtdisk);
            linkLabel1.Text = "\uE8BB";// Close
            linkLabel2.Text = "\uE921"; // Minimize
            if (this.WindowState == FormWindowState.Normal)
            {
                linkLabel2.Text = "\uE922"; // Maximize
            }
            else
            {
                linkLabel2.Text = "\uE923"; // Restore
            }


            InitLoading();

            this.FormClosing += Form1_FormClosing;


        }
        // ===========================resize form==========================
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;

            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            const int RESIZE_HANDLE_SIZE = 8; // lebar area resize

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                if ((int)m.Result == HTCLIENT)
                {
                    Point p = PointToClient(new Point(m.LParam.ToInt32()));

                    bool left = p.X <= RESIZE_HANDLE_SIZE;
                    bool right = p.X >= ClientSize.Width - RESIZE_HANDLE_SIZE;
                    bool top = p.Y <= RESIZE_HANDLE_SIZE;
                    bool bottom = p.Y >= ClientSize.Height - RESIZE_HANDLE_SIZE;

                    if (left && top) m.Result = (IntPtr)HTTOPLEFT;
                    else if (right && top) m.Result = (IntPtr)HTTOPRIGHT;
                    else if (left && bottom) m.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (right && bottom) m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else if (left) m.Result = (IntPtr)HTLEFT;
                    else if (right) m.Result = (IntPtr)HTRIGHT;
                    else if (top) m.Result = (IntPtr)HTTOP;
                    else if (bottom) m.Result = (IntPtr)HTBOTTOM;
                }
                return;
            }

            base.WndProc(ref m);
        }



        // ===========================
        // LOADING TEXT
        // ===========================
        private void InitLoading()
        {
            loading.Visible = false;
            loadingTimer = new System.Windows.Forms.Timer();
            loadingTimer.Interval = 400;
            loadingTimer.Tick += delegate
            {
                loadingDots = loadingDots >= 4 ? 1 : loadingDots + 1;
                loading.Text = "Loading" + new string('.', loadingDots);
            };
        }

        private void StartLoading()
        {
            loadingDots = 1;
            loading.Text = "Loading.";
            loading.Visible = true;
            loadingTimer.Start();
        }

        private void StopLoading()
        {
            loadingTimer.Stop();
            loading.Visible = false;
        }

        // ===========================
        // BUTTON CLICK
        // ===========================
        private async void button1_Click(object sender, EventArgs e)
        {
            if (isScanning)
                return;

            string msg = "Scanning system errors...\r\nPlease wait.";

            txtcpu.Text = msg;
            txtgpu.Text = msg;
            txtram.Text = msg;
            txtdisk.Text = msg;

            scanCts = new CancellationTokenSource();
            isScanning = true;
            StartLoading();
            SetScanButtonState(button1, true);

            try
            {
                var result = await Task.Run(
                    () => ScanErrors(scanCts.Token),
                    scanCts.Token
                );

                txtcpu.Text = result.cpu.Length > 0 ? result.cpu : "No CPU errors detected.";
                txtram.Text = result.ram.Length > 0 ? result.ram : "No RAM errors detected.";
                txtdisk.Text = result.disk.Length > 0 ? result.disk : "No Disk errors detected.";
                txtgpu.Text = result.gpu.Length > 0 ? result.gpu : "No GPU errors detected.";
            }
            catch (OperationCanceledException)
            {
                txtcpu.Text = "Scan cancelled.";
                txtgpu.Text = "Scan cancelled.";
                txtram.Text = "Scan cancelled.";
                txtdisk.Text = "Scan cancelled.";
            }
            finally
            {
                StopLoading();
                SetScanButtonState(button1, false);
                isScanning = false;

                if (scanCts != null)
                {
                    scanCts.Dispose();
                    scanCts = null;
                }
            }
        }

        // ===========================
        // FORM CLOSING
        // ===========================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isScanning)
                return;

            DialogResult r = MessageBox.Show(
                "Scan is still running.\r\nForce exit?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (scanCts != null)
                scanCts.Cancel();
        }
        // ===========================Mouse DOWN DISABLE BUTTON ==========================
        private void SetScanButtonState(Button btn, bool scanning)
        {
            btn.ForeColor = scanning
                ? Color.FromArgb(0, 174, 219)
                : Color.White;

            btn.BackColor = scanning
                ? Color.FromArgb(40, 45, 55)
                : Color.FromArgb(30, 36, 44);

            btn.Cursor = scanning
                ? Cursors.No
                : Cursors.Hand;
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isScanning)
                ((Control)sender).Capture = false;
        }


        // ===========================
        // SCAN EVENT LOG
        // ===========================
        private (string cpu, string ram, string disk, string gpu)
            ScanErrors(CancellationToken token)
        {
            StringBuilder cpu = new StringBuilder();
            StringBuilder ram = new StringBuilder();
            StringBuilder disk = new StringBuilder();
            StringBuilder gpu = new StringBuilder();

            EventLog log = new EventLog("System");

            foreach (EventLogEntry e in log.Entries)
            {
                token.ThrowIfCancellationRequested();

                if (e.EntryType != EventLogEntryType.Error &&
                    e.EntryType != EventLogEntryType.Warning)
                    continue;

                string src = e.Source.ToLower();
                string msg = e.Message.ToLower();

                if (e.Source == "BugCheck")
                {
                    cpu.AppendLine(FormatBugCheck(e));
                }
                else if (src.Contains("whea"))
                {
                    cpu.AppendLine(Format(e));
                }
                else if (src.Contains("memory") || msg.Contains("page fault"))
                {
                    ram.AppendLine(Format(e));
                }
                else if (src.Contains("disk") || src.Contains("stor") || msg.Contains("bad block"))
                {
                    disk.AppendLine(FormatDisk(e));
                }
                else if (src.Contains("nvlddmkm") || src.Contains("amdkmdag") || msg.Contains("tdr"))
                {
                    gpu.AppendLine(FormatGpu(e));
                }
            }

            return (cpu.ToString(), ram.ToString(), disk.ToString(), gpu.ToString());
        }

        // ===========================
        // BUGCHECK
        // ===========================
        private string FormatBugCheck(EventLogEntry e)
        {
            string code = ExtractBugCheckCode(e.Message);
            return
                "[" + e.TimeGenerated + "]\r\n" +
                "Source : BugCheck\r\n" +
                "Code   : " + code + "\r\n" +
                new string('-', 60) + "\r\n";
        }

        private string ExtractBugCheckCode(string msg)
        {
            Match m = Regex.Match(msg, @"0x[0-9a-fA-F]{8}");
            return m.Success ? m.Value.ToUpper() : "UNKNOWN";
        }

        // ===========================
        // FORMAT COMMON
        // ===========================
        private string Format(EventLogEntry e)
        {
            return
                "[" + e.TimeGenerated + "]\r\n" +
                "Source   : " + e.Source + "\r\n" +
                "Event ID : " + e.InstanceId + "\r\n" +
                e.Message + "\r\n" +
                new string('-', 60) + "\r\n";
        }

        // ===========================
        // GPU
        // ===========================
        private string FormatGpu(EventLogEntry e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[" + e.TimeGenerated + "]");
            sb.AppendLine("Source : " + e.Source);
            sb.AppendLine("Event  : " + e.InstanceId);
            sb.AppendLine(e.Message);
            sb.AppendLine(new string('-', 60));
            return sb.ToString();
        }

        // ===========================
        // DISK
        // ===========================
        private string FormatDisk(EventLogEntry e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[" + e.TimeGenerated + "]");
            sb.AppendLine("Source : " + e.Source);
            sb.AppendLine("Event  : " + e.InstanceId);
            sb.AppendLine(GetDiskInfo(e.Message));
            sb.AppendLine(e.Message);
            sb.AppendLine(new string('-', 60));
            return sb.ToString();
        }

        private string GetDiskInfo(string msg)
        {
            Match m = Regex.Match(msg, @"harddisk(\d+)", RegexOptions.IgnoreCase);
            if (!m.Success)
                return "Disk : UNKNOWN";

            int index = int.Parse(m.Groups[1].Value);

            try
            {
                ManagementObjectSearcher s =
                    new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Index=" + index);

                foreach (ManagementObject d in s.Get())
                {
                    return
                        "Disk Index : " + index + "\r\n" +
                        "Model      : " + d["Model"];
                }
            }
            catch { }

            return "Disk Index : " + index;
        }

        private void CPU_Click(object sender, EventArgs e)
        {
            txtcpu.BringToFront();
            CPU.FlatStyle = FlatStyle.Flat;
        }

        private void GPU_Click(object sender, EventArgs e)
        {
            txtgpu.BringToFront();
            GPU.FlatStyle = FlatStyle.Flat;
        }

        private void RAM_Click(object sender, EventArgs e)
        {
            txtram.BringToFront();
            RAM.FlatStyle = FlatStyle.Flat;
        }

        private void DISK_Click(object sender, EventArgs e)
        {
            txtdisk.BringToFront();
            DISK.FlatStyle = FlatStyle.Flat;
        }

        private void CPU_Leave(object sender, EventArgs e)
        {
            CPU.FlatStyle = FlatStyle.Popup;
        }

        private void GPU_Leave(object sender, EventArgs e)
        {
            GPU.FlatStyle = FlatStyle.Popup;
        }

        private void RAM_Leave(object sender, EventArgs e)
        {
            RAM.FlatStyle = FlatStyle.Popup;
        }

        private void DISK_Leave(object sender, EventArgs e)
        {
            DISK.FlatStyle = FlatStyle.Popup;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                linkLabel2.Text = "\uE923"; // Restore
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                linkLabel2.Text = "\uE922"; // Maximize
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!isScanning)
                this.Close();

            DialogResult r = MessageBox.Show(
                "Scan is still running.\r\nForce exit?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.No)
            {                
                return;
            }

            if (scanCts != null)
                scanCts.Cancel();
                this.Close();
        }
    }
}
