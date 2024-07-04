using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000041 RID: 65
	public class DirectX : IFeature
	{
		// Token: 0x060002A8 RID: 680 RVA: 0x0002A878 File Offset: 0x00028A78
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\DirectX\\DXSETUP.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\DirectX\\", "DXSETUP.exe", "", false);
				return;
			}
			Utils.Status("Downloading DirectX...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803518976310378496/DIRECTX.zip"), Path.GetTempPath() + "\\DIRECTX.zip");
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0002A91C File Offset: 0x00028B1C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading DirectX: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (96MB)");
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0002A96D File Offset: 0x00028B6D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("DIRECTX", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\DirectX\\", "DXSETUP.exe", "", true);
		}
	}
}
