using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000086 RID: 134
	public class VirusTotal : IFeature
	{
		// Token: 0x060003AC RID: 940 RVA: 0x00031F58 File Offset: 0x00030158
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\VirusTotal\\uploader.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\VirusTotal\\", "uploader.exe", "", false);
				return;
			}
			Utils.Status("Downloading VirusTotal Uploader...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/840305939596050462/VirusTotal.zip"), Path.GetTempPath() + "\\VirusTotal.zip");
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00031FFC File Offset: 0x000301FC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading VirusTotal Uploader: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (528KB)");
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0003204D File Offset: 0x0003024D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("VirusTotal", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\VirusTotal\\", "uploader.exe", "", true);
		}
	}
}
