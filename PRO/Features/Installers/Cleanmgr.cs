using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200003F RID: 63
	public class Cleanmgr : IFeature
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x0002A600 File Offset: 0x00028800
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Cleanmgr\\cleanmgr.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Cleanmgr\\", "cleanmgr.exe", "", false);
				return;
			}
			Utils.Status("Downloading Cleanmgr...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803623547142275092/cleanmgr.zip"), Path.GetTempPath() + "\\cleanmgr.zip");
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0002A6A4 File Offset: 0x000288A4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Cleanmgr: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (230KB)");
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0002A6F5 File Offset: 0x000288F5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("cleanmgr", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Cleanmgr\\", "cleanmgr.exe", "", true);
		}
	}
}
