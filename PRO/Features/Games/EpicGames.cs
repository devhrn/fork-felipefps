using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000060 RID: 96
	public class EpicGames : IFeature
	{
		// Token: 0x0600031E RID: 798 RVA: 0x0002E6BC File Offset: 0x0002C8BC
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\EpicInstaller.msi"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "EpicInstaller.msi", "", false);
				return;
			}
			Utils.Status("Downloading EpicGames...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi"), Utils.AppData + "\\Felipe\\EpicInstaller.msi");
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0002E760 File Offset: 0x0002C960
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading EpicGames: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (54.1MB)");
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0002E7B1 File Offset: 0x0002C9B1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "EpicInstaller.msi", "", true);
		}
	}
}
