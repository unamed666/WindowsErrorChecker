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

            linkLabel1.Text = "\uE8BB"; // Close
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

            const int RESIZE_HANDLE_SIZE = 8; // width of resize area

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
            labelprogress.Visible = false;
            panelProgressBack.Visible = false;
            loadingTimer = new System.Windows.Forms.Timer();
            loadingTimer.Interval = 400;
            loadingTimer.Tick += delegate
            {
                loadingDots = loadingDots >= 7 ? 1 : loadingDots + 1;
                loading.Text = "Loading" + new string('.', loadingDots);
            };
        }

        private void StartLoading()
        {
            loadingDots = 1;
            loading.Text = "Loading.";
            loading.Visible = true;
            labelprogress.Visible = true;
            panelProgressBack.Visible = true;
            loadingTimer.Start();
        }

        private void StopLoading()
        {
            loadingTimer.Stop();
            loading.Visible = false;
            labelprogress.Visible = false;
            panelProgressBack.Visible = false;
        }

        private void SetProgress(int percent)
        {
            // Ensure percent is 0-100
            percent = Math.Max(0, Math.Min(100, percent));

            panelProgressFill.Width = panelProgressBack.Width * percent / 100;

            // Update text
            labelprogress.Text = percent + "%";
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
            SetProgress(0);

            var progress = new Progress<int>(value =>
            {
                SetProgress(value);

            });

            try
            {
                var result = await Task.Run(() => ScanErrors(scanCts.Token, progress), scanCts.Token);

                txtcpu.Text = !string.IsNullOrEmpty(result.cpu) ? result.cpu : "No CPU errors detected.";
                txtram.Text = !string.IsNullOrEmpty(result.ram) ? result.ram : "No RAM errors detected.";
                txtdisk.Text = !string.IsNullOrEmpty(result.disk) ? result.disk : "No Disk errors detected.";
                txtgpu.Text = !string.IsNullOrEmpty(result.gpu) ? result.gpu : "No GPU errors detected.";
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
                SetProgress(100);
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
        private (string cpu, string ram, string disk, string gpu) ScanErrors(CancellationToken token, IProgress<int> progress)
        {
            StringBuilder cpu = new StringBuilder();
            StringBuilder ram = new StringBuilder();
            StringBuilder disk = new StringBuilder();
            StringBuilder gpu = new StringBuilder();

            try
            {
                EventLog log = new EventLog("System");
                int total = log.Entries.Count;
                int processed = 0;

                foreach (EventLogEntry e in log.Entries)
                {
                    token.ThrowIfCancellationRequested();

                    string src = e.Source.ToLower();
                    string msg = e.Message.ToLower();

                    if (e.EntryType == EventLogEntryType.Error || e.EntryType == EventLogEntryType.Warning)
                    {
                        if (e.Source == "BugCheck")
                            cpu.AppendLine(FormatBugCheck(e));
                        else if (src.Contains("whea"))
                            cpu.AppendLine(Format(e));
                        else if (src.Contains("memory") || msg.Contains("page fault"))
                            ram.AppendLine(Format(e));
                        else if (src.Contains("disk") || src.Contains("stor") || msg.Contains("bad block"))
                        {
                            string diskLog = FormatDisk(e);
                            if (!string.IsNullOrEmpty(diskLog))
                                disk.AppendLine(diskLog);
                        }
                        else if (src.Contains("nvlddmkm") || src.Contains("amdkmdag") || msg.Contains("tdr"))
                            gpu.AppendLine(FormatGpu(e));
                    }

                    processed++;
                    // Update progress in percent
                    progress?.Report((int)((processed / (float)total) * 100));
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Some system logs require administrator privileges to read.", "Access Denied",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Get all GPUs
            List<string> gpuNames = new List<string>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController");
                foreach (ManagementObject gpu in searcher.Get())
                {
                    gpuNames.Add(gpu["Name"].ToString());
                }
            }
            catch { }

            string matchedGpu = "Unknown GPU";

            foreach (string name in gpuNames)
            {
                if (e.Source.ToLower().Contains(name.ToLower()) || e.Message.ToLower().Contains(name.ToLower()))
                {
                    matchedGpu = name;
                    break;
                }
            }

            sb.AppendLine("[" + e.TimeGenerated + "]");
            sb.AppendLine("GPU Device : " + matchedGpu);
            sb.AppendLine("Source     : " + e.Source);
            sb.AppendLine("Event      : " + e.InstanceId);
            sb.AppendLine(e.Message);
            sb.AppendLine(new string('-', 60));
            return sb.ToString();
        }

        // ===========================
        // DISK
        // ===========================
        private string FormatDisk(EventLogEntry e)
        {
            string diskInfo = GetDiskInfo(e.Message);

            // Ignore log if diskInfo is null → brand unknown / disk likely not attached
            if (diskInfo == null)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[" + e.TimeGenerated + "]");
            sb.AppendLine("Source : " + e.Source);
            sb.AppendLine("Event  : " + e.InstanceId);
            sb.AppendLine(diskInfo);
            sb.AppendLine(e.Message);
            sb.AppendLine(new string('-', 60));
            return sb.ToString();
        }

        private string GetDiskInfo(string msg)
        {
            Match m = Regex.Match(msg, @"harddisk(\d+)", RegexOptions.IgnoreCase);
            if (!m.Success)
                return null; // do not process if index not found

            int index = int.Parse(m.Groups[1].Value);

            try
            {
                // Get physical disk from WMI
                ManagementObjectSearcher diskSearcher =
                    new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Index=" + index);

                foreach (ManagementObject disk in diskSearcher.Get())
                {
                    string status = disk["Status"]?.ToString() ?? "UNKNOWN";
                    string model = disk["Model"]?.ToString() ?? "Unknown Model";

                    // Ignore disks with Unknown or Pred Fail status
                    if (status.Equals("Unknown", StringComparison.OrdinalIgnoreCase) ||
                        status.Equals("Pred Fail", StringComparison.OrdinalIgnoreCase))
                        return null; // disk will not be displayed

                    // Get drive letters if any
                    string driveLetters = GetDriveLetters(disk);

                    return $"Disk Index : {index}\r\nModel      : {model}\r\nStatus     : {status}\r\nDrive      : {driveLetters}";
                }
            }
            catch
            {
                // If WMI fails → assume disk not attached
                return null;
            }

            // If disk not found in WMI → likely not attached
            return null;
        }

        // Helper to get drive letters from physical disk
        private string GetDriveLetters(ManagementObject disk)
        {
            List<string> letters = new List<string>();

            try
            {
                // Connect DiskDrive → Partition → LogicalDisk
                ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher(
                    $"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{disk["DeviceID"]}'}} WHERE AssocClass = Win32_DiskDriveToDiskPartition");

                foreach (ManagementObject partition in partitionSearcher.Get())
                {
                    ManagementObjectSearcher logicalSearcher = new ManagementObjectSearcher(
                        $"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{partition["DeviceID"]}'}} WHERE AssocClass = Win32_LogicalDiskToPartition");

                    foreach (ManagementObject logical in logicalSearcher.Get())
                    {
                        letters.Add(logical["DeviceID"].ToString()); // e.g.: C:, D:
                    }
                }
            }
            catch { }

            return letters.Count > 0 ? string.Join(", ", letters) : "Unknown";
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

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/unamed666/WindowsErrorChecker";

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Open in default browser
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open link: " + ex.Message);
            }
        }


    }
}
