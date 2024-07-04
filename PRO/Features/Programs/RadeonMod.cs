using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000036 RID: 54
	public class RadeonMod : IFeature
	{
		// Token: 0x0600027C RID: 636 RVA: 0x00029C04 File Offset: 0x00027E04
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\RadeonMod.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "RadeonMod.exe", "", false);
				return;
			}
			Utils.Status("Downloading RadeonMod...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/880612788425338930/RadeonMod.exe"), Utils.AppData + "\\Felipe\\RadeonMod.exe");
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00029CA8 File Offset: 0x00027EA8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading RadeonMod: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.1MB)");
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00029CF9 File Offset: 0x00027EF9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "RadeonMod.exe", "", true);
		}
	}
}
