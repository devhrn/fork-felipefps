using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x0200005F RID: 95
	public class Battlenet : IFeature
	{
		// Token: 0x0600031A RID: 794 RVA: 0x0002E5A4 File Offset: 0x0002C7A4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\BattlenetSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "BattlenetSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Battle.net...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/855996125613654076/BattlenetSetup.exe"), Utils.AppData + "\\Felipe\\BattlenetSetup.exe");
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0002E648 File Offset: 0x0002C848
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Battle.net: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (4.61MB)");
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0002E699 File Offset: 0x0002C899
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "BattlenetSetup.exe", "", true);
		}
	}
}
