using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200007D RID: 125
	public class ProcessLasso : IFeature
	{
		// Token: 0x0600038A RID: 906 RVA: 0x000315A0 File Offset: 0x0002F7A0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\PL\\ProcessLasso.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\PL\\", "ProcessLasso.exe", "", false);
				return;
			}
			Utils.Status("Downloading ProcessLasso...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/851492805980454922/PL.zip"), Path.GetTempPath() + "\\PL.zip");
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00031644 File Offset: 0x0002F844
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ProcessLasso: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (6.6MB)");
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00031695 File Offset: 0x0002F895
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("PL", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\PL\\", "ProcessLasso.exe", "", true);
		}
	}
}
