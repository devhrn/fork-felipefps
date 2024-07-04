using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200009F RID: 159
	public class WPA : IFeature
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x00033928 File Offset: 0x00031B28
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\adksetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "adksetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Windows ADK...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/866319322586546176/adksetup.exe"), Utils.AppData + "\\Felipe\\adksetup.exe");
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000339CC File Offset: 0x00031BCC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Windows ADK: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (2.08MB)");
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00033A1D File Offset: 0x00031C1D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "adksetup.exe", "", true);
		}
	}
}
