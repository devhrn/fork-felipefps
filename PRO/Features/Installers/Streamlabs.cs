using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000056 RID: 86
	public class Streamlabs : IFeature
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0002DC88 File Offset: 0x0002BE88
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\StreamlabsSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "StreamlabsSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Streamlabs...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://streamlabs.com/slobs/download"), Utils.AppData + "\\Felipe\\StreamlabsSetup.exe");
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0002DD2C File Offset: 0x0002BF2C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Streamlabs: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (187.4MB)");
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0002DD7D File Offset: 0x0002BF7D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "StreamlabsSetup.exe", "", true);
		}
	}
}
