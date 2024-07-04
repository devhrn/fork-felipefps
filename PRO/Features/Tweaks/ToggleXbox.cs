using System;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000025 RID: 37
	public class ToggleXbox : IFeature
	{
		// Token: 0x0600023D RID: 573 RVA: 0x00028388 File Offset: 0x00026588
		public void Execute()
		{
			Utils.Status("Tweaking GameBar...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258238388436336660/NSudoLC.exe?ex=66875150&is=6685ffd0&hm=5bcd0730110a96d5836e1e4e2db9675915131d69202e894a0286cffd2075f605&");
			if (ToggleXbox.Settings.GetValue("GameBar") != null)
			{
				ToggleXbox.Settings.DeleteValue("GameBar", false);
				Utils.ExecuteProcess("cmd.exe", "/c taskkill /F /FI \"IMAGENAME eq GameBarPresenceWriter.exe", true, false);
				Utils.ExecuteProcess("cmd.exe", "/c IF EXIST %WINDIR%\\System32\\gamebarpresencewriter.old takeown /F %WINDIR%\\System32\\gamebarpresencewriter.old /A & icacls %WINDIR%\\System32\\gamebarpresencewriter.old /grant Administrators:(F)", true, false);
				Utils.ExecuteProcess("cmd.exe", "/c IF NOT EXIST %WINDIR%\\System32\\gamebarpresencewriter.exe IF EXIST %WINDIR%\\System32\\gamebarpresencewriter.old REN %WINDIR%\\System32\\gamebarpresencewriter.old gamebarpresencewriter.exe", true, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe delete \"HKCU\\SOFTWARE\\Microsoft\\WindowsRuntime\\ActivatableClassId\\Windows.Gaming.GameBar.PresenceServer.Internal.PresenceWriter\" /f /v ActivationType", false, false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("AllowAutoGameMode", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("AutoGameModeEnabled", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("GamePanelStartupTipIndex", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("ShowStartupPanel", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("UseNexusForGameBarEnabled", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR", true).DeleteValue("AppCaptureEnabled", false);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_Enabled", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\default\\ApplicationManagement\\AllowGameDVR", true).SetValue("value", "1", RegistryValueKind.DWord);
				MainForm.Main.button62.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				Utils.ExecuteProcess("cmd.exe", "/c taskkill /F /FI \"IMAGENAME eq GameBarPresenceWriter.exe\"", true, false);
				Utils.ExecuteProcess("cmd.exe", "/c IF EXIST %WINDIR%\\System32\\gamebarpresencewriter.exe takeown /F %WINDIR%\\System32\\gamebarpresencewriter.exe /A & icacls %WINDIR%\\System32\\gamebarpresencewriter.exe /grant Administrators:(F)", true, false);
				Utils.ExecuteProcess("cmd.exe", "/c IF NOT EXIST %WINDIR%\\System32\\gamebarpresencewriter.old IF EXIST %WINDIR%\\System32\\gamebarpresencewriter.exe REN %WINDIR%\\System32\\gamebarpresencewriter.exe gamebarpresencewriter.old", true, false);
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E -ShowWindowMode:Hide cmd /c Reg.exe add \"HKCU\\SOFTWARE\\Microsoft\\WindowsRuntime\\ActivatableClassId\\Windows.Gaming.GameBar.PresenceServer.Internal.PresenceWriter\" /f /v ActivationType /t REG_DWORD /d 0", false, false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("AllowAutoGameMode", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("AutoGameModeEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("GamePanelStartupTipIndex", "3", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("ShowStartupPanel", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("UseNexusForGameBarEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR", true).SetValue("AppCaptureEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_Enabled", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", true).SetValue("AllowGameDVR", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\default\\ApplicationManagement\\AllowGameDVR", true).SetValue("value", "0", RegistryValueKind.DWord);
				ToggleXbox.Settings.SetValue("GameBar", "1", RegistryValueKind.DWord);
				MainForm.Main.button62.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000F0 RID: 240
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
