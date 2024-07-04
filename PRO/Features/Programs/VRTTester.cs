using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200003C RID: 60
	public class VRTTester : IFeature
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0002A2B8 File Offset: 0x000284B8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Benchmark.DX9.Human.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Benchmark.DX9.Human.exe", "", false);
				return;
			}
			Utils.Status("Downloading Benchmark.DX9.Human...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/857644916482244628/Benchmark.DX9.Human.exe"), Utils.AppData + "\\Felipe\\Benchmark.DX9.Human.exe");
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0002A35C File Offset: 0x0002855C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Benchmark.DX9.Human: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (20KB)");
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0002A3AD File Offset: 0x000285AD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Benchmark.DX9.Human.exe", "", true);
		}
	}
}
