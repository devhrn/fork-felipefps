using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200002F RID: 47
	public class InSpectre : IFeature
	{
		// Token: 0x06000262 RID: 610 RVA: 0x00029398 File Offset: 0x00027598
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\InSpectre.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "InSpectre.exe", "", false);
				return;
			}
			Utils.Status("Downloading InSpectre...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852930420618166292/InSpectre.exe"), Utils.AppData + "\\Felipe\\InSpectre.exe");
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0002943C File Offset: 0x0002763C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading InSpectre: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (125KB)");
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0002948D File Offset: 0x0002768D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "InSpectre.exe", "", true);
		}
	}
}
