using System;
using System.Runtime.InteropServices;

namespace Injecter
{
    public class Hooker : IDisposable
    {
        private int hHook = 0;
        private HookProc hProc;

        public Hooker(HookProc hProc)
        {
            this.hProc = hProc;
        }

        public void SetWindowsHook(HookTypes idHook)
        {
            if (hHook == 0)
            {
                hHook = NativeMethods.SetWindowsHookEx((int)idHook, hProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
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
