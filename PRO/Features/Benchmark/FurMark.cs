using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200008E RID: 142
	public class FurMark : IFeature
	{
		// Token: 0x060003CA RID: 970 RVA: 0x00032754 File Offset: 0x00030954
		public void Execute()
		{
			if (File.Exists(Utils.ProgramFilesX86 + "\\Geeks3D\\Benchmarks\\FurMark\\FurMark.exe"))
			{
				Utils.StartProcess(Utils.ProgramFilesX86 + "\\Geeks3D\\Benchmarks\\FurMark\\", "FurMark.exe", "", false);
				return;
			}
			Utils.Status("Downloading FurMark...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/825030108028076042/FurMark_1.25.1.0_Setup.exe"), Path.GetTempPath() + "\\FurMark_1.25.1.0_Setup.exe");
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000327F8 File Offset: 0x000309F8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading FurMark: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (12.1MB)");
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00032849 File Offset: 0x00030A49
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Path.GetTempPath(), "\\FurMark_1.25.1.0_Setup.exe", "", true);
		}
	}
}
