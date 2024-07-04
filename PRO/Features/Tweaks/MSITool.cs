using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000015 RID: 21
	public class MSITool : IFeature
	{
		// Token: 0x06000213 RID: 531 RVA: 0x0001D058 File Offset: 0x0001B258
		public void Execute()
		{
			Utils.Status("Launching MSI Tool...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\MSI_util_v3.exe", "https://cdn.discordapp.com/attachments/762398248655913004/824699793309827082/MSI_util_v3.exe");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "MSI_util_v3.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
