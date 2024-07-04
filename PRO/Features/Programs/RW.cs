using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000037 RID: 55
	public class RW : IFeature
	{
		// Token: 0x06000280 RID: 640 RVA: 0x00029D1C File Offset: 0x00027F1C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\RW\\Rw.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\RW\\", "Rw.exe", "", false);
				return;
			}
			Utils.Status("Downloading RWEverything...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/847649563052343306/RW.zip"), Path.GetTempPath() + "\\RW.zip");
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00029DC0 File Offset: 0x00027FC0
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading RWEverything: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (5.9MB)");
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00029E11 File Offset: 0x00028011
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("RW", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\RW\\", "Rw.exe", "", true);
		}
	}
}
