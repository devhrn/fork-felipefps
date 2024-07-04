using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000017 RID: 23
	public class PCIUtil : IFeature
	{
		// Token: 0x06000217 RID: 535 RVA: 0x0001D154 File Offset: 0x0001B354
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\PCIutil.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "PCIutil.exe", "", false);
				return;
			}
			Utils.Status("Downloading PCIutil...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/854604806127747072/PCIutil.exe"), Utils.AppData + "\\Felipe\\PCIutil.exe");
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading PCIutil: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (10.7MB)");
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0001D249 File Offset: 0x0001B449
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "PCIutil.exe", "", true);
		}
	}
}
