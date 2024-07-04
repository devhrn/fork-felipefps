using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000042 RID: 66
	public class Discord : IFeature
	{
		// Token: 0x060002AC RID: 684 RVA: 0x0002A99C File Offset: 0x00028B9C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\DiscordSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DiscordSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Discord...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://discord.com/api/download?platform=win"), Utils.AppData + "\\Felipe\\DiscordSetup.exe");
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0002AA40 File Offset: 0x00028C40
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Discord: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (67.6MB)");
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0002AA91 File Offset: 0x00028C91
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DiscordSetup.exe", "", true);
		}
	}
}
