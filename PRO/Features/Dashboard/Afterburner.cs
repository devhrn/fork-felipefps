using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000067 RID: 103
	public class Afterburner : IFeature
	{
		// Token: 0x06000338 RID: 824 RVA: 0x0002EDF8 File Offset: 0x0002CFF8
		public void Execute()
		{
			if (File.Exists(Utils.WinDrive + "\\Program Files (x86)\\MSI Afterburner\\MSIAfterburner.exe"))
			{
				Utils.StartProcess(Utils.WinDrive + "\\Program Files (x86)\\MSI Afterburner\\", "MSIAfterburner.exe", "", false);
				return;
			}
			Utils.Status("Downloading MSI Afterburner...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/775317831348125696/775322078453956608/MSIAfterburnerSetup462.exe"), Path.GetTempPath() + "\\MSIAfterburnerSetup462.exe");
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0002EE9C File Offset: 0x0002D09C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading MSI Afterburner: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (26.4MB)");
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0002EEED File Offset: 0x0002D0ED
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Path.GetTempPath() + "\\", "MSIAfterburnerSetup462.exe", "", true);
		}
	}
}
