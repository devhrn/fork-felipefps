using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200004B RID: 75
	public class NET35 : IFeature
	{
		// Token: 0x060002CC RID: 716 RVA: 0x0002B430 File Offset: 0x00029630
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\dotNetFx35.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "dotNetFx35.exe", "", false);
				return;
			}
			Utils.Status("Downloading dotNetFx35...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/840699312769466378/dotNetFx35.exe"), Utils.AppData + "\\Felipe\\dotNetFx35.exe");
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0002B4D4 File Offset: 0x000296D4
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading dotNetFx35: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (46.2MB)");
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0002B525 File Offset: 0x00029725
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "dotNetFx35.exe", "", true);
		}
	}
}
