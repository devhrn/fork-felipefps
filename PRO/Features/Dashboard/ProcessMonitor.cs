using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200007E RID: 126
	public class ProcessMonitor : IFeature
	{
		// Token: 0x0600038E RID: 910 RVA: 0x000316C4 File Offset: 0x0002F8C4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Procmon64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Procmon64.exe", "/AcceptEula", false);
				return;
			}
			Utils.Status("Downloading ProcessMonitor...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/798696171299668028/Procmon64.exe"), Utils.AppData + "\\Felipe\\Procmon64.exe");
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00031768 File Offset: 0x0002F968
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ProcessMonitor: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.1MB)");
		}

		// Token: 0x06000390 RID: 912 RVA: 0x000317B9 File Offset: 0x0002F9B9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Procmon64.exe", "/AcceptEula", true);
		}
	}
}
