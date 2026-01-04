<h1 align="center">
Windows Error Checker
</h2><br>

Windows Error Checker is a lightweight Windows Forms utility for scanning **Windows Event Logs** to detect and categorize system errors related to **CPU, RAM, Disk, and GPU**.
<br><br><br><br>
<h2 align="center">
  <a href="https://github.com/unamed666/WindowsErrorChecker/releases/latest">DOWNLOAD HERE</a>
</h2>

## Features
- Scans *System* event logs for **Error** and **Warning** entries
- Categorizes issues by hardware component:
  - CPU (BugCheck, WHEA)
  - RAM (memory faults, page faults)
  - Disk (bad blocks, storage errors)
  - GPU (TDR, driver crashes)

## Requirements
- Windows OS

## Usage
1. Run the application
2. Click **Scan**
3. Review detected issues per hardware category
4. Cancel or exit safely while scanning if needed

## Notes
This tool reads existing system logs only.  
It does **not** modify system settings or perform repairs.
