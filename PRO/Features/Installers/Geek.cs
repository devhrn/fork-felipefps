using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000047 RID: 71
	public class Geek : IFeature
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0002AED0 File Offset: 0x000290D0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\geek.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "geek.exe", "", false);
				return;
			}
			Utils.Status("Downloading Geek...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/878974290438000640/geek.exe"), Utils.AppData + "\\Felipe\\geek.exe");
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0002AF74 File Offset: 0x00029174
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Geek: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (6.1MB)");
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0002AFC5 File Offset: 0x000291C5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "geek.exe", "", true);
		}
	}
}
