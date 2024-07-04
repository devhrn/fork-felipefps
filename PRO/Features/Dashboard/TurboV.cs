using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000085 RID: 133
	public class TurboV : IFeature
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x00031E34 File Offset: 0x00030034
		public void Execute()
		{
			if (File.Exists(Utils.WinDrive + "\\Program Files (x86)\\ASUS\\TurboV Core\\TurboV_Core.exe"))
			{
				Utils.StartProcess(Utils.WinDrive + "\\Program Files (x86)\\ASUS\\TurboV Core\\", "TurboV_Core.exe", "", false);
				return;
			}
			Utils.Status("Downloading TurboV Core...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/857523025011277824/858816668158787604/TurboV.zip"), Path.GetTempPath() + "\\TurboV.zip");
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00031ED8 File Offset: 0x000300D8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading TurboV Core: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (14.1MB)");
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00031F29 File Offset: 0x00030129
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("TurboV", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\TurboV\\", "Setup.exe", "", true);
		}
	}
}
