using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000073 RID: 115
	public class LinpackExtended : IFeature
	{
		// Token: 0x06000366 RID: 870 RVA: 0x0002FD4C File Offset: 0x0002DF4C
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Linpack Extended\\Linpack Extended.bat"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Linpack Extended\\", "Linpack Extended.bat", "", false);
				return;
			}
			Utils.Status("Downloading Linpack-Extended...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/881336225171140628/Linpack_Extended.zip"), Path.GetTempPath() + "\\Linpack Extended.zip");
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0002FDF0 File Offset: 0x0002DFF0
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Linpack-Extended: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (29.0MB)");
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0002FE41 File Offset: 0x0002E041
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("Linpack Extended", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\Linpack Extended\\", "Linpack Extended.bat", "", true);
		}
	}
}
