using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200009B RID: 155
	public class RivaTuner : IFeature
	{
		// Token: 0x060003FE RID: 1022 RVA: 0x000335E0 File Offset: 0x000317E0
		public void Execute()
		{
			if (File.Exists(Utils.WinDrive + "\\Program Files (x86)\\RivaTuner Statistics Server\\RTSS.exe"))
			{
				Utils.StartProcess(Utils.WinDrive + "\\Program Files (x86)\\RivaTuner Statistics Server\\", "RTSS.exe", "", false);
				return;
			}
			Utils.Status("Downloading RivaTuner...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/844099902606802944/RTSSSetup731.exe"), Path.GetTempPath() + "\\RTSSSetup731.exe");
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00033684 File Offset: 0x00031884
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading RivaTuner: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (23.0MB)");
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000336D5 File Offset: 0x000318D5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Path.GetTempPath(), "\\RTSSSetup731.exe", "", true);
		}
	}
}
