using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x02000032 RID: 50
	public class LosslessCut : IFeature
	{
		// Token: 0x0600026E RID: 622 RVA: 0x000296F8 File Offset: 0x000278F8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\LosslessCut\\LosslessCut.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\LosslessCut\\", "LosslessCut.exe", "", false);
				return;
			}
			Utils.Status("Downloading LosslessCut...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://github.com/mifi/lossless-cut/releases/download/v3.38.0/LosslessCut-win.zip"), Path.GetTempPath() + "\\LosslessCut.zip");
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0002979C File Offset: 0x0002799C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading LosslessCut: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (100MB)");
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000297F0 File Offset: 0x000279F0
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			using (ZipArchive zipArchive = ZipFile.OpenRead(Path.GetTempPath() + "\\LosslessCut.zip"))
			{
				foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
				{
					string text = Path.Combine(Utils.AppData + "\\Felipe\\LosslessCut", zipArchiveEntry.FullName);
					string directoryName = Path.GetDirectoryName(text);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					if (!string.IsNullOrEmpty(Path.GetFileName(text)))
					{
						zipArchiveEntry.ExtractToFile(text, true);
					}
				}
			}
			Utils.StartProcess(Utils.AppData + "\\Felipe\\LosslessCut\\", "LosslessCut.exe", "", true);
		}
	}
}
