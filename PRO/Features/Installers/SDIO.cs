using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000053 RID: 83
	public class SDIO : IFeature
	{
		// Token: 0x060002EC RID: 748 RVA: 0x0002BD30 File Offset: 0x00029F30
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\SDIO\\SDIO_auto.bat"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\SDIO\\", "SDIO_auto.bat", "", false);
				return;
			}
			Utils.Status("Downloading Snappy Driver Installer Origin...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803580542296784917/SDIO.zip"), Path.GetTempPath() + "\\SDIO.zip");
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0002BDD4 File Offset: 0x00029FD4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Snappy Driver Installer Origin: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (69.3MB)");
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0002BE25 File Offset: 0x0002A025
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("SDIO", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\SDIO\\", "SDIO_auto.bat", "", true);
		}
	}
}
