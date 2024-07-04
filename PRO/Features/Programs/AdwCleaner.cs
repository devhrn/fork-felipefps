using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000027 RID: 39
	public class AdwCleaner : IFeature
	{
		// Token: 0x06000242 RID: 578 RVA: 0x00028A48 File Offset: 0x00026C48
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\AdwCleaner.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "AdwCleaner.exe", "", false);
				return;
			}
			Utils.Status("Downloading AdwCleaner...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/795904177581588500/821254311505297442/AdwCleaner.exe"), Utils.AppData + "\\Felipe\\AdwCleaner.exe");
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00028AEC File Offset: 0x00026CEC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading AdwCleaner: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (8.2MB)");
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00028B3D File Offset: 0x00026D3D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "AdwCleaner.exe", "", true);
		}
	}
}
