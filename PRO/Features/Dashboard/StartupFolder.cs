using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000081 RID: 129
	public class StartupFolder : IFeature
	{
		// Token: 0x0600039A RID: 922 RVA: 0x00031ABA File Offset: 0x0002FCBA
		public void Execute()
		{
			Process.Start("shell:startup");
		}
	}
}
