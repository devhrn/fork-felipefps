using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000099 RID: 153
	public class PMT : IFeature
	{
		// Token: 0x060003F6 RID: 1014 RVA: 0x000333A4 File Offset: 0x000315A4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\PMT\\Performance Measurement Tool.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\PMT\\", "Performance Measurement Tool.exe", "", false);
				return;
			}
			Utils.Status("Downloading Performance Measurement Tool...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/880608055191031858/PMT.zip"), Path.GetTempPath() + "\\PMT.zip");
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00033448 File Offset: 0x00031648
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Performance Measurement Tool: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (0.4MB)");
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00033499 File Offset: 0x00031699
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("PMT", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\PMT\\", "Performance Measurement Tool.exe", "", true);
		}
	}
}
