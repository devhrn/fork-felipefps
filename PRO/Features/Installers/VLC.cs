using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200005D RID: 93
	public class VLC : IFeature
	{
		// Token: 0x06000314 RID: 788 RVA: 0x0002E43C File Offset: 0x0002C63C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\vlc-3.0.11-win64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "vlc-3.0.11-win64.exe", "", false);
				return;
			}
			Utils.Status("Downloading VLC...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/775249129177743370/782392009188179998/vlc-3.0.11-win64.exe"), Utils.AppData + "\\Felipe\\vlc-3.0.11-win64.exe");
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0002E4E0 File Offset: 0x0002C6E0
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading VLC: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (40.8MB)");
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0002E531 File Offset: 0x0002C731
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "vlc-3.0.11-win64.exe", "", true);
		}
	}
}
