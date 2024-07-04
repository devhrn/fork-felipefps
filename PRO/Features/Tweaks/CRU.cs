using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200000A RID: 10
	public class CRU : IFeature
	{
		// Token: 0x060001FB RID: 507 RVA: 0x0001AC58 File Offset: 0x00018E58
		public void Execute()
		{
			Utils.Status("Launching CRU...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\CRU.exe", "https://cdn.discordapp.com/attachments/762398248655913004/804352421705941062/CRU.exe");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "CRU.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
