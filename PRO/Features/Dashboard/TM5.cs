using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000083 RID: 131
	public class TM5 : IFeature
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x00031BEC File Offset: 0x0002FDEC
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\TM5\\TM5.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\TM5\\", "TM5.exe", "", false);
				return;
			}
			Utils.Status("Downloading TestMem5 (anta)...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/803560578978545674/TM5.zip"), Path.GetTempPath() + "\\TM5.zip");
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00031C90 File Offset: 0x0002FE90
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading TestMem5 (anta): " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (24KB)");
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00031CE1 File Offset: 0x0002FEE1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("TM5", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\TM5\\", "TM5.exe", "", true);
		}
	}
}
