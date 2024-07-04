using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000074 RID: 116
	public class LinX : IFeature
	{
		// Token: 0x0600036A RID: 874 RVA: 0x0002FE70 File Offset: 0x0002E070
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\LinX\\LinX.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\LinX\\", "LinX.exe", "", false);
				return;
			}
			Utils.Status("Downloading LinX...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/856271440793829426/LinX.zip"), Path.GetTempPath() + "\\LinX.zip");
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0002FF14 File Offset: 0x0002E114
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading LinX: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (3.37MB)");
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0002FF65 File Offset: 0x0002E165
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("LinX", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\LinX\\", "LinX.exe", "", true);
		}
	}
}
