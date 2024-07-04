using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200003E RID: 62
	public class Wooting : IFeature
	{
		// Token: 0x0600029C RID: 668 RVA: 0x0002A4E8 File Offset: 0x000286E8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\wooting-double-movement-Setup-1.3.1.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "wooting-double-movement-Setup-1.3.1.exe", "", false);
				return;
			}
			Utils.Status("Downloading Wooting Double Movement...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852934079124996149/wooting-double-movement-Setup-1.3.1.exe"), Utils.AppData + "\\Felipe\\wooting-double-movement-Setup-1.3.1.exe");
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0002A58C File Offset: 0x0002878C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Wooting Double Movement: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (60.1MB)");
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0002A5DD File Offset: 0x000287DD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "wooting-double-movement-Setup-1.3.1.exe", "", true);
		}
	}
}
