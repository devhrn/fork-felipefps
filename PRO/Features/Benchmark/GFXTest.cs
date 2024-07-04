using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200008F RID: 143
	public class GFXTest : IFeature
	{
		// Token: 0x060003CE RID: 974 RVA: 0x00032860 File Offset: 0x00030A60
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\GFXTest\\GFXTest64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\GFXTest\\", "GFXTest64.exe", "", false);
				return;
			}
			Utils.Status("Downloading GFXTest...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839296694272393276/GFXTest.zip"), Path.GetTempPath() + "\\GFXTest.zip");
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00032904 File Offset: 0x00030B04
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading GFXTest: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (59.6MB)");
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00032955 File Offset: 0x00030B55
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("GFXTest", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\GFXTest\\", "GFXTest64.exe", "", true);
		}
	}
}
