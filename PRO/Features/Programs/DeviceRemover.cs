using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200002B RID: 43
	public class DeviceRemover : IFeature
	{
		// Token: 0x06000252 RID: 594 RVA: 0x00028EC0 File Offset: 0x000270C0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Device Remover\\DeviceRemover.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Device Remover\\", "DeviceRemover.exe", "", false);
				return;
			}
			Utils.Status("Downloading Device Remover...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852922536806711346/Device_Remover.zip"), Path.GetTempPath() + "\\DeviceRemover.zip");
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00028F64 File Offset: 0x00027164
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Device Remover: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (5.9MB)");
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00028FB5 File Offset: 0x000271B5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("DeviceRemover", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Device Remover\\", "DeviceRemover.exe", "", true);
		}
	}
}
