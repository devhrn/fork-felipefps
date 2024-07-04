using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000075 RID: 117
	public class MLC : IFeature
	{
		// Token: 0x0600036E RID: 878 RVA: 0x0002FF94 File Offset: 0x0002E194
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\MLC\\mlc.exe"))
			{
				Utils.StartProcessCmd(Utils.AppData + "\\Felipe\\MLC", "/k mlc --loaded_latency -t5", false);
				return;
			}
			Utils.Status("Downloading Intel Memory Latency Checker...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803574724323311676/MLC.zip"), Path.GetTempPath() + "\\MLC.zip");
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00030034 File Offset: 0x0002E234
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Intel Memory Latency Checker: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (200KB)");
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00030085 File Offset: 0x0002E285
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("MLC", false);
			Utils.StartProcessCmd(Utils.AppData + "\\Felipe\\MLC", "/k mlc --loaded_latency -t5", true);
		}
	}
}
