using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000052 RID: 82
	public class Rufus : IFeature
	{
		// Token: 0x060002E8 RID: 744 RVA: 0x0002BC18 File Offset: 0x00029E18
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\rufus-3.15p.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "rufus-3.15p.exe", "", false);
				return;
			}
			Utils.Status("Downloading Rufus...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/879341244743036988/rufus-3.15p.exe"), Utils.AppData + "\\Felipe\\rufus-3.15p.exe");
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0002BCBC File Offset: 0x00029EBC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Rufus: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.1MB)");
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0002BD0D File Offset: 0x00029F0D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "rufus-3.15p.exe", "", true);
		}
	}
}
