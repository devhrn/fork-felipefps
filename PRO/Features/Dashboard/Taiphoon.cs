using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000082 RID: 130
	public class Taiphoon : IFeature
	{
		// Token: 0x0600039C RID: 924 RVA: 0x00031AC8 File Offset: 0x0002FCC8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Thaiphoon\\Thaiphoon.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Thaiphoon\\", "Thaiphoon.exe", "", false);
				return;
			}
			Utils.Status("Downloading Thaiphoon...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/813112828738928711/Thaiphoon.zip"), Path.GetTempPath() + "\\Thaiphoon.zip");
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00031B6C File Offset: 0x0002FD6C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Thaiphoon: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (4.3MB)");
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00031BBD File Offset: 0x0002FDBD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Thaiphoon", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Thaiphoon\\", "Thaiphoon.exe", "", true);
		}
	}
}
