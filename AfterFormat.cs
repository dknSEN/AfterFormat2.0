using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace AfterFormat_2._0
{
    public partial class AfterFormat : Form
    {
        public AfterFormat()
        { InitializeComponent(); }

        //Main
        private void Form1_Load(object sender, EventArgs e)
        {
            AfterFormatTab.ItemSize = new System.Drawing.Size(120, 36);
            foreach (ManagementObject obj in SystemInfo.myCPU.Get())
            { lblCPU.Text = ("CPU Name: " + obj["Name"]); }
            foreach (ManagementObject obj in SystemInfo.myGPU.Get())
            { lblGPU.Text = ("GPU Name:  " + obj["Name"]); }
            foreach (ManagementObject obj in SystemInfo.myGPU.Get())
            { lblHz.Text = ("Refresh Rate:  " + obj["CurrentRefreshRate"] + "Hz"); }

            foreach (ManagementObject obj in SystemInfo.myOperatingSystem.Get())
            { lblOS.Text = ("Operating System:  " + obj["Caption"]); }
            foreach (ManagementObject obj in SystemInfo.myOperatingSystem.Get())
            { lblARC.Text = ("Architecture:  " + obj["OSArchitecture"]); }
            foreach (ManagementObject obj in SystemInfo.myOperatingSystem.Get())
            { lblOSVer.Text = ("Version:  " + obj["Version"]); }
            foreach (ManagementObject obj in SystemInfo.myOperatingSystem.Get())
            { lblOSN.Text = ("Serial Number:  " + obj["SerialNumber"]); }
            foreach (ManagementObject obj in SystemInfo.myOperatingSystem.Get())
            { lblMail.Text = ("Registered User:  " + obj["RegisteredUser"]); }
            foreach (ManagementObject obj in SystemInfo.myOperatingSystem.Get())
            { lblName.Text = ("Computer Name:  " + obj["CSName"]); }

            foreach (ManagementObject obj in SystemInfo.mySystem.Get())
            { lblBios.Text = ("BIOS Number:  " + obj["Name"]); }
            foreach (ManagementObject obj in SystemInfo.mySystem.Get())
            { lblMan.Text = ("System Manufacturer:  " + obj["Manufacturer"]); }


            foreach (ManagementObject obj in SystemInfo.myBaseBoard.Get())
            { lblMBM.Text = ("Mainboard Manufacturer:  " + obj["Manufacturer"]); }
            foreach (ManagementObject obj in SystemInfo.myBaseBoard.Get())
            { lblMSN.Text = ("Mainboard SN:  " + obj["SerialNumber"]); }

            long memKb;
            SystemInfo.GetPhysicallyInstalledSystemMemory(out memKb);
            lblRAM.Text = ("Total Memory: " + (memKb / 1024 / 1024) + " GB");


            //wallpapers
            pctBoxWall1.LoadAsync("https://w.wallhaven.cc/full/j3/wallhaven-j3y3jm.png");
            pctBoxWall2.LoadAsync("https://w.wallhaven.cc/full/9m/wallhaven-9mxpx1.png");
            pctBoxWall3.LoadAsync("https://w.wallhaven.cc/full/ym/wallhaven-ym1o3l.png");
            pctBoxWall6.LoadAsync("https://w.wallhaven.cc/full/kw/wallhaven-kwy5yd.png");
            pctBoxWall5.LoadAsync("https://w.wallhaven.cc/full/lm/wallhaven-lmleyq.png");
            pctBoxWall4.LoadAsync("https://w.wallhaven.cc/full/z8/wallhaven-z8g68w.png");

        }

        //Improves System and Gaming Performance
        private void PerformanceApply_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)    
            { 
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Control Panel\Desktop' /v HungAppTimeout /t REG_SZ /d 1000 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Control Panel\Desktop' /v MenuShowDelay /t REG_SZ /d 8 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Control Panel\Desktop' /v WaitToKillAppTimeout /t REG_SZ /d 2000 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Control Panel\Desktop' /v LowLevelHooksTimeout /t REG_SZ /d 1000 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Control Panel\Desktop' /v MouseHoverTime /t REG_SZ /d 8 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Control Panel\Desktop' /v AutoEndTasks /t REG_SZ /d 1 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control' /v WaitToKillServiceTimeout /t REG_SZ /d 2000 /f");
            }
            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked) 
            {
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications' /v GlobalUserDisabled /t REG_DWORD /d 1 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy' /f /v LetAppsRunInBackground /t REG_DWORD /d 2 ");
            }
            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control\CrashControl' /v AutoReboot /t REG_DWORD /d 0 /f");
            }
            if (checkedListBox1.GetItemCheckState(3) == CheckState.Checked) 
            {
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management' /f /v ClearPageFileAtShutdown /t REG_DWORD /d 1");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control\CrashControl' /v AutoReboot /t REG_DWORD /d 0 /f");
            }
            if (checkedListBox1.GetItemCheckState(4) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer' /f /v NoLowDiskSpaceChecks /t REG_DWORD /d 1");
            }
            if (checkedListBox1.GetItemCheckState(5) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand(@"reg add 'HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer' /f /v NoResolveSearch /t REG_DWORD /d 1");
            }
            if (checkedListBox1.GetItemCheckState(6) == CheckState.Checked)
            {  
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control\FileSystem' /f /v LongPathsEnabled /t REG_DWORD /d 0");
            }
            if (checkedListBox1.GetItemCheckState(7) == CheckState.Checked) 
            {
                Settings.ExecuteShellCommand(@"reg add 'HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\AppHost' /f /v EnableWebContentEvaluation /t REG_DWORD /d 0");
            }
            if (checkedListBox1.GetItemCheckState(8) == CheckState.Checked) 
            {
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management' /v FeatureSettingsOverride /t REG_DWORD /d 3 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management' /v FeatureSettingsOverrideMask /t REG_DWORD /d 3 /f");
            }
            if (checkedListBox1.GetItemCheckState(9) == CheckState.Checked) 
            {
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SYSTEM\CurrentControlSet\services\DiagTrack' /f /v Start /t REG_DWORD /d 4 ");
            }
            if (checkedListBox1.GetItemCheckState(10) == CheckState.Checked) 
            { 
                Settings.ExecuteShellCommand("fsutil behavior set DisableDeleteNotify 0"); 
            }

            if (checkedListBox1.GetItemCheckState(11) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile' /v SystemResponsiveness /t REG_DWORD /d ffffffff /f");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile' /v NetworkThrottlingIndex /t REG_DWORD /d 00000000 /f");
            }
            if (checkedListBox1.GetItemCheckState(12) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games' /v 'GPU Priority' /t REG_DWORD /d 8 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games' /v Priority /t REG_DWORD /d 6 /f");
                Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games' /v 'Scheduling Category' /t REG_SZ /d High /f");
                Settings.ExecuteShellCommand(@"reg add 'HKCU\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games' /v 'SFIO Priority' /t REG_SZ /d High /f");
            }
        }

        //Unnecessary Services
        private void ServiceApply_Click(object sender, EventArgs e)
        {
            if (checkedListBox2.GetItemCheckState(0) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Control\Session Manager\Power", "HiberbootEnabled", "0"); }
            if (checkedListBox2.GetItemCheckState(1) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Control\Power", "HibernateEnabled", "0"); }
            if (checkedListBox2.GetItemCheckState(2) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnablePrefetcher", "0");
                Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters", "EnableSuperFetch", "0");
            }
            if (checkedListBox2.GetItemCheckState(3) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"Software\Policies\Microsoft\Windows\Psched", "NonBestEffortLimit", "0"); }
            if (checkedListBox2.GetItemCheckState(4) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"Software\Microsoft\Windows\CurrentVersion\Policies\Associations", "ModRiskFileTypes", ".bat;.exe;.reg;.vbs;.chm;.msi;.js;.cmd"); }
            if (checkedListBox2.GetItemCheckState(5) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Services\LanmanServer\Parameters", "SMB1", "0");
                Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Services\LanmanServer\Parameters", "SMB2", "0");
            }
            if (checkedListBox2.GetItemCheckState(6) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"System\CurrentControlSet\Control\WMI\Autologger\SQMLogger", "Start", "0"); }
            if (checkedListBox2.GetItemCheckState(7) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"Software\Policies\Microsoft\Windows NT\SystemRestore", "DisableSR", "1"); }
            if (checkedListBox2.GetItemCheckState(8) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"Software\Policies\Microsoft\Windows\EnhancedStorageDevices", "TCGSecurityActivationDisabled", "0"); }
            if (checkedListBox2.GetItemCheckState(9) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"Software\Policies\Microsoft\Windows\Windows Error Reporting", "DontSendAdditionalData", "1"); }
            if (checkedListBox2.GetItemCheckState(10) == CheckState.Checked)
            { Settings.SetLocalMachineRegistry(@"Software\Policies\Microsoft\Windows\Gwx", "DisableGwx", "1");
                Settings.SetLocalMachineRegistry(@"Software\Policies\Microsoft\Windows\WindowsUpdate", "DisableOSUpgrade", "1");
            }
        }

        private void button3_Click(object sender, EventArgs e) //telemetry button
        {
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Policies\Microsoft\Windows Defender\Real-Time Protection' /v DisableRealtimeMonitoring /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\System\CurrentControlSet\Services\SecurityHealthService' /v Start /t REG_DWORD /d 4 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\System\CurrentControlSet\Services\WinDefend' /v Start /t REG_DWORD /d 4 /f");
            Settings.ExecuteShellCommand(@"reg add 'Software\Policies\Microsoft\MRT' /v DontOfferThroughWUAU /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\System' /v PromptOnSecureDesktop /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\System' /v ConsentPromptBehaviorAdmin /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Policies\Microsoft\Windows\AdvertisingInfo' /v DisabledByGroupPolicy /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\SQMClient\Window' /v CEIPEnable /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Policies\Microsoft\SQMClient\Windows' /v CEIPEnable /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\DataCollection' /v AllowTelemetry /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo' /v Enabled /t REG_DWORD /d 0 /f");
        }

        private void button7_Click(object sender, EventArgs e) //hpet button
        {
            Settings.ExecuteShellCommand("Compact.exe /CompactOS:always");
        }

        private void button5_Click(object sender, EventArgs e) //uac button
        { Settings.SetLocalMachineRegistry(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", "0"); }

        private void button6_Click(object sender, EventArgs e) //dvr button
        {
            Settings.ExecuteShellCommand(@"reg add 'HKCU\Software\Microsoft\Windows\CurrentVersion\GameDVR' /v AppCaptureEnabled /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\System\GameConfigStore' /v GameDVR_Enabled /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\System\GameConfigStore' /v GameDVR_FSEBehaviorMode /t REG_DWORD /d 2 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\System\GameConfigStore' /v GameDVR_HonorUserFSEBehaviorMode /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\System\GameConfigStore' /v GameDVR_DXGIHonorFSEWindowsCompatible /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\System\GameConfigStore' /v GameDVR_EFSEFeatureFlags /t REG_DWORD /d 0 /f");
        }

        private void button8_Click(object sender, EventArgs e) //update button
        {
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Policies\Microsoft\Windows\WindowsUpdate' /v NoAutoUpdate /t REG_DWORD /d 1 /f");
        }

        private void button4_Click(object sender, EventArgs e) //defender button
        {
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer' /v HideSCAHealth /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKCU\Software\Microsoft\Windows Security Health\State' /v AccountProtection_MicrosoftAccount_Disconnected /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows Defender Security Center\Notifications' /v DisableNotifications /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows Defender Security Center\Notifications' /v DisableEnhancedNotifications /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\AppHost' /v EnableWebContentEvaluation /t REG_DWORD /d 0 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Policies\Microsoft\Windows Defender' /v DisableAntiSpyware /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer' /v HideSCAHealth /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments' /v ScanWithAntiVirus /t REG_DWORD /d 3 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\Attachments' /v SaveZoneInformation /t REG_DWORD /d 1 /f");
            Settings.ExecuteShellCommand(@"reg add 'HKLM\Policies\Microsoft\Windows Defender\Real-Time Protection' /v DisableRealtimeMonitoring /t REG_DWORD /d 1 /f");
        }
        private void button1_Click(object sender, EventArgs e) //ultimate performance 
        {
            Settings.ExecuteShellCommand("powercfg -duplicatescheme e9a42b02-d5df-448d-aa00 -03f14749eb61");
        }

        //Apps Download

        public void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        public void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download complete.","AfterFormat 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pctBoxDism_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://gh.api.99988866.xyz/github.com/Chuyu-Team/Dism-Multi-language/releases/download/v10.1.1002.1/Dism++10.1.1002.1.zip"), $"{Directory.GetCurrentDirectory()}" + "/" + "Dism.zip");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxPure_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://files1.majorgeeks.com/10afebdbffcd4742c81a3cb0f6ce4092156b4375/drives/PureRa.zip"), $"{Directory.GetCurrentDirectory()}" + "/" + "PureRa.zip");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxRam_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://download1594.mediafire.com/qi83662rsvhg/yz6b8pnbariuhgv/SmartRAM.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "SmartRAM.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxChr_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26iid%3D%7BEA833CDD-442D-D389-8831-EE6462FB5804%7D%26lang%3Dtr%26browser%3D4%26usagestats%3D0%26appname%3DGoogle%2520Chrome%26needsadmin%3Dprefers%26ap%3Dx64-stable-statsdef_1%26installdataindex%3Dempty/update2/installers/ChromeSetup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "ChromeSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxOpe_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google_via_opera_com&utm_medium=ose&utm_campaign=(none)_via_opera_com_https&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/download&dl_token=49808780"), $"{Directory.GetCurrentDirectory()}" + "/" + "OperaSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxFir_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://download-installer.cdn.mozilla.net/pub/firefox/releases/94.0.1/win32/tr/Firefox%20Installer.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "FirefoxSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxBra_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://referrals.brave.com/latest/BraveBrowserSetup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "BraveSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxWin_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://www.win-rar.com/fileadmin/winrar-versions/winrar/winrar-x64-61b1.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "WinRARSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxVCR_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://de1-dl.techpowerup.com/files/4zGFkSIGPCaBVQeiLQzyCw/1636754476/Visual-C-Runtimes-All-in-One-Nov-2021.zip"), $"{Directory.GetCurrentDirectory()}" + "/" + "VCRedist.zip");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxDRX_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "DirectXSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxTor_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://download.fosshub.com/Protected/expiretime=1636940132;badurl=aHR0cHM6Ly93d3cuZm9zc2h1Yi5jb20vcUJpdHRvcnJlbnQuaHRtbA==/61f853952fb9e735cbe24bf686b452a55592add7fad847ba437087b0e6881475/5b8793a7f9ee5a5c3e97a3b2/617ea9d83af10152701eec7b/qbittorrent_4.3.9_x64_setup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "qBittorrent.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxSte_Click(object sender, EventArgs e) //
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "SteamSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxEpi_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://epicgames-download1.akamaized.net/Builds/UnrealEngineLauncher/Installers/Win32/EpicInstaller-13.0.0.msi?launcherfilename=EpicInstaller-13.0.0.msi"), $"{Directory.GetCurrentDirectory()}" + "/" + "EpicGamesSetup.msi");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxUbi_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://ubistatic3-a.akamaihd.net/orbit/launcher_installer/UbisoftConnectInstaller.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "UbisoftConnectSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxEAD_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "EaDesktopSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxDis_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://dl.discordapp.net/distro/app/stable/win/x86/1.0.9003/DiscordSetup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "DiscordSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxSpo_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://download.scdn.co/SpotifySetup.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "SpotifySetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxTel_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://updates.tdesktop.com/tx64/tsetup-x64.3.2.2.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "TelegramSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxVlc_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://mirror.library.ucy.ac.cy/videolan/vlc/3.0.16/win64/vlc-3.0.16-win64.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "VLCSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxMal_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://data-cdn.mbamupdates.com/web/affiliate_builds/win_temp/MBSetup-119967.119967-consumer.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "MalwareBytesSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxNvi_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://tr.download.nvidia.com/GFE/GFEClient/3.23.0.74/GeForce_Experience_v3.23.0.74.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "GeforceSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxAmd_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("https://drivers.amd.com/drivers/installer/21.30/beta/radeon-software-adrenalin-2020-21.11.2-minimalsetup-211110_web.exe"), $"{Directory.GetCurrentDirectory()}" + "/" + "RadeonSetup.exe");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        //Windows Apps Delete

        private void pctBoxAla_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowsalarms* | Remove-AppxPackage"); }

        private void pctBoxCal_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowscalculator* | Remove-AppxPackage"); }

        private void pctBoxCale_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage"); }

        private void pctBoxCam_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *camera* | Remove-AppxPackage"); }

        private void pctBoxFee_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowsfeedbackhub* | Remove-AppxPackage"); }

        private void pctBoxHelp_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *Microsoft.GetHelp* | Remove-AppxPackage"); }

        private void pctBoxStore_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowsstore* | Remove-AppxPackage"); }

        private void pctBoxTod_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *Microsoft.Todos* | Remove-AppxPackage"); }

        private void pctBoxMob_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *oneconnect* | Remove-AppxPackage"); }

        private void pctBoxVid_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *zunevideo* | Remove-AppxPackage"); }

        private void pctBoxWea_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *bingweather* | Remove-AppxPackage"); }

        private void pctBoxPhoto_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *photos* | Remove-AppxPackage"); }

        private void pctBoxMusic_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *zunemusic* | Remove-AppxPackage"); }

        private void pctBoxMail_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage"); }

        private void pctBoxMaps_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *windowsmaps* | Remove-AppxPackage"); }

        private void pctBoxSol_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *Microsoft.MicrosoftSolitaireCollection* | Remove-AppxPackage"); }

        private void pctBoxOff_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *microsoftofficehub* | Remove-AppxPackage"); }

        private void pctBoxOneDrive_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *microsoft.microsoftskydrive* | Remove-AppxPackage"); }

        private void pctBoxSkype_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *skypeapp* | Remove-AppxPackage"); }

        private void pctBoxTeam_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *MicrosoftTeams* | Remove-AppxPackage"); }

        private void pctBoxTips_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *getstarted* | Remove-AppxPackage"); }

        private void pctBoxPhone_Click(object sender, EventArgs e)
        { Settings.ExecuteShellCommand("Get-AppxPackage *yourphone* | Remove-AppxPackage"); }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Settings.ExecuteShellCommand("Get-AppxPackage *yourphone* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *getstarted* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *MicrosoftTeams* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *skypeapp* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *microsoft.microsoftskydrive* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *microsoftofficehub* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *Microsoft.MicrosoftSolitaireCollection* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowsmaps* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *zunemusic* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *oneconnect* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *Microsoft.Todos* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowsstore* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *Microsoft.GetHelp* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowsfeedbackhub* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *camera* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowscalculator* | Remove-AppxPackage");
            Settings.ExecuteShellCommand("Get-AppxPackage *windowsalarms* | Remove-AppxPackage");
        }

        //Wallpapers
        private void pctBoxWall1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://w.wallhaven.cc/full/j3/wallhaven-j3y3jm.png"), $"{Directory.GetCurrentDirectory()}" + "/" + "Wall1.png");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxWall2_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://w.wallhaven.cc/full/9m/wallhaven-9mxpx1.png"), $"{Directory.GetCurrentDirectory()}" + "/" + "Wall2.png");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxWall3_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://w.wallhaven.cc/full/ym/wallhaven-ym1o3l.png"), $"{Directory.GetCurrentDirectory()}" + "/" + "Wall3.png");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxWall4_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://w.wallhaven.cc/full/z8/wallhaven-z8g68w.png"), $"{Directory.GetCurrentDirectory()}" + "/" + "Wall4.png");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxWall5_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://w.wallhaven.cc/full/lm/wallhaven-lmleyq.png"), $"{Directory.GetCurrentDirectory()}" + "/" + "Wall5.png");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        private void pctBoxWall6_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://w.wallhaven.cc/full/kw/wallhaven-kwy5yd.png"), $"{Directory.GetCurrentDirectory()}" + "/" + "Wall6.png");
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        }

        //Junk Files Clean
        private void JunkApply_Click(object sender, EventArgs e)
        {
            if (checkedListBox3.GetItemCheckState(0) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand(@"Del /F /Q %APPDATA%\Microsoft\Windows\Recent\*");
                Settings.ExecuteShellCommand(@"Del /F /Q %APPDATA%\Microsoft\Windows\Recent\AutomaticDestinations\*");
                Settings.ExecuteShellCommand(@"Del /F /Q %APPDATA%\Microsoft\Windows\Recent\CustomDestinations\*");
            }
            if (checkedListBox3.GetItemCheckState(1) == CheckState.Checked)
            {
                var tmpPath = Path.GetTempPath();
                var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    try
                    {
                        if (File.Exists(file))
                        { File.Delete(file); }
                    }
                    catch { }
                }
                String tempFolder = Environment.ExpandEnvironmentVariables("%TEMP%");
                foreach (var file in Directory.GetFiles(tempFolder))
                {
                    try
                    {
                        if (File.Exists(file))
                        { File.Delete(file); }
                    }
                    catch { }
                }
                String prefetch = Environment.ExpandEnvironmentVariables("%SYSTEMROOT%") + "\\Prefetch";
                foreach (var file in Directory.GetFiles(prefetch))
                {
                    try
                    {
                        if (File.Exists(file))
                        { File.Delete(file); }
                    }
                    catch { }
                }
            }
            if (checkedListBox3.GetItemCheckState(2) == CheckState.Checked)
            {
                Settings.ExecuteShellCommand("ipconfig /flushdns");
            }
        }

        //buttons

        private void pctBoxInfo_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }
    }
}
