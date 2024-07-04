using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200005C RID: 92
	public class VisualStudio : IFeature
	{
		// Token: 0x06000310 RID: 784 RVA: 0x0002E324 File Offset: 0x0002C524
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\vs_Community.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "vs_Community.exe", "", false);
				return;
			}
			Utils.Status("Downloading VisualStudio...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/827961965891682344/vs_Community.exe"), Utils.AppData + "\\Felipe\\vs_Community.exe");
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0002E3C8 File Offset: 0x0002C5C8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading VisualStudio: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.4MB)");
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0002E419 File Offset: 0x0002C619
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "vs_Community.exe", "", true);
		}
	}
}
