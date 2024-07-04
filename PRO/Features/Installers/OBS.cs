using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200004F RID: 79
	public class OBS : IFeature
	{
		// Token: 0x060002DC RID: 732 RVA: 0x0002B8D0 File Offset: 0x00029AD0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\OBS-Studio-27.0.1-Full-Installer-x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OBS-Studio-27.0.1-Full-Installer-x64.exe", "", false);
				return;
			}
			Utils.Status("Downloading OBS...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/879340661738971187/OBS-Studio-27.0.1-Full-Installer-x64.exe"), Utils.AppData + "\\Felipe\\OBS-Studio-27.0.1-Full-Installer-x64.exe");
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0002B974 File Offset: 0x00029B74
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading OBS: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (85.7MB)");
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0002B9C5 File Offset: 0x00029BC5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OBS-Studio-27.0.1-Full-Installer-x64.exe", "", true);
		}
	}
}
