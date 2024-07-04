using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200008C RID: 140
	public class FrameView : IFeature
	{
		// Token: 0x060003C2 RID: 962 RVA: 0x0003250C File Offset: 0x0003070C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\FrameView\\FrameViewSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\FrameView\\", "FrameViewSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading FrameView...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852948818282807366/FrameView.zip"), Path.GetTempPath() + "\\FrameView.zip");
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000325B0 File Offset: 0x000307B0
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading FrameView: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (59.6MB)");
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00032601 File Offset: 0x00030801
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("FrameView", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\FrameView\\", "FrameViewSetup.exe", "", true);
		}
	}
}
