/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/6
 * Time: 13:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;


namespace AutoFinder
{
	/// <summary>
	/// Description of InterceptKeys.
	/// </summary>
	public class InterceptKeys
	{
		private static IntPtr _hookID = IntPtr.Zero;
		private static LowLevelKeyboardProc _proc = new LowLevelKeyboardProc(InterceptKeys.HookCallback);
		private const int WH_KEYBOARD = 2;
		private const int WH_KEYBOARD_LL = 13;
		private const int WM_GRAB = 0x8888;
		private const int WM_KEYDOWN = 0x100;
		private const int WM_REFRESH = 0x9999;
		private const int WM_SYSKEYDOWN = 260;
		private static StringBuilder sbKeys = new StringBuilder();

		[DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
		[DllImport("User32.dll ")]
		public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr child, string strclass, string strname);
		[DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);
		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if ((nCode >= 0) && (wParam == ((IntPtr) 0x100)))
			{
				Keys keys = (Keys) Marshal.ReadInt32(lParam);
//				File.AppendAllText(@"C:\hot.txt", DateTime.Now.ToString() + ": " + keys.ToString() + "\r\n");
				sbKeys.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "# " + keys.ToString());
				switch (keys)
				{
					case Keys.LControlKey:
						{
							IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, "火眼金睛QQ找茬辅助");
							Message message = Message.Create(hWnd, 0x8888, new IntPtr(0x7b), IntPtr.Zero);
							SendMessage(hWnd, 0x8888, (uint) ((int) message.WParam), (uint) ((int) message.LParam));
							return new IntPtr(1);
						}
					case Keys.Escape:
						{
							IntPtr ptr2 = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, "火眼金睛QQ找茬辅助");
							Message message2 = Message.Create(ptr2, 0x9999, new IntPtr(0x7b), IntPtr.Zero);
							SendMessage(ptr2, 0x9999, (uint) ((int) message2.WParam), (uint) ((int) message2.LParam));
							return new IntPtr(1);
						}
				}
			}
			return CallNextHookEx(_hookID, nCode, wParam, lParam);
		}

		public static void RunHook()
		{
			_hookID = SetHook(_proc);
		}
		
		public static string GetKeysRecord()
		{
			return sbKeys.ToString();
		}

		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);
		private static IntPtr SetHook(LowLevelKeyboardProc proc)
		{
			IntPtr ptr;
			using (Process process = Process.GetCurrentProcess())
			{
				using (ProcessModule module = process.MainModule)
				{
					ptr = SetWindowsHookEx(13, proc, GetModuleHandle(module.ModuleName), 0);
				}
			}
			return ptr;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
		public static void UnHook()
		{
			UnhookWindowsHookEx(_hookID);
		}

		[return: MarshalAs(UnmanagedType.Bool)]
		[DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
	}
}
