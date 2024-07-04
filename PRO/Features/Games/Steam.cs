using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000065 RID: 101
	public class Steam : IFeature
	{
		// Token: 0x06000330 RID: 816 RVA: 0x0002EBC8 File Offset: 0x0002CDC8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\SteamSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "SteamSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Steam...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe"), Utils.AppData + "\\Felipe\\SteamSetup.exe");
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0002EC6C File Offset: 0x0002CE6C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Steam: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.69MB)");
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0002ECBD File Offset: 0x0002CEBD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "SteamSetup.exe", "", true);
		}
	}
}
