using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000078 RID: 120
	public class OCCT : IFeature
	{
		// Token: 0x06000378 RID: 888 RVA: 0x000301D4 File Offset: 0x0002E3D4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\OCCT.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OCCT.exe", "", false);
				return;
			}
			Utils.Status("Downloading OCCT...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/862552157604413440/OCCT.exe"), Utils.AppData + "\\Felipe\\OCCT.exe");
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00030278 File Offset: 0x0002E478
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading OCCT: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (18.1MB)");
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000302C9 File Offset: 0x0002E4C9
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OCCT.exe", "", true);
		}
	}
}
