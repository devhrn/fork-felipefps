using System;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000024 RID: 36
	public class ToggleVisualFX : IFeature
	{
		// Token: 0x0600023A RID: 570 RVA: 0x00028150 File Offset: 0x00026350
		public void Execute()
		{
			Utils.Status("Tweaking VisualFX...");
			if (ToggleVisualFX.Settings.GetValue("VisualFX") != null)
			{
				ToggleVisualFX.Settings.DeleteValue("VisualFX", false);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("DragFullWindows", "1", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("FontSmoothing", "2", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("MenuShowDelay", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("UserPreferencesMask", new byte[]
				{
					158,
					30,
					7,
					128,
					18,
					0,
					0,
					0
				}, RegistryValueKind.Binary);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop\\WindowMetrics", true).SetValue("MinAnimate", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", true).DeleteValue("VisualFXSetting", false);
				MainForm.Main.button66.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("DragFullWindows", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("FontSmoothing", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("MenuShowDelay", "0", RegistryValueKind.String);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop", true).SetValue("UserPreferencesMask", new byte[]
				{
					144,
					18,
					3,
					128,
					16,
					0,
					0,
					0
				}, RegistryValueKind.Binary);
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop\\WindowMetrics", true).SetValue("MinAnimate", "0", RegistryValueKind.DWord);
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", true).SetValue("VisualFXSetting", "2", RegistryValueKind.DWord);
				ToggleVisualFX.Settings.SetValue("VisualFX", "1", RegistryValueKind.DWord);
				MainForm.Main.button66.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000EF RID: 239
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
