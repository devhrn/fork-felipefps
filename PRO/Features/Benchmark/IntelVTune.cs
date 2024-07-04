using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000091 RID: 145
	public class IntelVTune : IFeature
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x00032A9C File Offset: 0x00030C9C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\w_BaseKit_p_2021.3.0.3221.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "w_BaseKit_p_2021.3.0.3221.exe", "", false);
				return;
			}
			Utils.Status("Downloading Intel VTune Profile...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/778313621188378655/863800489024159754/w_BaseKit_p_2021.3.0.3221.exe"), Utils.AppData + "\\Felipe\\w_BaseKit_p_2021.3.0.3221.exe");
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00032B40 File Offset: 0x00030D40
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Intel VTune Profile: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (16.4MB)");
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00032B91 File Offset: 0x00030D91
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "w_BaseKit_p_2021.3.0.3221.exe", "", true);
		}
	}
}
