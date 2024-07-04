using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000095 RID: 149
	public class MLCadam : IFeature
	{
		// Token: 0x060003E6 RID: 998 RVA: 0x00032F2C File Offset: 0x0003112C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\MLC\\mlc.exe"))
			{
				Utils.StartProcessCmd(Utils.AppData + "\\Felipe\\MLC", "/k mlc --loaded_latency -w9 -d2000 -t10 -r -D16208", false);
				return;
			}
			Utils.Status("Downloading Intel Memory Latency Checker...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803574724323311676/MLC.zip"), Path.GetTempPath() + "\\MLC.zip");
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00032FCC File Offset: 0x000311CC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Intel Memory Latency Checker: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (200KB)");
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0003301D File Offset: 0x0003121D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("MLC", false);
			Utils.StartProcessCmd(Utils.AppData + "\\Felipe\\MLC", "/k mlc --loaded_latency -w9 -d2000 -t10 -r -D16208", true);
		}
	}
}
