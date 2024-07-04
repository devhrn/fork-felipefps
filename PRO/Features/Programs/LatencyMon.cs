using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000031 RID: 49
	public class LatencyMon : IFeature
	{
		// Token: 0x0600026A RID: 618 RVA: 0x000295D4 File Offset: 0x000277D4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\LatencyMon\\LatMon.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\LatencyMon\\", "LatMon.exe", "", false);
				return;
			}
			Utils.Status("Downloading LatencyMon...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803563701788999680/LatencyMon.zip"), Path.GetTempPath() + "\\LatencyMon.zip");
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00029678 File Offset: 0x00027878
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading LatencyMon: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (2.9MB)");
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000296C9 File Offset: 0x000278C9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("LatencyMon", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\LatencyMon\\", "LatMon.exe", "", true);
		}
	}
}
