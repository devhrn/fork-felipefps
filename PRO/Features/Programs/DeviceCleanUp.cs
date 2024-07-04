using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200002A RID: 42
	public class DeviceCleanUp : IFeature
	{
		// Token: 0x0600024E RID: 590 RVA: 0x00028DA8 File Offset: 0x00026FA8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\DeviceCleanup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DeviceCleanup.exe", "", false);
				return;
			}
			Utils.Status("Downloading DeviceCleanup...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852921523094552606/DeviceCleanup.exe"), Utils.AppData + "\\Felipe\\DeviceCleanup.exe");
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00028E4C File Offset: 0x0002704C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading DeviceCleanup: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (62KB)");
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00028E9D File Offset: 0x0002709D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "DeviceCleanup.exe", "", true);
		}
	}
}
