using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200006C RID: 108
	public class CPUZ : IFeature
	{
		// Token: 0x0600034C RID: 844 RVA: 0x0002F520 File Offset: 0x0002D720
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\CPUZ\\cpuz_x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\CPUZ\\", "cpuz_x64.exe", "", false);
				return;
			}
			Utils.Status("Downloading CPUZ...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/862552700155723776/CPUZ.zip"), Path.GetTempPath() + "\\CPUZ.zip");
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0002F5C4 File Offset: 0x0002D7C4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading CPUZ: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.63MB)");
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0002F615 File Offset: 0x0002D815
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("CPUZ", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\CPUZ\\", "cpuz_x64.exe", "", true);
		}
	}
}
