using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200001B RID: 27
	public class RestartGraphics : IFeature
	{
		// Token: 0x06000221 RID: 545 RVA: 0x00022260 File Offset: 0x00020460
		public void Execute()
		{
			Utils.Status("Restarting Graphics...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\restart-only.exe", "https://cdn.discordapp.com/attachments/773065487990784021/773426817184694298/restart-only.exe");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "restart-only.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
