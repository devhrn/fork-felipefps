using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000046 RID: 70
	public class Freezer : IFeature
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x0002ADB8 File Offset: 0x00028FB8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Freezer_1.1.23.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Freezer_1.1.23.exe", "", false);
				return;
			}
			Utils.Status("Downloading Freezer...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/879340413381672980/Freezer_1.1.23.exe"), Utils.AppData + "\\Felipe\\Freezer_1.1.23.exe");
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0002AE5C File Offset: 0x0002905C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Freezer: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (58.5MB)");
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0002AEAD File Offset: 0x000290AD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Freezer_1.1.23.exe", "", true);
		}
	}
}
