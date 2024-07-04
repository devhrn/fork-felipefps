using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200006F RID: 111
	public class Firestarter : IFeature
	{
		// Token: 0x06000356 RID: 854 RVA: 0x0002F888 File Offset: 0x0002DA88
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\FIRESTARTER-windows.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "FIRESTARTER-windows.exe", "-r -i 22 --set-line-count 4096", false);
				return;
			}
			Utils.Status("Downloading Firestarter...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/857640468502151188/FIRESTARTER-windows.exe"), Utils.AppData + "\\Felipe\\FIRESTARTER-windows.exe");
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0002F92C File Offset: 0x0002DB2C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Firestarter: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.72MB)");
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0002F97D File Offset: 0x0002DB7D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "FIRESTARTER-windows.exe", "-r -i 22 --set-line-count 4096", true);
		}
	}
}
