using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200008B RID: 139
	public class DNSBenchmark : IFeature
	{
		// Token: 0x060003BE RID: 958 RVA: 0x000323F4 File Offset: 0x000305F4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\DNSBench.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DNSBench.exe", "", false);
				return;
			}
			Utils.Status("Downloading DNSBenchmark...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852941576379432990/DNSBench.exe"), Utils.AppData + "\\Felipe\\DNSBench.exe");
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00032498 File Offset: 0x00030698
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading DNSBenchmark: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (147KB)");
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000324E9 File Offset: 0x000306E9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DNSBench.exe", "", true);
		}
	}
}
