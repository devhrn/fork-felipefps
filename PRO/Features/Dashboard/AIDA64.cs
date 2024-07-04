using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000068 RID: 104
	public class AIDA64 : IFeature
	{
		// Token: 0x0600033C RID: 828 RVA: 0x0002EF10 File Offset: 0x0002D110
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\AIDA64\\aida64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\AIDA64\\", "aida64.exe", "", false);
				return;
			}
			Utils.Status("Downloading AIDA64...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/864762620925313034/AIDA64.zip"), Path.GetTempPath() + "\\AIDA64.zip");
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0002EFB4 File Offset: 0x0002D1B4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading AIDA64: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (18.3MB)");
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0002F005 File Offset: 0x0002D205
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("AIDA64", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\AIDA64\\", "aida64.exe", "", true);
		}
	}
}
