using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000051 RID: 81
	public class qBitTorrent : IFeature
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x0002BB00 File Offset: 0x00029D00
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\qbittorrent_4.3.4.1_setup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "qbittorrent_4.3.4.1_setup.exe", "", false);
				return;
			}
			Utils.Status("Downloading qBitTorrent...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/857061303033004042/qbittorrent_4.3.4.1_setup.exe"), Utils.AppData + "\\Felipe\\qbittorrent_4.3.4.1_setup.exe");
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0002BBA4 File Offset: 0x00029DA4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading qBitTorrent: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (23.0MB)");
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0002BBF5 File Offset: 0x00029DF5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "qbittorrent_4.3.4.1_setup.exe", "", true);
		}
	}
}
