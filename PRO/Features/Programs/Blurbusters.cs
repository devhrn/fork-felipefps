using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000029 RID: 41
	public class Blurbusters : IFeature
	{
		// Token: 0x0600024A RID: 586 RVA: 0x00028C84 File Offset: 0x00026E84
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\BBSU\\BlurBustersStrobeUtility.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\BBSU\\", "BlurBustersStrobeUtility.exe", "", false);
				return;
			}
			Utils.Status("Downloading Blurbusters...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/840700629026603048/BBSU.zip"), Path.GetTempPath() + "\\BBSU.zip");
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00028D28 File Offset: 0x00026F28
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Blurbusters: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.4MB)");
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00028D79 File Offset: 0x00026F79
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("BBSU", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\BBSU\\", "BlurBustersStrobeUtility.exe", "", true);
		}
	}
}
