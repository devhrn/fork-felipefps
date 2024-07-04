using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200009E RID: 158
	public class UserBenchmark : IFeature
	{
		// Token: 0x06000408 RID: 1032 RVA: 0x00033810 File Offset: 0x00031A10
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\PerformanceTestInstaller.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "PerformanceTestInstaller.exe", "", false);
				return;
			}
			Utils.Status("Downloading PassMark PerformanceTest...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/842272987831074836/PerformanceTestInstaller.exe"), Utils.AppData + "\\Felipe\\PerformanceTestInstaller.exe");
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x000338B4 File Offset: 0x00031AB4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading PassMark PerformanceTest: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (66.5MB)");
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00033905 File Offset: 0x00031B05
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "PerformanceTestInstaller.exe", "", true);
		}
	}
}
