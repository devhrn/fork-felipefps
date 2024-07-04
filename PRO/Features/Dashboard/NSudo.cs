using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000077 RID: 119
	public class NSudo : IFeature
	{
		// Token: 0x06000374 RID: 884 RVA: 0x000300BC File Offset: 0x0002E2BC
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\NSudoLG.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "NSudoLG.exe", "", false);
				return;
			}
			Utils.Status("Downloading NSudoLG...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/851487440304865330/NSudoLG.exe"), Utils.AppData + "\\Felipe\\NSudoLG.exe");
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00030160 File Offset: 0x0002E360
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading NSudoLG: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (160KB)");
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000301B1 File Offset: 0x0002E3B1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "NSudoLG.exe", "", true);
		}
	}
}
