using System;
using System.Net;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x0200005E RID: 94
	public class ApexConfig : IFeature
	{
		// Token: 0x06000318 RID: 792 RVA: 0x0002E554 File Offset: 0x0002C754
		public void Execute()
		{
			new WebClient
			{
				Headers = 
				{
					"User-Agent: Other"
				}
			}.DownloadFile("https://cdn.discordapp.com/attachments/762398293686485024/879343405262594098/autoexec.cfg", Utils.Desktop + "\\autoexec.cfg");
			MessageBox.Show("Downloaded autoexec.cfg to " + Utils.Desktop);
		}
	}
}
