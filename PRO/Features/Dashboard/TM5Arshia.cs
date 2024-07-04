using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000084 RID: 132
	public class TM5Arshia : IFeature
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x00031D10 File Offset: 0x0002FF10
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\TM5Arshia\\TM5.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\TM5Arshia\\", "TM5.exe", "", false);
				return;
			}
			Utils.Status("Downloading TestMem5 (Arshia)...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/880635486228582420/TM5Arshia.zip"), Path.GetTempPath() + "\\TM5Arshia.zip");
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00031DB4 File Offset: 0x0002FFB4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading TestMem5 (Arshia): " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (24KB)");
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00031E05 File Offset: 0x00030005
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("TM5Arshia", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\TM5Arshia\\", "TM5.exe", "", true);
		}
	}
}
