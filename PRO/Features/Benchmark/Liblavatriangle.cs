using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000094 RID: 148
	public class Liblavatriangle : IFeature
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x00032E08 File Offset: 0x00031008
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Lava\\lava-triangle.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Lava\\", "lava-triangle.exe", "", false);
				return;
			}
			Utils.Status("Downloading lava-triangle...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/840097820349562900/Lava.zip"), Path.GetTempPath() + "\\Lava.zip");
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00032EAC File Offset: 0x000310AC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading lava-triangle: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (3.6MB)");
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00032EFD File Offset: 0x000310FD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Lava", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Lava\\", "lava-triangle.exe", "", true);
		}
	}
}
