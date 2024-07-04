using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000087 RID: 135
	public class ZenTimings : IFeature
	{
		// Token: 0x060003B0 RID: 944 RVA: 0x0003207C File Offset: 0x0003027C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\ZenTimings\\ZenTimings.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\ZenTimings\\", "ZenTimings.exe", "", false);
				return;
			}
			Utils.Status("Downloading ZenTimings...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/819360994680897536/ZenTimings.zip"), Path.GetTempPath() + "\\ZenTimings.zip");
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00032120 File Offset: 0x00030320
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ZenTimings: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (455KB)");
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00032171 File Offset: 0x00030371
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("ZenTimings", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\ZenTimings\\", "ZenTimings.exe", "", true);
		}
	}
}
