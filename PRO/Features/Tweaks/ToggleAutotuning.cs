using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200001E RID: 30
	public class ToggleAutotuning : IFeature
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00024B7C File Offset: 0x00022D7C
		public void Execute()
		{
			Utils.Status("Tweaking Autotuning...");
			if (ToggleAutotuning.Settings.GetValue("Autotuning") != null)
			{
				ToggleAutotuning.Settings.DeleteValue("Autotuning", false);
				new Process
				{
					StartInfo = 
					{
						FileName = "netsh.exe",
						Arguments = "int tcp set global autotuninglevel=normal",
						WindowStyle = ProcessWindowStyle.Hidden,
						CreateNoWindow = true
					}
				}.Start();
				MainForm.Main.button64.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "netsh.exe",
						Arguments = "int tcp set global autotuninglevel=disabled",
						WindowStyle = ProcessWindowStyle.Hidden,
						CreateNoWindow = true
					}
				}.Start();
				ToggleAutotuning.Settings.SetValue("Autotuning", "1", RegistryValueKind.DWord);
				MainForm.Main.button64.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000E9 RID: 233
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
