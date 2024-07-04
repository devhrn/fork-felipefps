using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200008D RID: 141
	public class FrogPursuit : IFeature
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x00032630 File Offset: 0x00030830
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\FrogPursuit\\FrogPursuit.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\FrogPursuit\\", "FrogPursuit.exe", "", false);
				return;
			}
			Utils.Status("Downloading FrogPursuit...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852949442642182184/FrogPursuit.zip"), Path.GetTempPath() + "\\FrogPursuit.zip");
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000326D4 File Offset: 0x000308D4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading FrogPursuit: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (59.6MB)");
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00032725 File Offset: 0x00030925
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("FrogPursuit", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\FrogPursuit\\", "FrogPursuit.exe", "", true);
		}
	}
}
