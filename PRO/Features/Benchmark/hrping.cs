using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000090 RID: 144
	public class hrping : IFeature
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x00032984 File Offset: 0x00030B84
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\hrping.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "hrping.exe", "", false);
				return;
			}
			Utils.Status("Downloading hrping...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852950459383808060/hrping.exe"), Utils.AppData + "\\Felipe\\hrping.exe");
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00032A28 File Offset: 0x00030C28
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading hrping: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (450KB)");
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00032A79 File Offset: 0x00030C79
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "hrping.exe", "", true);
		}
	}
}
