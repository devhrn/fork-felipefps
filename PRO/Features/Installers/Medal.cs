using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200004A RID: 74
	public class Medal : IFeature
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x0002B318 File Offset: 0x00029518
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\MedalSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "MedalSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Medal...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/865156062700896276/MedalInstaller.exe"), Utils.AppData + "\\Felipe\\MedalSetup.exe");
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0002B3BC File Offset: 0x000295BC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Medal: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (98.8MB)");
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0002B40D File Offset: 0x0002960D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "MedalSetup.exe", "", true);
		}
	}
}
