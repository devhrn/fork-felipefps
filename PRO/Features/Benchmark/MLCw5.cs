using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000096 RID: 150
	public class MLCw5 : IFeature
	{
		// Token: 0x060003EA RID: 1002 RVA: 0x00033044 File Offset: 0x00031244
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\MLC\\mlc.exe"))
			{
				Utils.StartProcessCmd(Utils.AppData + "\\Felipe\\MLC", "/k mlc --loaded_latency -r -W5", false);
				return;
			}
			Utils.Status("Downloading Intel Memory Latency Checker...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803574724323311676/MLC.zip"), Path.GetTempPath() + "\\MLC.zip");
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x000330E4 File Offset: 0x000312E4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Intel Memory Latency Checker: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (200KB)");
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00033135 File Offset: 0x00031335
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("MLC", false);
			Utils.StartProcessCmd(Utils.AppData + "\\Felipe\\MLC", "/k mlc --loaded_latency -r -W5", true);
		}
	}
}
