using System;
using System.Runtime.InteropServices;

namespace Injector
{
    public class Hooker : IDisposable
    {
        private int hHook = 0;
        private HookProc hProc;
        private IntPtr hmod;

        public Hooker(HookProc hProc)
            : this(hProc, IntPtr.Zero)
        { }

        public Hooker(HookProc hProc, IntPtr hmod)
        {
            this.hProc = hProc;
            this.hmod = hmod;
        }

        public void SetWindowsHook(HookTypes idHook)
        {
            if (hHook == 0)
            {
                hHook = NativeMethods.SetWindowsHookEx((int)idHook, hProc, IntPtr.Zero, NativeMethods.GetCurrentThreadId());
                if (hHook == 0)
                {
                    throw new Exception("Set Hook Failed!");
                }
            }
        }

        public void SetGlobalHook(HookTypes idHook)
        {
            if (hHook == 0 && hmod != IntPtr.Zero)
            {
                hHook = NativeMethods.SetWindowsHookEx((int)idHook, hProc, hmod, 0);
                if (hHook == 0)
                {
                    throw new Exception("Set Hook Failed!");
                }
            }
        }

        public int CallNextHook(int nCode, int wParam, IntPtr lParam)
        {
            return NativeMethods.CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        public void Dispose()
        {
            bool ret = NativeMethods.UnhookWindowsHookEx(hHook);
            if (!ret)
            {
                throw new Exception("UnHook Failed!");
            }
            else
            {
                hHook = 0;
            }
        }
    }
}
