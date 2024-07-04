using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000038 RID: 56
	public class SPPT : IFeature
	{
		// Token: 0x06000284 RID: 644 RVA: 0x00029E40 File Offset: 0x00028040
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\SPPT\\SPPT Tool.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\SPPT\\", "SPPT Tool.exe", "", false);
				return;
			}
			Utils.Status("Downloading SPPT...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/881324499646160907/SPPT.zip"), Path.GetTempPath() + "\\SPPT.zip");
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00029EE4 File Offset: 0x000280E4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading SPPT: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (146KB)");
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00029F35 File Offset: 0x00028135
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("SPPT", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\SPPT\\", "SPPT Tool.exe", "", true);
		}
	}
}
