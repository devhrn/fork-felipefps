using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000055 RID: 85
	public class StartIsBack : IFeature
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x0002DB70 File Offset: 0x0002BD70
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\StartIsBack_AiO_1.0.30.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "StartIsBack_AiO_1.0.30.exe", "", false);
				return;
			}
			Utils.Status("Downloading StartIsBack...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/842567917358546954/StartIsBack_AiO_1.0.30.exe"), Utils.AppData + "\\Felipe\\StartIsBack_AiO_1.0.30.exe");
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0002DC14 File Offset: 0x0002BE14
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading StartIsBack: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (4.0MB)");
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0002DC65 File Offset: 0x0002BE65
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "StartIsBack_AiO_1.0.30.exe", "", true);
		}
	}
}
