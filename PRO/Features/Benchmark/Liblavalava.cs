using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000093 RID: 147
	public class Liblavalava : IFeature
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00032CE4 File Offset: 0x00030EE4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Lava\\lava-lamp.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Lava\\", "lava-lamp.exe", "", false);
				return;
			}
			Utils.Status("Downloading lava-lamp...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/840097820349562900/Lava.zip"), Path.GetTempPath() + "\\Lava.zip");
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00032D88 File Offset: 0x00030F88
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading lava-lamp: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (3.6MB)");
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00032DD9 File Offset: 0x00030FD9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Lava", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Lava\\", "lava-lamp.exe", "", true);
		}
	}
}
