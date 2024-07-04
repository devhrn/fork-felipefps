using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200007C RID: 124
	public class ProcessHacker : IFeature
	{
		// Token: 0x06000386 RID: 902 RVA: 0x0003147C File Offset: 0x0002F67C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\PH\\ProcessHacker.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\PH\\", "ProcessHacker.exe", "", false);
				return;
			}
			Utils.Status("Downloading ProcessHacker...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/851491166406311956/PH.zip"), Path.GetTempPath() + "\\PH.zip");
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00031520 File Offset: 0x0002F720
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ProcessHacker: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (3.8MB)");
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00031571 File Offset: 0x0002F771
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("PH", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\PH\\", "ProcessHacker.exe", "", true);
		}
	}
}
