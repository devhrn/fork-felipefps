using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000014 RID: 20
	public class InterruptAffinity : IFeature
	{
		// Token: 0x06000211 RID: 529 RVA: 0x0001D004 File Offset: 0x0001B204
		public void Execute()
		{
			Utils.Status("Launching Interrupt Affinity...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\intPolicy_x64.exe", "https://cdn.discordapp.com/attachments/762398248655913004/824699695670362112/intPolicy_x64.exe");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "intPolicy_x64.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
