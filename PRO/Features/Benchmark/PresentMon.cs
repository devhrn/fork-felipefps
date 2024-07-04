using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200009A RID: 154
	public class PresentMon : IFeature
	{
		// Token: 0x060003FA RID: 1018 RVA: 0x000334C8 File Offset: 0x000316C8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\PresentMon.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "PresentMon.exe", "", false);
				return;
			}
			Utils.Status("Downloading PresentMon...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/873092141390376980/877171621486547004/PresentMon.exe"), Utils.AppData + "\\Felipe\\PresentMon.exe");
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0003356C File Offset: 0x0003176C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading PresentMon: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (288KB)");
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000335BD File Offset: 0x000317BD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "PresentMon.exe", "", true);
		}
	}
}
