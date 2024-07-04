using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000028 RID: 40
	public class AntiMicro : IFeature
	{
		// Token: 0x06000246 RID: 582 RVA: 0x00028B60 File Offset: 0x00026D60
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\antimicro\\antimicro.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\antimicro\\", "antimicro.exe", "", false);
				return;
			}
			Utils.Status("Downloading AntiMicro...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852919636462272582/antimicro.zip"), Path.GetTempPath() + "\\antimicro.zip");
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00028C04 File Offset: 0x00026E04
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading AntiMicro: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (21.5MB)");
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00028C55 File Offset: 0x00026E55
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("antimicro", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\antimicro\\", "antimicro.exe", "", true);
		}
	}
}
