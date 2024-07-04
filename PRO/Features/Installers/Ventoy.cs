using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200005B RID: 91
	public class Ventoy : IFeature
	{
		// Token: 0x0600030C RID: 780 RVA: 0x0002E200 File Offset: 0x0002C400
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Ventoy\\Ventoy2Disk.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Ventoy\\", "Ventoy2Disk.exe", "", false);
				return;
			}
			Utils.Status("Downloading Ventoy...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/826634656479969320/Ventoy.zip"), Path.GetTempPath() + "\\Ventoy.zip");
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0002E2A4 File Offset: 0x0002C4A4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Ventoy: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (12.6MB)");
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0002E2F5 File Offset: 0x0002C4F5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Ventoy", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Ventoy\\", "Ventoy2Disk.exe", "", true);
		}
	}
}
