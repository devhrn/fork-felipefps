using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200000C RID: 12
	public class CRURestart : IFeature
	{
		// Token: 0x060001FF RID: 511 RVA: 0x0001AD00 File Offset: 0x00018F00
		public void Execute()
		{
			Utils.Status("Restarting CRU...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\restart64.exe", "https://cdn.discordapp.com/attachments/762398248655913004/812127418436288572/restart64.exe");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "restart64.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
