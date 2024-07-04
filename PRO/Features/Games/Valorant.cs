using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000066 RID: 102
	public class Valorant : IFeature
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0002ECE0 File Offset: 0x0002CEE0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\VALORANT.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "VALORANT.exe", "", false);
				return;
			}
			Utils.Status("Downloading VALORANT...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/855992825735675914/VALORANT.exe"), Utils.AppData + "\\Felipe\\VALORANT.exe");
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0002ED84 File Offset: 0x0002CF84
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading VALORANT: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (65.8MB)");
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0002EDD5 File Offset: 0x0002CFD5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "VALORANT.exe", "", true);
		}
	}
}
