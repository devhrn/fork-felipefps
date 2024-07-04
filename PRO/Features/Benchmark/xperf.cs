using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x020000A0 RID: 160
	public class xperf : IFeature
	{
		// Token: 0x06000410 RID: 1040 RVA: 0x00033A40 File Offset: 0x00031C40
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\xperf.bat"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "xperf.bat", "", false);
				return;
			}
			Utils.Status("Downloading xperf...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/867864104709914704/xperf.zip"), Path.GetTempPath() + "\\xperf.zip");
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00033AE4 File Offset: 0x00031CE4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading xperf: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (44.5MB)");
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00033B35 File Offset: 0x00031D35
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("xperf", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "xperf.bat", "", true);
		}
	}
}
