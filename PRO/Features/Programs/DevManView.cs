using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200002C RID: 44
	public class DevManView : IFeature
	{
		// Token: 0x06000256 RID: 598 RVA: 0x00028FE4 File Offset: 0x000271E4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\DevManView.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DevManView.exe", "", false);
				return;
			}
			Utils.Status("Downloading DevManView...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852923450753941524/DevManView.exe"), Utils.AppData + "\\Felipe\\DevManView.exe");
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00029088 File Offset: 0x00027288
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading DevManView: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (112KB)");
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000290D9 File Offset: 0x000272D9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DevManView.exe", "", true);
		}
	}
}
