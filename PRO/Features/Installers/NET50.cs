using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200004C RID: 76
	public class NET50 : IFeature
	{
		// Token: 0x060002D0 RID: 720 RVA: 0x0002B548 File Offset: 0x00029748
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\windowsdesktop-runtime-5.0.8-win-x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "windowsdesktop-runtime-5.0.8-win-x64.exe", "", false);
				return;
			}
			Utils.Status("Downloading .NET 5.0 Runtime...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/865157604758126622/windowsdesktop-runtime-5.0.8-win-x64.exe"), Utils.AppData + "\\Felipe\\windowsdesktop-runtime-5.0.8-win-x64.exe");
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0002B5EC File Offset: 0x000297EC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading .NET 5.0 Runtime: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (52.3MB)");
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0002B63D File Offset: 0x0002983D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "windowsdesktop-runtime-5.0.8-win-x64.exe", "", true);
		}
	}
}
