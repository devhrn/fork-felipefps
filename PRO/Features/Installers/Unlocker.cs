using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000059 RID: 89
	public class Unlocker : IFeature
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0002DFD0 File Offset: 0x0002C1D0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Unlocker.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Unlocker.exe", "", false);
				return;
			}
			Utils.Status("Downloading Unlocker...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/781249189350473758/Unlocker.exe"), Utils.AppData + "\\Felipe\\Unlocker.exe");
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0002E074 File Offset: 0x0002C274
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Unlocker: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (2.4MB)");
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0002E0C5 File Offset: 0x0002C2C5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Unlocker.exe", "", true);
		}
	}
}
