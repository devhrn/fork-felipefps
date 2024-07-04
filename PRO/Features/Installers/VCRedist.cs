using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200005A RID: 90
	public class VCRedist : IFeature
	{
		// Token: 0x06000308 RID: 776 RVA: 0x0002E0E8 File Offset: 0x0002C2E8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\VisualCppRedist_AIO_x86_x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "VisualCppRedist_AIO_x86_x64.exe", "", false);
				return;
			}
			Utils.Status("Downloading VCRedist...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/825011760847257660/VisualCppRedist_AIO_x86_x64.exe"), Utils.AppData + "\\Felipe\\VisualCppRedist_AIO_x86_x64.exe");
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0002E18C File Offset: 0x0002C38C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading VCRedist: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (28.4MB)");
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0002E1DD File Offset: 0x0002C3DD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "VisualCppRedist_AIO_x86_x64.exe", "", true);
		}
	}
}
