using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000035 RID: 53
	public class OverdriveNTool : IFeature
	{
		// Token: 0x06000278 RID: 632 RVA: 0x00029AEC File Offset: 0x00027CEC
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\OverdriveNTool.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OverdriveNTool.exe", "", false);
				return;
			}
			Utils.Status("Downloading OverdriveNTool...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/1258236120354000896/1258239039467683840/OverdriveNTool.exe?ex=668751eb&is=6686006b&hm=72225d846b347631d74c77690436de61c2609d3b479839bdec8c1428d33e43a6&"), Utils.AppData + "\\Felipe\\OverdriveNTool.exe");
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00029B90 File Offset: 0x00027D90
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading OverdriveNTool: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (112KB)");
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00029BE1 File Offset: 0x00027DE1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OverdriveNTool.exe", "", true);
		}
	}
}
