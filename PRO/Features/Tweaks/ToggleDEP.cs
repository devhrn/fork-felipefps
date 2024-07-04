using System;
using System.Drawing;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000021 RID: 33
	public class ToggleDEP : IFeature
	{
		// Token: 0x06000231 RID: 561 RVA: 0x00026B4C File Offset: 0x00024D4C
		public void Execute()
		{
			Utils.Status("Tweaking DEP...");
			if (ToggleDEP.Settings.GetValue("DEP") != null)
			{
				ToggleDEP.Settings.DeleteValue("DEP", false);
				Utils.SysNativeCmd("bcdedit.exe /deletevalue nx");
				MainForm.Main.button56.BackColor = Color.FromArgb(5, 8, 10);
			}
			else
			{
				Utils.SysNativeCmd("bcdedit.exe /set nx AlwaysOff");
				ToggleDEP.Settings.SetValue("DEP", "1", RegistryValueKind.DWord);
				MainForm.Main.button56.BackColor = Color.FromArgb(5, 88, 10);
			}
			Utils.ResetStatus();
		}

		// Token: 0x040000EC RID: 236
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
