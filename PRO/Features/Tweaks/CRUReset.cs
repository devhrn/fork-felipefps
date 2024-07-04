using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200000B RID: 11
	public class CRUReset : IFeature
	{
		// Token: 0x060001FD RID: 509 RVA: 0x0001ACAC File Offset: 0x00018EAC
		public void Execute()
		{
			Utils.Status("Reset CRU...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\reset-all.exe", "https://cdn.discordapp.com/attachments/762398248655913004/812117677320699927/reset-all.exe");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "reset-all.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
