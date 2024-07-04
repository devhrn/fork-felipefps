using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000098 RID: 152
	public class OCAT : IFeature
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x00033280 File Offset: 0x00031480
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\OCAT\\OCAT.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\OCAT\\", "OCAT.exe", "", false);
				return;
			}
			Utils.Status("Downloading OCAT...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839296403532021830/OCAT.zip"), Path.GetTempPath() + "\\OCAT.zip");
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00033324 File Offset: 0x00031524
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading OCAT: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.6MB)");
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00033375 File Offset: 0x00031575
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("OCAT", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\OCAT\\", "OCAT.exe", "", true);
		}
	}
}
