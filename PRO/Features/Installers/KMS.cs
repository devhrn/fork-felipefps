using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000049 RID: 73
	public class KMS : IFeature
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x0002B200 File Offset: 0x00029400
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\KMS_VL_ALL_AIO.cmd"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "KMS_VL_ALL_AIO.cmd", "", false);
				return;
			}
			Utils.Status("Downloading KMS_VL_ALL_AIO...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/801731177362227200/KMS_VL_ALL_AIO.cmd"), Utils.AppData + "\\Felipe\\KMS_VL_ALL_AIO.cmd");
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0002B2A4 File Offset: 0x000294A4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading KMS_VL_ALL_AIO: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (233KB)");
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0002B2F5 File Offset: 0x000294F5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "KMS_VL_ALL_AIO.cmd", "", true);
		}
	}
}
