using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200003A RID: 58
	public class trianglebin : IFeature
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0002A07C File Offset: 0x0002827C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\trianglebin\\trianglebin.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\trianglebin\\", "trianglebin.exe", "", false);
				return;
			}
			Utils.Status("Downloading trianglebin...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/856008020625981480/trianglebin.zip"), Path.GetTempPath() + "\\trianglebin.zip");
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0002A120 File Offset: 0x00028320
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading trianglebin: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (236KB)");
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0002A171 File Offset: 0x00028371
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("trianglebin", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\trianglebin\\", "trianglebin.exe", "", true);
		}
	}
}
