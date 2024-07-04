using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000010 RID: 16
	public class EasyGRUB : IFeature
	{
		// Token: 0x06000207 RID: 519 RVA: 0x0001BB94 File Offset: 0x00019D94
		public void Execute()
		{
			if (File.Exists(Utils.Desktop + "\\EasyGRUB\\SCEWIN_64.exe"))
			{
				MessageBox.Show(string.Concat(new string[]
				{
					"EasyGRUB files now located in ",
					Utils.Desktop,
					Environment.NewLine,
					Environment.NewLine,
					"Export.bat to write BIOSSettings.txt",
					Environment.NewLine,
					Environment.NewLine,
					"Edit settings in BIOSSettings.txt",
					Environment.NewLine,
					Environment.NewLine,
					"Import.bat to save and reboot PC",
					Environment.NewLine,
					Environment.NewLine,
					"Im not responsible for any problem!"
				}), "EasyGRUB Guide", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Process.Start("explorer.exe", Utils.Desktop + "\\EasyGRUB");
				return;
			}
			Utils.Status("Downloading EasyGRUB...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/856588375230251059/EasyGRUB.zip"), Path.GetTempPath() + "\\EasyGRUB.zip");
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0001BCC8 File Offset: 0x00019EC8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading EasyGRUB: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (200KB)");
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0001BD1C File Offset: 0x00019F1C
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZipDesktop("EasyGRUB", false);
			MessageBox.Show(string.Concat(new string[]
			{
				"EasyGRUB files now located in ",
				Utils.Desktop,
				Environment.NewLine,
				Environment.NewLine,
				"Export.bat to write BIOSSettings.txt",
				Environment.NewLine,
				Environment.NewLine,
				"Edit settings in BIOSSettings.txt",
				Environment.NewLine,
				Environment.NewLine,
				"Import.bat to save and reboot PC",
				Environment.NewLine,
				Environment.NewLine,
				"Im not responsible for any problem!"
			}), "EasyGRUB Guide", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Process.Start("explorer.exe", Utils.Desktop + "\\EasyGRUB");
			Utils.ResetStatus();
		}
	}
}
