using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200007A RID: 122
	public class Prime95 : IFeature
	{
		// Token: 0x0600037E RID: 894 RVA: 0x000302F8 File Offset: 0x0002E4F8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Prime95\\prime95.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Prime95\\", "prime95.exe", "", false);
				return;
			}
			Utils.Status("Downloading Prime95...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/876422189459578890/Prime95.zip"), Path.GetTempPath() + "\\Prime95.zip");
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0003039C File Offset: 0x0002E59C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Prime95: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (10.05MB)");
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000303ED File Offset: 0x0002E5ED
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Prime95", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Prime95\\", "prime95.exe", "", true);
		}
	}
}
