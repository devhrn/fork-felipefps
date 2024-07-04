using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000030 RID: 48
	public class Keys2xInput : IFeature
	{
		// Token: 0x06000266 RID: 614 RVA: 0x000294B0 File Offset: 0x000276B0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\DoMove\\DoMove.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\DoMove\\", "DoMove.exe", "", false);
				return;
			}
			Utils.Status("Downloading Keys2xInput...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/844884111821897758/DoMove.zip"), Path.GetTempPath() + "\\DoMove.zip");
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00029554 File Offset: 0x00027754
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Keys2xInput: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (55KB)");
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000295A5 File Offset: 0x000277A5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("DoMove", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\DoMove\\", "DoMove.exe", "", true);
		}
	}
}
