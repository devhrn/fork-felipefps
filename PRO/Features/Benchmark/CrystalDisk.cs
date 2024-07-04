using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200008A RID: 138
	public class CrystalDisk : IFeature
	{
		// Token: 0x060003BA RID: 954 RVA: 0x000322D0 File Offset: 0x000304D0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\CrystalDiskMark\\DiskMark64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\CrystalDiskMark\\", "DiskMark64.exe", "", false);
				return;
			}
			Utils.Status("Downloading CrystalDiskMark...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839002286025605200/CrystalDiskMark.zip"), Path.GetTempPath() + "\\CrystalDiskMark.zip");
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00032374 File Offset: 0x00030574
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading CrystalDiskMark: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (4.0MB)");
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000323C5 File Offset: 0x000305C5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("CrystalDiskMark", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\CrystalDiskMark\\", "DiskMark64.exe", "", true);
		}
	}
}
