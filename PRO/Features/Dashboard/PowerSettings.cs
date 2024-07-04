using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000079 RID: 121
	public class PowerSettings : IFeature
	{
		// Token: 0x0600037C RID: 892 RVA: 0x000302EA File Offset: 0x0002E4EA
		public void Execute()
		{
			Process.Start("powercfg.cpl");
		}
	}
}
