using System;
using System.Runtime.InteropServices;

namespace Injecter
{
    internal class NativeMethods
    {
        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SetWindowsHookEx(int idHook, Injecter.HookProc lpfn, IntPtr hmod, int dwThreadId);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int CallNextHookEx(int hhk, int nCode, int wParam, IntPtr lParam);
    }
}
