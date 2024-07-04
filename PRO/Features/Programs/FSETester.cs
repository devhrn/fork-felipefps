using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200002D RID: 45
	public class FSETester : IFeature
	{
		// Token: 0x0600025A RID: 602 RVA: 0x000290FC File Offset: 0x000272FC
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\FullscreenExclusiveTester_binary.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "FullscreenExclusiveTester_binary.exe", "", false);
				return;
			}
			Utils.Status("Downloading FSETester...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/816670468580048926/FullscreenExclusiveTester_binary.exe"), Utils.AppData + "\\Felipe\\FullscreenExclusiveTester_binary.exe");
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000291A0 File Offset: 0x000273A0
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading FSETester: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.0MB)");
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000291F1 File Offset: 0x000273F1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "FullscreenExclusiveTester_binary.exe", "", true);
		}
	}
}
