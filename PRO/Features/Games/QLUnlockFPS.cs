using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000064 RID: 100
	public class QLUnlockFPS : IFeature
	{
		// Token: 0x0600032C RID: 812 RVA: 0x0002EA90 File Offset: 0x0002CC90
		public void Execute()
		{
			MessageBox.Show("This file is safe for playing QuakeLive without bans.\nBut I dont know about other games,\nBefore using please close all games!!!", "Anticheat Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			if (File.Exists(Utils.AppData + "\\Felipe\\QLUnlockFPS\\QuakeLive500FPS.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\QLUnlockFPS\\", "QuakeLive500FPS.exe", "", false);
				return;
			}
			Utils.Status("Downloading QLUnlockFPS...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/855997300048789544/QLUnlockFPS.zip"), Path.GetTempPath() + "\\QLUnlockFPS.zip");
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0002EB48 File Offset: 0x0002CD48
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading QLUnlockFPS: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (127KB)");
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0002EB99 File Offset: 0x0002CD99
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("QLUnlockFPS", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\QLUnlockFPS\\", "QuakeLive500FPS.exe", "", true);
		}
	}
}
