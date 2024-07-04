using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200003B RID: 59
	public class UsbTreeView : IFeature
	{
		// Token: 0x06000290 RID: 656 RVA: 0x0002A1A0 File Offset: 0x000283A0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\UsbTreeView.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "UsbTreeView.exe", "", false);
				return;
			}
			Utils.Status("Downloading UsbTreeView...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852933477220220959/UsbTreeView.exe"), Utils.AppData + "\\Felipe\\UsbTreeView.exe");
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0002A244 File Offset: 0x00028444
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading UsbTreeView: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (669KB)");
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0002A295 File Offset: 0x00028495
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "UsbTreeView.exe", "", true);
		}
	}
}
