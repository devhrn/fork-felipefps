using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000050 RID: 80
	public class OpenShell : IFeature
	{
		// Token: 0x060002E0 RID: 736 RVA: 0x0002B9E8 File Offset: 0x00029BE8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\OpenShellSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OpenShellSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading OpenShell...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/842608945557536778/OpenShellSetup.exe"), Utils.AppData + "\\Felipe\\OpenShellSetup.exe");
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0002BA8C File Offset: 0x00029C8C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading OpenShell: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (7.2MB)");
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0002BADD File Offset: 0x00029CDD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "OpenShellSetup.exe", "", true);
		}
	}
}
