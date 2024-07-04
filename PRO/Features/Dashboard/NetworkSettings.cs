using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000076 RID: 118
	public class NetworkSettings : IFeature
	{
		// Token: 0x06000372 RID: 882 RVA: 0x000300AC File Offset: 0x0002E2AC
		public void Execute()
		{
			Process.Start("ncpa.cpl");
		}
	}
}
