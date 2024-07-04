using System;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000022 RID: 34
	public class ToggleFullscreen : IFeature
	{
		// Token: 0x06000234 RID: 564 RVA: 0x00026C00 File Offset: 0x00024E00
		public void Execute()
		{
			Utils.Status("Tweaking FSE...");
			if (ToggleFullscreen.Settings.GetValue("FSE") != null)
			{
				ToggleFullscreen.Settings.DeleteValue("FSE", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("AllowAutoGameMode", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("AutoGameModeEnabled", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("GamePanelStartupTipIndex", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("ShowStartupPanel", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).DeleteValue("UseNexusForGameBarEnabled", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR", true).DeleteValue("AppCaptureEnabled", false);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR", false);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).DeleteValue("GameDVR_DSEBehavior", false);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_DXGIHonorFSEWindowsCompatible", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_EFSEFeatureFlags", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).DeleteValue("GameDVR_FSEBehavior", false);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_FSEBehaviorMode", "2", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_HonorUserFSEBehaviorMode", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", true).DeleteValue("AllowGameDVR", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", false);
				Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\default\\ApplicationManagement\\AllowGameDVR", true).SetValue("value", "1", RegistryValueKind.DWord);
				MainForm.Main.button63.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("AllowAutoGameMode", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("AutoGameModeEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("GamePanelStartupTipIndex", "3", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("ShowStartupPanel", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\GameBar", true).SetValue("UseNexusForGameBarEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\GameDVR", true).SetValue("AppCaptureEnabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).DeleteValue("Win32_AutoGameModeDefaultProfile", false);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).DeleteValue("Win32_GameModeRelatedProcesses", false);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_DSEBehavior", "2", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_DXGIHonorFSEWindowsCompatible", "1", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_EFSEFeatureFlags", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_Enabled", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_FSEBehavior", "2", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_FSEBehaviorMode", "2", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("System\\GameConfigStore", true).SetValue("GameDVR_HonorUserFSEBehaviorMode", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", true).SetValue("AllowGameDVR", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\PolicyManager\\default\\ApplicationManagement\\AllowGameDVR", true).SetValue("value", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.DeleteSubKeyTree("SYSTEM\\GameConfigStore\\Children", false);
				Registry.CurrentUser.DeleteSubKeyTree("SYSTEM\\GameConfigStore\\Parents", false);
				ToggleFullscreen.Settings.SetValue("FSE", "1", RegistryValueKind.DWord);
				MainForm.Main.button63.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000ED RID: 237
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
