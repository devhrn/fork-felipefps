using System;
using System.Net;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000063 RID: 99
	public class QLConfig : IFeature
	{
		// Token: 0x0600032A RID: 810 RVA: 0x0002EA10 File Offset: 0x0002CC10
		public void Execute()
		{
			new WebClient
			{
				Headers = 
				{
					"User-Agent: Other"
				}
			}.DownloadFile("https://cdn.discordapp.com/attachments/762398293686485024/879342789463265350/fayeQL.cfg", Utils.Desktop + "\\fayeQL.cfg");
			new WebClient
			{
				Headers = 
				{
					"User-Agent: Other"
				}
			}.DownloadFile("https://cdn.discordapp.com/attachments/762398293686485024/879342801215717416/felipeQL.cfg", Utils.Desktop + "\\felipeQL.cfg");
			MessageBox.Show("Downloaded fayeQL.cfg and felipeQL.cfg to " + Utils.Desktop);
		}
	}
}
