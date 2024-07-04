using System;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000020 RID: 32
	public class ToggleDefender : IFeature
	{
		// Token: 0x0600022E RID: 558 RVA: 0x000268AC File Offset: 0x00024AAC
		public void Execute()
		{
			Utils.Status("Toggling Defender...");
			if (ToggleDefender.Settings.GetValue("Defender") != null)
			{
				Utils.RegServiceNSudo("WdBoot", "0");
				Utils.RegServiceNSudo("WdFilter", "0");
				Utils.RegServiceNSudo("WdNisDrv", "3");
				Utils.RegServiceNSudo("WdNisSvc", "3");
				Utils.RegServiceNSudo("WinDefend", "2");
				Utils.RegServiceNSudo("wscsvc", "2");
				Utils.RegServiceNSudo("sense", "3");
				Utils.RegServiceNSudo("MsSecFlt", "0");
				Utils.RegServiceNSudo("SecurityHealthService", "3");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments", true).DeleteValue("ScanWithAntiVirus", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).DeleteValue("EnableSmartScreen", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).DeleteValue("SmartScreenEnabled", false);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).DeleteValue("SmartScreenEnabled", false);
				ToggleDefender.Settings.DeleteValue("Defender", false);
				MainForm.Main.button58.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				Utils.RegServiceNSudo("WdBoot", "4");
				Utils.RegServiceNSudo("WdFilter", "4");
				Utils.RegServiceNSudo("WdNisDrv", "4");
				Utils.RegServiceNSudo("WdNisSvc", "4");
				Utils.RegServiceNSudo("WinDefend", "4");
				Utils.RegServiceNSudo("wscsvc", "4");
				Utils.RegServiceNSudo("sense", "4");
				Utils.RegServiceNSudo("MsSecFlt", "4");
				Utils.RegServiceNSudo("SecurityHealthService", "4");
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments", true).SetValue("ScanWithAntiVirus", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System", true).SetValue("EnableSmartScreen", "0", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).SetValue("SmartScreenEnabled", "Off", RegistryValueKind.String);
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).SetValue("SmartScreenEnabled", "Off", RegistryValueKind.String);
				ToggleDefender.Settings.SetValue("Defender", "1", RegistryValueKind.DWord);
				MainForm.Main.button58.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000EB RID: 235
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
