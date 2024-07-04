using System;
using System.Diagnostics;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200006D RID: 109
	public class DeviceManager : IFeature
	{
		// Token: 0x06000350 RID: 848 RVA: 0x0002F644 File Offset: 0x0002D844
		public void Execute()
		{
			Utils.Status("Tweaking Devices...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258238388436336660/NSudoLC.exe?ex=66875150&is=6685ffd0&hm=5bcd0730110a96d5836e1e4e2db9675915131d69202e894a0286cffd2075f605&");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\DeviceCleanupCmd.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258238611241828402/DeviceCleanupCmd.exe?ex=66875185&is=66860005&hm=ee3ef6095dd1964a913a00044583dda8d0767479b60c4949f5bb22d22c0cd9ca&");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment", true).SetValue("DEVMGR_SHOW_NONPRESENT_DEVICES", "1", RegistryValueKind.DWord);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKLM\\SYSTEM\\ControlSet001\\Enum\\PCI\\VEN_10DE&DEV_0FBB&SUBSYS_36961458&REV_A1\\4&3834d97&0&0108\\Device Parameters\\WDF\" /f /v IdleInWorkingState /t REG_DWORD /d 0", false, false);
			Utils.ExecuteProcess("powershell.exe", "$devices = Get-WmiObject Win32_PnPEntity; $powerMgmt = Get-WmiObject MSPower_DeviceEnable -Namespace root\\wmi; foreach ($p in $powerMgmt){$IN = $p.InstanceName.ToUpper(); foreach ($h in $devices){$PNPDI = $h.PNPDeviceID; if ($IN -like \\\"*$PNPDI*\\\"){$p.enable = $False; $p.psbase.put()}}}", false, false);
			foreach (string str in "for /f %%a in ('wmic PATH Win32_PnPEntity GET DeviceID ^| findstr /l USB\\VID_') do (\r\nC:\\Windows\\SetACL.exe -on HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters -ot reg -actn setowner -ownr n:Administrators\r\nC:\\Windows\\SetACL.exe -on HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters -ot reg -actn ace -ace n:Administrators;p:full,\r\nreg.exe add HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters /v SelectiveSuspendOn /t REG_DWORD /d 00000000 /f,\r\nreg.exe add HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters /v SelectiveSuspendEnabled /t REG_BINARY /d 00 /f,\r\nreg.exe add HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters /v EnhancedPowerManagementEnabled /t REG_DWORD /d 00000000 /f,\r\nreg.exe add HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters /v AllowIdleIrpInD3 /t REG_DWORD /d 00000000 /f,\r\n)\r\nfor /f %%a in ('wmic PATH Win32_USBHub GET DeviceID ^| findstr /l USB\\ROOT_HUB') do (\r\nC:\\Windows\\SetACL.exe -on HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters\\WDF -ot reg -actn setowner -ownr n:Administrators,\r\nreg.exe add HKLM\\SYSTEM\\ControlSet001\\Enum\\%%a\\Device Parameters\\WDF /v IdleInWorkingState /t REG_DWORD /d 00000000 /f,\r\n)".Split(new char[]
			{
				','
			}))
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c " + str,
					WindowStyle = ProcessWindowStyle.Hidden
				});
			}
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\DeviceCleanupCmd.exe", "* -n", false, false);
			Utils.StartProcess("", "devmgmt.msc", "", true);
			Utils.ResetStatus();
		}
	}
}
