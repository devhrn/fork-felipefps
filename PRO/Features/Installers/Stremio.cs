using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000057 RID: 87
	public class Stremio : IFeature
	{
		// Token: 0x060002FC RID: 764 RVA: 0x0002DDA0 File Offset: 0x0002BFA0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\StremioInstaller.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "StremioInstaller.exe", "", false);
				return;
			}
			Utils.Status("Downloading Stremio...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://www.strem.io/download?platform=windows&four=true"), Utils.AppData + "\\Felipe\\StremioInstaller.exe");
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0002DE44 File Offset: 0x0002C044
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Stremio: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (105MB)");
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0002DE95 File Offset: 0x0002C095
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "StremioInstaller.exe", "", true);
		}
	}
}
