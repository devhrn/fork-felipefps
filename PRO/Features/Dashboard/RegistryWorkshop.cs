using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200007F RID: 127
	public class RegistryWorkshop : IFeature
	{
		// Token: 0x06000392 RID: 914 RVA: 0x000317DC File Offset: 0x0002F9DC
		public void Execute()
		{
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/766680501284241460/783493940875231262/NSudoLC.exe");
			if (!File.Exists(Utils.AppData + "\\Felipe\\RegistryWorkshop\\RegistryWorkshopPortable.exe"))
			{
				Utils.Status("Downloading RegistryWorkshop...");
				WebClient webClient = new WebClient();
				webClient.Headers.Add("User-Agent: Other");
				webClient.DownloadProgressChanged += this.DownloadProgressChanged;
				webClient.DownloadFileCompleted += this.DownloadCompleted;
				webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/807966168819957840/RegistryWorkshop.zip"), Path.GetTempPath() + "\\RegistryWorkshop.zip");
				return;
			}
			if (MessageBox.Show("Run as NSudo?", "NSudo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E %AppData%\\Felipe\\RegistryWorkshop\\RegistryWorkshopPortable.exe", false, false);
				return;
			}
			Utils.StartProcess(Utils.AppData + "\\Felipe\\RegistryWorkshop\\", "RegistryWorkshopPortable.exe", "", false);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000318CC File Offset: 0x0002FACC
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading RegistryWorkshop: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.4MB)");
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00031920 File Offset: 0x0002FB20
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("RegistryWorkshop", false);
			if (MessageBox.Show("Run as NSudo?", "NSudo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E %AppData%\\Felipe\\RegistryWorkshop\\RegistryWorkshopPortable.exe", false, false);
			}
			else
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\RegistryWorkshop\\", "RegistryWorkshopPortable.exe", "", false);
			}
			Utils.ResetStatus();
		}
	}
}
