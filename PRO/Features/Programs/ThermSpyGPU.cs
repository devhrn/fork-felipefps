using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000039 RID: 57
	public class ThermSpyGPU : IFeature
	{
		// Token: 0x06000288 RID: 648 RVA: 0x00029F64 File Offset: 0x00028164
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\ThermSpyGPU.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "ThermSpyGPU.exe", "", false);
				return;
			}
			Utils.Status("Downloading ThermSpyGPU...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/773065487990784021/773092500113063966/ThermSpyGPU.exe"), Utils.AppData + "\\Felipe\\ThermSpyGPU.exe");
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0002A008 File Offset: 0x00028208
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ThermSpyGPU: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (679KB)");
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0002A059 File Offset: 0x00028259
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "ThermSpyGPU.exe", "", true);
		}
	}
}
