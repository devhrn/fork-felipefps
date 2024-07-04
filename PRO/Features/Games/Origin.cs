using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000062 RID: 98
	public class Origin : IFeature
	{
		// Token: 0x06000326 RID: 806 RVA: 0x0002E8F8 File Offset: 0x0002CAF8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\OriginThinSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OriginThinSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Origin...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://www.dm.origin.com/download"), Utils.AppData + "\\Felipe\\OriginThinSetup.exe");
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0002E99C File Offset: 0x0002CB9C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Origin: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (62.1MB)");
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0002E9ED File Offset: 0x0002CBED
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OriginThinSetup.exe", "", true);
		}
	}
}
