using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000008 RID: 8
	public class Basics : IFeature
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00017220 File Offset: 0x00015420
		public void Execute()
		{
			Utils.Status("Tweaking Basics...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258238388436336660/NSudoLC.exe?ex=66875150&is=6685ffd0&hm=5bcd0730110a96d5836e1e4e2db9675915131d69202e894a0286cffd2075f605&");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\DevManView.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258239357991653518/DevManView.exe?ex=66875237&is=668600b7&hm=d7fffc500656032949cf3d303c079d7ff2f5723e1648e3d526463b55f252bd7c&");
			if (MainForm.SpyCheck())
			{
				Utils.FB();
			}
			else
			{
				if (Environment.OSVersion.Version.Major == 6)
				{
					bool flag = Environment.OSVersion.Version.Minor == 1;
				}
				if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
				{
					Utils.NeedDownload(Utils.WinDrive + "Windows\\System32\\StartLayoutFile.xml", "https://cdn.discordapp.com/attachments/1258236120354000896/1258236456309227530/StartLayoutFile.xml?ex=66874f84&is=6685fe04&hm=4f103e9e146358d42288a317984350e04d2cf5e55310bfd33d33243f4b6b5d81&");
					Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("StartLayoutFile", Utils.WinDrive + "Windows\\System32\\StartLayoutFile.xml", RegistryValueKind.ExpandString);
					Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("LockedStartLayout", "1", RegistryValueKind.DWord);
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("MitigationOptions", new byte[24], RegistryValueKind.Binary);
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("MitigationAuditOptions", new byte[16], RegistryValueKind.Binary);
				}
				if (Environment.OSVersion.Version.Major == 10)
				{
					Utils.NeedDownload(Utils.WinDrive + "Windows\\System32\\StartLayoutFile.xml", "https://cdn.discordapp.com/attachments/1258236120354000896/1258236456309227530/StartLayoutFile.xml?ex=66874f84&is=6685fe04&hm=4f103e9e146358d42288a317984350e04d2cf5e55310bfd33d33243f4b6b5d81&");
					Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("StartLayoutFile", Utils.WinDrive + "Windows\\System32\\StartLayoutFile.xml", RegistryValueKind.ExpandString);
					Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true).SetValue("LockedStartLayout", "1", RegistryValueKind.DWord);
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("MitigationAuditOptions", new byte[]
					{
						0,
						0,
						0,
						0,
						0,
						0,
						32,
						34,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						32,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0
					}, RegistryValueKind.Binary);
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("MitigationOptions", new byte[]
					{
						0,
						34,
						34,
						32,
						34,
						32,
						34,
						34,
						32,
						0,
						0,
						0,
						0,
						32,
						0,
						32,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0
					}, RegistryValueKind.Binary);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Print3D | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.3DBuilder | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.AppConnector | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.BingFinance | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.BingNews | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.BingSports | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.BingTranslator | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.BingWeather | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.GetHelp | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Getstarted | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Messaging | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Microsoft3DViewer | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.MicrosoftSolitaireCollection | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.NetworkSpeedTest | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.News | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Office.Lens | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Office.Sway | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.OneConnect | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.People | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Windows.PeopleExperienceHost | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.SkypeApp | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.StorePurchaseApp | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Wallet | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Whiteboard | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.WindowsAlarms | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage microsoft.windowscommunicationsapps | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.WindowsFeedbackHub | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.WindowsMaps | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.WindowsSoundRecorder | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.ZuneMusic | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.ZuneVideo | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.Advertising.Xaml_10.1712.5.0_x64__8wekyb3d8bbwe | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.BingWeather | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.MicrosoftStickyNotes | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.MixedReality.Portal | Remove-AppxPackage", false, false);
					Utils.ExecuteProcess("powershell.exe", "Get-AppxPackage Microsoft.SkypeApp_14.53.77.0_x64__kzf8qxf38zg5c | Remove-AppxPackage", false, false);
				}
				if (File.Exists(Utils.WinDrive + "Windows\\System32\\mcupdate_AuthenticAMD.dll"))
				{
					Utils.ExecuteProcess("cmd.exe", "/C takeown /F %WINDIR%\\System32\\mcupdate_AuthenticAMD.dll /A & icacls %WINDIR%\\System32\\mcupdate_AuthenticAMD.dll /grant Administrators:(F)", true, false);
					Utils.ExecuteProcess("cmd.exe", "/C REN %WINDIR%\\System32\\mcupdate_AuthenticAMD.dll mcupdate_AuthenticAMD.old", true, false);
				}
				if (File.Exists(Utils.WinDrive + "Windows\\System32\\mcupdate_GenuineIntel.dll"))
				{
					Utils.ExecuteProcess("cmd.exe", "/C takeown /F %WINDIR%\\System32\\mcupdate_GenuineIntel.dll /A & icacls %WINDIR%\\System32\\mcupdate_GenuineIntel.dll /grant Administrators:(F)", true, false);
					Utils.ExecuteProcess("cmd.exe", "/C REN %WINDIR%\\System32\\mcupdate_GenuineIntel.dll mcupdate_GenuineIntel.old", true, false);
				}
				if (File.Exists(Utils.WinDrive + "Windows\\System32\\mobsync.exe"))
				{
					Utils.ExecuteProcess("cmd.exe", "/C takeown /F %WINDIR%\\System32\\mobsync.exe /A & icacls %WINDIR%\\System32\\mobsync.exe /grant Administrators:(F)", true, false);
					Utils.ExecuteProcess("cmd.exe", "/C REN %WINDIR%\\System32\\mobsync.exe mobsync.old", true, false);
					Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableSettingSyncUserOverride", "1", RegistryValueKind.DWord);
					Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\SettingSync", true).SetValue("DisableSettingSync", "2", RegistryValueKind.DWord);
				}
				if (Utils.SystemInformation.SvchostValue.ToString() == "8")
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control", true).SetValue("SvcHostSplitThresholdInKB", "137922056", RegistryValueKind.DWord);
				}
				if (Utils.SystemInformation.SvchostValue.ToString() == "16")
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control", true).SetValue("SvcHostSplitThresholdInKB", "376926742", RegistryValueKind.DWord);
				}
				if (Utils.SystemInformation.SvchostValue.ToString() == "32")
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control", true).SetValue("SvcHostSplitThresholdInKB", "861226034", RegistryValueKind.DWord);
				}
				if (Utils.SystemInformation.SystemType.ToString() == "1")
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\PowerThrottling", true).SetValue("PowerThrottlingOff", "1", RegistryValueKind.DWord);
				}
				Utils.ExecuteProcess("dism.exe", "/online /enable-feature /featurename:DesktopExperience /all /norestart", false, false);
				Utils.ExecuteProcess("dism.exe", "/online /enable-feature /featurename:LegacyComponents /all /norestart", false, false);
				Utils.ExecuteProcess("dism.exe", "/online /enable-feature /featurename:DirectPlay /all /norestart", false, false);
				Utils.ExecuteProcess("dism.exe", "/online /enable-feature /featurename:NetFx4-AdvSrvs /all /norestart", false, false);
				Utils.ExecuteProcess("dism.exe", "/online /enable-feature /featurename:NetFx3 /all /norestart", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Teredo Tunneling\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Kernel Debug Network Adapter\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"UMBus Root Bus Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Composite Bus Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Virtual Drive Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"NDIS Virtual Network Adapter Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"System Timer\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"System speaker\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Programmable Interrupt Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"PCI standard RAM Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"PCI Memory Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Storage Spaces Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Windows Management Interface for ACPI\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Wi-Fi Direct Virtual Adapter\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft GS Wavetable Synth\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Remote Desktop Device Redirector Bus\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"SM Bus Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"AMD PSP\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Intel SMBus\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Intel Management Engine\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Numeric Data Processor\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"AURA LED Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"PCI Simple Communications Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Composite Bus Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft System Management BIOS Driver\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Virtual Drive Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"NDIS Virtual Network Adapter Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Remote Desktop Device Redirector Bus\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"UMBus Root Bus Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"NVIDIA Virtual Audio Device\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Intel SMBus\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft GS Wavetable Synth\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"System speaker\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Intel(R) Management Engine Interface\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"AMD PSP\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"System Speaker\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"System Timer\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (IKEv2)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (IP)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (IPv6)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (L2TP)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (Network Monitor)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (PPPOE)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (PPTP)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"WAN Miniport (SSTP)\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"UMBus Root Bus Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft System Management BIOS Driver\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Programmable Interrupt Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"High Precision Event Timer\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"PCI Encryption/Decryption Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Intel SMBus\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Intel Management Engine\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"PCI Memory Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"PCI standard RAM Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Composite Bus Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Kernel Debug Network Adapter\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"SM Bus Controller\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"NDIS Virtual Network Adapter Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft Virtual Drive Enumerator\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Numeric Data Processor\"", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DevManView.exe", "/disable \"Microsoft RRAS Root Enumerator\"", false, false);
				Utils.ExecuteProcess("fsutil.exe", "behavior set disableLastAccess 1", false, false);
				Utils.ExecuteProcess("fsutil.exe", "behavior set disable8dot3 1", false, false);
				Utils.ExecuteProcess("netsh.exe", "int tcp set heuristics disabled", false, false);
				Utils.ExecuteProcess("netsh.exe", "int tcp set global timestamps=disabled", false, false);
				Utils.ExecuteProcess("netsh.exe", "int tcp set global rsc=disabled", false, false);
				Utils.ExecuteProcess("wmic.exe", "nicconfig where TcpipNetbiosOptions=0 call SetTcpipNetbios 2", false, false);
				Utils.ExecuteProcess("wmic.exe", "nicconfig where TcpipNetbiosOptions=1 call SetTcpipNetbios 2", false, false);
				Utils.SysNativeCmd("bcdedit.exe /deletevalue useplatformclock");
				Utils.SysNativeCmd("bcdedit.exe /set useplatformtick yes");
				Utils.SysNativeCmd("bcdedit.exe /set disabledynamictick yes");
				Utils.SysNativeCmd("bcdedit.exe /set tscsyncpolicy Enhanced");
				Utils.SysNativeCmd("bcdedit.exe /set bootdebug No");
				Utils.SysNativeCmd("bcdedit.exe /set bootlog No");
				Utils.SysNativeCmd("bcdedit.exe /set bootux disabled");
				Utils.SysNativeCmd("bcdedit.exe /set debug No");
				Utils.SysNativeCmd("bcdedit.exe /set disableelamdrivers Yes");
				Utils.SysNativeCmd("bcdedit.exe /set hypervisorlaunchtype off");
				Utils.SysNativeCmd("bcdedit.exe /set integrityservices disable");
				Utils.SysNativeCmd("bcdedit.exe /set quietboot yes");
				Utils.SysNativeCmd("bcdedit.exe /set tpmbootentropy ForceDisable");
				Utils.SysNativeCmd("bcdedit.exe /timeout 3");
				Utils.SysNativeCmd("bcdedit.exe /set {globalsettings} custom:16000067 true");
				Utils.SysNativeCmd("bcdedit.exe /set {globalsettings} custom:16000069 true");
				Utils.SysNativeCmd("bcdedit.exe /set {globalsettings} custom:16000068 true");
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Application Experience\\Microsoft Compatibility Appraiser\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Application Experience\\ProgramDataUpdater\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Application Experience\\StartupAppTask\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Application Experience\\AitAgent\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Customer Experience Improvement Program\\Consolidator\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Customer Experience Improvement Program\\KernelCeipTask\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Customer Experience Improvement Program\\UsbCeip\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Customer Experience Improvement Program\\Uploader\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Power Efficiency Diagnostics\\AnalyzeSystem\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\AppID\\SmartScreenSpecific\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Autochk\\Proxy\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\CloudExperienceHost\\CreateObjectTask\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\DiskDiagnostic\\Microsoft-Windows-DiskDiagnosticDataCollector\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\DiskFootprint\\Diagnostics\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\FileHistory\\File History (maintenance mode)\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Maintenance\\WinSAT\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\PI\\Sqm-Tasks\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\NetTrace\\GatherNetworkInfo\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Time Synchronization\\ForceSynchronizeTime\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Time Synchronization\\SynchronizeTime\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\ErrorDetails\\EnableErrorDetailsUpdate\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\Windows Error Reporting\\QueueReporting\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"Microsoft\\Windows\\WindowsUpdate\\Automatic App Update\" /Disable", false, false);
				Utils.ExecuteProcess("schtasks.exe", "/Change /TN \"USER_ESRV_SVC_QUEENCREEK\" /Disable", false, false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\SystemRestore", true).SetValue("RPSessionInterval", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("AutoGameModeEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableVirtualization", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableInstallerDetection", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("PromptOnSecureDesktop", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableLUA", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableSecureUIAPaths", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("ConsentPromptBehaviorAdmin", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("ValidateAdminCodeSignatures", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("EnableUIADesktopToggle", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("ConsentPromptBehaviorUser", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("FilterAdministratorToken", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\PriorityControl", true).SetValue("Win32PrioritySeparation", "38", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("AlwaysOn", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("LazyModeTimeout", "150000", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("NetworkThrottlingIndex", "10", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("NoLazyMode", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", true).SetValue("SystemResponsiveness", "10", RegistryValueKind.DWord);
				Registry.LocalMachine.DeleteSubKeyTree("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers\\BlockList\\Kernel", false);
				Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Superfetch", true).SetValue("AdminDisable", "8704", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Superfetch", true).SetValue("AdminEnable", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Superfetch", true).SetValue("StartedComponents", "513347", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("CsEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("EnergyEstimationEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("PerfCalculateActualUtilization", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("SleepReliabilityDetailedDiagnostics", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("EventProcessorEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("QosManagesIdleProcessors", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("DisableVsyncLatencyUpdate", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("DisableSensorWatchdog", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("HibernateEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoplayHandlers", true).SetValue("DisableAutoplay", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance", true).SetValue("MaintenanceDisabled", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments", true).SetValue("SaveZoneInformation", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\MRT", true).SetValue("DontOfferThroughWUAU", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\CrashControl", true).SetValue("DisplayParameters", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings", true).SetValue("ShowSleepOption", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings", true).SetValue("ShowLockOption", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("VerboseStatus", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true).SetValue("DelayedDesktopSwitchTimeout", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize", true).SetValue("StartupDelayInMSec", "0", RegistryValueKind.DWord);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SOFTWARE\\Microsoft\\WindowsRuntime\\ActivatableClassId\\Windows.Gaming.GameBar.PresenceServer.Internal.PresenceWriter\" /f /v ActivationType /t REG_DWORD /d 0", false, false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Feeds", true).SetValue("ShellFeedsTaskbarViewMode", "2", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("AlwaysHibernateThumbnails", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("Animations", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("Blur", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("ColorizationGlassAttribute", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("ColorPrevalence", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("Composition", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("CompositionPolicy", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("EnableAeroPeek", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\DWM", true).SetValue("EnableWindowColorization", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm", true).SetValue("AnimationAttributionEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm", true).SetValue("AnimationAttributionHashingEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm", true).SetValue("EnableDesktopOverlays", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm\\ExtendedComposition", true).SetValue("ExclusiveModeFramerateAveragingPeriodMs", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Dwm\\ExtendedComposition", true).SetValue("ExclusiveModeFramerateThresholdPercent", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("AnimationAttributionEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("Composition", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("CompositionPolicy", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisableHologramCompositor", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisallowAnimations", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisallowComposition", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DisallowFlip3d", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", true).SetValue("DWMWA_TRANSITIONS_FORCEDISABLED", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\FTH", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\FTH\\State", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Multimedia\\Audio", true).SetValue("UserDuckingPreference", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\BootAnimation", true).SetValue("DisableStartupSound", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Kernel", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Executive", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power\\ModernSleep", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Power", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("HiberbootEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("HibernateEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power", true).SetValue("SleepStudyDisabled", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager", true).SetValue("ProtectionMode", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("DisablePagingCombining", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DisableExceptionChainValidation", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DpcQueueDepth", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DpcWatchdogPeriod", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("DpcWatchdogProfileOffset", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("EAFModules", "", RegistryValueKind.String);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("EAFWatchdogEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("ForceIdleGracePeriod", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("InterruptSteeringDisabled", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("KernelSEHOPEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("SerializeTimerExpiration", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", true).SetValue("InterruptSteeringFlags", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("CoalescingTimerInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("DisablePagingExecutive", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnableCfg", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnableLowVaAccess", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnablePrefetcher", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnableSuperfetch", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("FeatureSettings", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("FeatureSettingsOverride", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("FeatureSettingsOverrideMask", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnableBootTrace", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnablePrefetcher", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnableSuperfetch", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Wbem\\CIMOM", true).SetValue("EnableEvents", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows", true).SetValue("TimeStaCEIPEnablempInterval", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\SQMClient", true).SetValue("CorporateSQMURL", "0.0.0.0", RegistryValueKind.String);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).SetValue("CpuPriorityClass", "4", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\csrss.exe\\PerfOptions", true).SetValue("IoPriority", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers\\Scheduler", true).SetValue("EnablePreemption", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers\\Scheduler", true).SetValue("VsyncIdleTimeout", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", true).SetValue("HwSchedMode", "2", RegistryValueKind.DWord);
				Utils.SysNativeCmd("echo hrtf = true > \"%appdata%\\alsoft.ini\"");
				Utils.SysNativeCmd("echo hrtf = true > \"%ProgramData%\\alsoft.ini\"");
				Utils.SysNativeCmd("if not exist \"%WinDir%\\System32\\SDL.dll\" copy \"resources\\SDL.dll\" \"%WinDir%\\System32\"");
				Utils.SysNativeCmd("if not exist \"%WinDir%\\SysWOW64\\SDL.dll\" copy \"resources\\SDL.dll\" \"%WinDir%\\SysWOW64\"");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Speech", true).SetValue("AllowSpeechModelUpdate", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Peernet", true).SetValue("Disabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Siuf\\Rules", true).DeleteValue("PeriodInNanoSeconds", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Siuf\\Rules", true).SetValue("NumberOfSIUFInPeriod", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("DoNotShowFeedbackNotifications", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Privacy", true).SetValue("TailoredExperiencesWithDiagnosticDataEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CDP", true).SetValue("RomeSdkChannelUserAuthzPolicy", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("ContentDeliveryAllowed", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("OemPreInstalledAppsEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("PreInstalledAppsEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("PreInstalledAppsEverEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SilentInstalledAppsEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SystemPaneSuggestionsEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-310093Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-314559Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338387Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338388Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338389Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-338393Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-353694Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-353696Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", true).SetValue("SubscribedContent-353698Enabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableSoftLanding", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\CloudContent", true).SetValue("DisableWindowsConsumerFeatures", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement", true).SetValue("ScoobeSystemSettingEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata", false);
				Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\StorageSense", false);
				Utils.RegService("DoSvc", "4");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization", true).SetValue("DODownloadMode", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeliveryOptimization", true).SetValue("SystemSettingsDownloadMode", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config", true).SetValue("DODownloadMode", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization", true).SetValue("SystemSettingsDownloadMode", "0", RegistryValueKind.DWord);
				Utils.RegService("WerSvc", "4");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\PCHealth\\ErrorReporting", true).SetValue("DoReport", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\Windows Error Reporting", true).SetValue("Disabled", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost", true).SetValue("EnableWebContentEvaluation", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\default\\WiFi\\AllowAutoConnectToWiFiSenseHotspots", true).SetValue("value", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\default\\WiFi\\AllowWiFiHotSpotReporting", true).SetValue("value", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell", true).SetValue("UseActionCenterExperience", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection", true).SetValue("AllowTelemetry", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("HideSCAHealth", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AdvertisingInfo", true).SetValue("DisabledByGroupPolicy", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowTelemetry", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowClipboardHistory", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection", true).SetValue("AllowCrossDeviceClipboard", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\EnhancedStorageDevices", true).SetValue("TCGSecurityActivationDisabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\safer\\codeidentifiers", true).SetValue("authenticodeenabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection", true).SetValue("AllowTelemetry", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\WUDF", true).SetValue("LogEnable", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\WUDF", true).SetValue("LogLevel", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Lsa\\Credssp", true).SetValue("DebugLogLevel", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("AITEnable", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", true).SetValue("DisableInventory", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\current\\device\\Bluetooth", true).SetValue("AllowAdvertising", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("LinkResolveIgnoreLinkInfo", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoResolveSearch", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).SetValue("NoResolveTrack", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("EnableBalloonTips", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("StartButtonBalloonTip", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\usbflags", true).SetValue("DisableLPM", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\usbflags", true).SetValue("D3ColdSupported", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\usbflags", true).SetValue("AllowIdleIrpInD3", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Services\\USBHUB\\hubg", true).SetValue("ThrottleMask", -1, RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Services\\USBHUB\\hubg", true).SetValue("EnableDiagnosticMode", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Services\\USBHUB\\hubg", true).SetValue("PreventDebounceTimeForSuperSpeedDevices", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\usb\\Usb20HardwareLpm", true).SetValue("Usb20HardwareLpmOverride", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\usb\\Usb30HardwareLpm", true).SetValue("Usb30HardwareLpmOverride", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("ShowTaskViewButton", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("TaskbarDa", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\Microsoft.549981C3F5F10_8wekyb3d8bbwe!App", true).SetValue("AgentActivationEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps", true).SetValue("AgentActivationEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\ImproveInkingAndTyping", true).SetValue("Value", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\InkingAndTypingPersonalization", true).SetValue("Value", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Diagnostics\\DiagTrack", true).SetValue("ShowedToastAtLevel", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", true).SetValue("IsMSACloudSearchEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", true).SetValue("IsAADCloudSearchEnabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection", true).SetValue("MaxTelemetryAllowed", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked", true).SetValue("{9F156763-7844-4DC4-B2B1-901F640F5155}", "", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Windows.SystemToast.CapabilityAccess", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Windows.SystemToast.StartupApp", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Windows.SystemToast.Suggested", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Windows.SystemToast.SecurityAndMaintenance", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Utils.SysNativeCmd("Reg.exe add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Modules\\GlobalSettings\\Sizer\" /v PageSpaceControlSizer /t REG_BINARY /d a00000000100000000000000ec030000 /f");
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Diagnostics\\Performance\" /f /v DisableDiagnosticTracing /t REG_DWORD /d 1", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Control Panel\\Settings\\Network\" /f /v ReplaceVan /t REG_DWORD /d 2", false, false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}", false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe delete \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}\" /f /v ReplaceVan /t REG_DWORD /d 2", false, false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SOFTWARE\\WOW6432Node\\Classes\\CLSID\\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\\ShellFolder\" /f /v Attributes /t REG_DWORD /d 2962489444", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKCR\\CLSID\\{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}\\ShellFolder\" /f /v Attributes /t REG_DWORD /d 2962489444", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\NetCore\" /f /v Start /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\WMI\\Autologger\\RadioMgr\" /f /v Start /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Enum\\USB\\ROOT_HUB20\\4&144fac0d&0\\Device Parameters\" /f /v EnableSelectiveSuspend /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Enum\\USB\\ROOT_HUB20\\4&f432ec7&0\\Device Parameters\" /f /v EnableSelectiveSuspend /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Enum\\USB\\ROOT_HUB30\\4&318a7e80&0&0\\Device Parameters\\WDF\" /f /v IdleInWorkingState /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Enum\\USB\\ROOT_HUB30\\4&73f3995&0&0\\Device Parameters\\WDF\" /f /v IdleInWorkingState /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Enum\\USB\\VID_8087&PID_8001\\5&d1aa17f&0&1\\Device Parameters\" /f /v EnableSelectiveSuspend /t REG_DWORD /d 0", false, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Enum\\USB\\VID_8087&PID_8009\\5&182a3301&0&1\\Device Parameters\" /f /v EnableSelectiveSuspend /t REG_DWORD /d 0", false, false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\WlanSvc\\AnqpCache", true).SetValue("OsuRegistrationStatus", "0", RegistryValueKind.DWord);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SOFTWARE\\Classes\\{B4FB3F98-C1EA-428d-A78A-D1F5659CBA93}\" /f /v System.IsPinnedToNameSpaceTree /t REG_DWORD /d 0", false, false);
				Registry.ClassesRoot.CreateSubKey("CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}", true).SetValue("System.IsPinnedToNameSpaceTree", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("NavPaneShowAllCloudStates", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true).SetValue("LaunchTo", "1", RegistryValueKind.DWord);
				Registry.ClassesRoot.CreateSubKey(".pow", true).SetValue("", "Power Plan", RegistryValueKind.String);
				Registry.ClassesRoot.CreateSubKey(".pow", true).SetValue("FriendlyTypeName", "Power Plan", RegistryValueKind.String);
				Registry.ClassesRoot.CreateSubKey(".pow\\DefaultIcon", true).SetValue("", "%SystemRoot%\\System32\\powercfg.cpl,-202", RegistryValueKind.ExpandString);
				Registry.ClassesRoot.CreateSubKey(".pow\\shell\\Import\\command", true).SetValue("", "powercfg /import \"%1\"", RegistryValueKind.String);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked", true).SetValue("{1d27f844-3a1f-4410-85ac-14651078412d}", "", RegistryValueKind.String);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked", true).SetValue("{7AD84985-87B4-4a16-BE58-8B72A5B390F7}", "", RegistryValueKind.String);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\OpenWithList\\Excel.exe", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\OpenWithList\\IExplore.exe", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\OpenWithList\\MSPaint.exe", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\OpenWithList\\Winword.exe", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\ContextMenuHandlers\\ModernSharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\ContextMenuHandlers\\Sharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shellex\\ContextMenuHandlers\\Sharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\ContextMenuHandlers\\Open With EncryptionMenu", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\PropertySheetHandlers\\CryptoSignMenu", false);
				Registry.ClassesRoot.DeleteSubKeyTree("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\{596AB062-B4D2-4215-9F74-E9109B0A8153}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\{450D8FBA-AD25-11D0-98A8-0800361B1103}\\shellex\\ContextMenuHandlers\\{596AB062-B4D2-4215-9F74-E9109B0A8153}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\{450D8FBA-AD25-11D0-98A8-0800361B1103}\\shellex\\ContextMenuHandlers\\Offline Files", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shellex\\ContextMenuHandlers\\{596AB062-B4D2-4215-9F74-E9109B0A8153}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\ContextMenuHandlers\\{596AB062-B4D2-4215-9F74-E9109B0A8153}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shellex\\ContextMenuHandlers\\Offline Files", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shellex\\CopyHookHandlers\\Sharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\ContextMenuHandlers\\Sharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\PropertySheetHandlers\\Sharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\PropertySheetHandlers\\{55B3A0BD-4D28-42fe-8CFB-FA3EDFF969B8}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\PropertySheetHandlers\\{596AB062-B4D2-4215-9F74-E9109B0A8153}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\PropertySheetHandlers\\{7988B573-EC89-11cf-9C00-00AA00A14F56}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("exefile\\shellex\\ContextMenuHandlers\\PintoStartScreen", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\image\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\text\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("batfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("cmdfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("docfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("fonfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("htmlfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("inffile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("inifile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("JSEFile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("JSFile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("MSInfo.Document\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("otffile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("pfmfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("regfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("rtffile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("ttcfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("ttffile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("txtfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("VBEFile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("VBSFile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Wordpad.Document.1\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("WPEDoc\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("WPSDoc\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("wrifile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("WSFFile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("odtfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("docxfile\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("AcroExch.Document.7\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("FoxitReader.Document\\shell\\print", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shellex\\ContextMenuHandlers\\Offline Files", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shellex\\ContextMenuHandlers\\Library Location", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shellex\\ContextMenuHandlers\\PinToStartScreen", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\ContextMenuHandlers\\{90AA3A4E-1CBA-4233-B8BB-535773D48449}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\image\\shell\\edit", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\image\\shell\\Image Preview", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\.bmp\\ShellEx\\ContextMenuHandlers\\ShellImagePreview", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\.gif\\ShellEx\\ContextMenuHandlers\\ShellImagePreview", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\.jpg\\ShellEx\\ContextMenuHandlers\\ShellImagePreview", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\.jpeg\\ShellEx\\ContextMenuHandlers\\ShellImagePreview", false);
				Registry.ClassesRoot.DeleteSubKeyTree("SystemFileAssociations\\.png\\ShellEx\\ContextMenuHandlers\\ShellImagePreview", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\ContextMenuHandlers\\EPP", false);
				Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Directory\\shellex\\ContextMenuHandlers\\EPP", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shellex\\ContextMenuHandlers\\EPP", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Classes\\InternetShortcut\\shell\\print", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Classes\\AllFilesystemObjects\\shellex\\ContextMenuHandlers\\{474C98EE-CF3D-41f5-80E3-4AAB0AB04301}", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Classes\\AllFilesystemObjects\\shellex\\PropertySheetHandlers\\{596AB062-B4D2-4215-9F74-E9109B0A8153}", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Classes\\Folder\\shell\\pintohome", false);
				Registry.ClassesRoot.DeleteSubKeyTree("*\\shellex\\ContextMenuHandlers\\ModernSharing", false);
				Registry.ClassesRoot.DeleteSubKeyTree("exefile\\shellex\\ContextMenuHandlers\\PintoStartScreen", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shell\\pintohome", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shellex\\ContextMenuHandlers\\PintoStartScreen", false);
				Registry.ClassesRoot.DeleteSubKeyTree("Microsoft.Website\\ShellEx\\ContextMenuHandlers\\PintoStartScreen", false);
				Registry.ClassesRoot.DeleteSubKeyTree("mscfile\\shellex\\ContextMenuHandlers\\PintoStartScreen", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Multimedia\\Audio", true).SetValue("UserDuckingPreference", "3", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("ForegroundLockTimeout", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("MenuShowDelay", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("MouseWheelRouting", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("AutoEndTasks", "1", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\International\\User Profile", true).SetValue("HttpAcceptLanguageOptOut", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\SlateLaunch", true).SetValue("ATapp", "", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\SlateLaunch", true).SetValue("LaunchAT", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\SoundSentry", true).SetValue("Flags", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\SoundSentry", true).SetValue("FSTextEffect", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\SoundSentry", true).SetValue("TextEffect", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\SoundSentry", true).SetValue("WindowsEffect", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\StickyKeys", true).SetValue("Flags", "506", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\ToggleKeys", true).SetValue("Flags", "58", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\Keyboard Response", true).SetValue("Flags", "122", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Cursors", true).SetValue("ContactVisualization", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Cursors", true).SetValue("GestureVisualization", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("MenuShowDelay", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("ScreenSaverIsSecure", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("HungAppTimeout", "1000", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("LowLevelHooksTimeout", "1000", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("WaitToKillServiceTimeout", "1000", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("WaitToKillAppTimeout", "1000", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseHoverTime", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseSensitivity", "10", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseSpeed", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseThreshold1", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Mouse", true).SetValue("MouseThreshold2", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Sound", true).SetValue("Beep", "No", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Sound", true).SetValue("ExtendedSounds", "No", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableAutocorrection", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableDoubleTapSpace", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableInkingWithTouch", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\TabletTip\\1.7", true).SetValue("EnablePredictionSpaceInsertion", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableSpellchecking", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TabletTip\\1.7", true).SetValue("EnableTextPrediction", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\TabletPC", true).SetValue("TurnOffPenFeedback", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("EnableHwkbAutocorrection", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("EnableHwkbTextPrediction", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("InsightsEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\Settings", true).SetValue("MultilingualEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Input\\TIPC", true).SetValue("Enabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\pci\\Parameters", true).SetValue("DmaRemappingCompatible", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\e2fexpress\\Parameters", true).SetValue("DmaRemappingCompatible", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\storahci\\Parameters", true).SetValue("DmaRemappingCompatible", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\stornvme\\Parameters", true).SetValue("DmaRemappingCompatible", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\USBXHCI\\Parameters", true).SetValue("DmaRemappingCompatible", "2", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\USBXHCI\\Parameters", true).SetValue("DmaRemappingCompatibleSelfhost", "1", RegistryValueKind.DWord);
				RegistryKey registryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}", true);
				Regex regex = new Regex("\\d{4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				foreach (string text in registryKey.GetSubKeyNames())
				{
					if (regex.IsMatch(text))
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey(text, RegistryKeyPermissionCheck.ReadWriteSubTree);
						if (Convert.ToString(registryKey2.GetValue("DeviceInstanceID")).ToUpper().Contains("PCI\\VEN_".ToUpper()))
						{
							registryKey2.SetValue("*TxAbsIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("TxAbsIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("*RxAbsIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("RxAbsIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("*TxIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("TxIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("*RxIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("RxIntDelay", "1", RegistryValueKind.String);
							registryKey2.SetValue("*Enable9KJFTpt", "0", RegistryValueKind.String);
							registryKey2.SetValue("Enable9KJFTpt", "0", RegistryValueKind.String);
							registryKey2.SetValue("*AlternateSemaphoreDelay", "0", RegistryValueKind.String);
							registryKey2.SetValue("AlternateSemaphoreDelay", "0", RegistryValueKind.String);
							registryKey2.SetValue("*Node", "0", RegistryValueKind.String);
							registryKey2.SetValue("Node", "0", RegistryValueKind.String);
							registryKey2.SetValue("*PacketDirect", "1", RegistryValueKind.String);
							registryKey2.SetValue("NicAutoPowerSaver", "0", RegistryValueKind.String);
							registryKey2.SetValue("EnableDynamicPowerGating", "0", RegistryValueKind.String);
							registryKey2.SetValue("AutoPowerSaveModeEnabled", "0", RegistryValueKind.String);
							registryKey2.SetValue("EnableConnectedPowerGating", "0", RegistryValueKind.String);
							registryKey2.SetValue("EnablePowerManagement", "0", RegistryValueKind.String);
							registryKey2.SetValue("EnableSavePowerNow", "0", RegistryValueKind.String);
							registryKey2.SetValue("AdaptiveIFS", "0", RegistryValueKind.String);
							registryKey2.SetValue("EnablePME", "0", RegistryValueKind.String);
							registryKey2.SetValue("EEELinkAdvertisement", "0", RegistryValueKind.String);
							registryKey2.SetValue("LinkNegotiationProcess", "1", RegistryValueKind.String);
							registryKey2.SetValue("LogLinkStateEvent", "16", RegistryValueKind.String);
							registryKey2.SetValue("ReduceSpeedOnPowerDown", "0", RegistryValueKind.String);
							registryKey2.SetValue("SipsEnabled", "0", RegistryValueKind.String);
							registryKey2.SetValue("ULPMode", "0", RegistryValueKind.String);
							registryKey2.SetValue("WaitAutoNegComplete", "0", RegistryValueKind.String);
							registryKey2.SetValue("WakeOnLink", "0", RegistryValueKind.String);
							registryKey2.SetValue("AdvancedEEE", "0", RegistryValueKind.String);
							registryKey2.SetValue("*EEE", "0", RegistryValueKind.String);
							registryKey2.SetValue("GigaLite", "0", RegistryValueKind.String);
							registryKey2.SetValue("EnableGreenEthernet", "0", RegistryValueKind.String);
							registryKey2.SetValue("PowerSavingMode", "0", RegistryValueKind.String);
							registryKey2.SetValue("S5WakeOnLan", "0", RegistryValueKind.String);
							registryKey2.SetValue("*FlowControl", "0", RegistryValueKind.String);
							registryKey2.SetValue("*PMNSOffload", "0", RegistryValueKind.String);
							registryKey2.SetValue("*PMARPOffload", "0", RegistryValueKind.String);
							registryKey2.SetValue("*WakeOnMagicPacket", "0", RegistryValueKind.String);
							registryKey2.SetValue("*WakeOnPattern", "0", RegistryValueKind.String);
						}
					}
				}
				if (Utils.SystemInformation.GetWindowsVersion() == "22000")
				{
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer", true).DeleteValue("DisableNotificationCenter", false);
				}
			}
			Utils.ResetStatus();
		}
	}
}
