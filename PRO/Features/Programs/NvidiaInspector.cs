using System;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000034 RID: 52
	public class NvidiaInspector : IFeature
	{
		// Token: 0x06000276 RID: 630 RVA: 0x00029A7C File Offset: 0x00027C7C
		public void Execute()
		{
			Utils.Status("Launching NVIDIA Profile Inspector...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\nvidiaProfileInspector.exe", "https://cdn.discordapp.com/attachments/762398248655913004/802528994586394634/nvidiaProfileInspector.exe");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\Reference.xml", "https://cdn.discordapp.com/attachments/762398248655913004/802528993257586688/Reference.xml");
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "nvidiaProfileInspector.exe", "", false);
			Utils.ResetStatus();
		}
	}
}
