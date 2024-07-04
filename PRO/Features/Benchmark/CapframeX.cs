using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000088 RID: 136
	public class CapframeX : IFeature
	{
		// Token: 0x060003B4 RID: 948 RVA: 0x000321A0 File Offset: 0x000303A0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\CapFrameX\\CapFrameX.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\CapFrameX\\", "CapFrameX.exe", "", false);
				return;
			}
			Utils.Status("Downloading CapFrameX...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/1258236120354000896/1258237963473784842/CapFrameX.zip?ex=668750eb&is=6685ff6b&hm=def64473ef1fddaa2af6736bf0b638736720da4cf2656273ea3b1a2910cf872c&"), Path.GetTempPath() + "\\CapFrameX.zip");
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00032244 File Offset: 0x00030444
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading CapFrameX: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (83.2MB)");
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00032295 File Offset: 0x00030495
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("CapFrameX", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\CapFrameX\\", "CapFrameX.exe", "", true);
		}
	}
}
