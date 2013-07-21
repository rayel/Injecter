using System;
using System.Runtime.InteropServices;

namespace Injector
{
    internal class NativeMethods
    {
        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, int dwThreadId);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int CallNextHookEx(int hhk, int nCode, int wParam, IntPtr lParam);

        //WINBASEAPI
        //__bcount_opt(dwSize)
        //LPVOID
        //WINAPI
        //VirtualAllocEx(
        //__in     HANDLE hProcess,
        //__in_opt LPVOID lpAddress,
        //__in     SIZE_T dwSize,
        //__in     DWORD flAllocationType,
        //__in     DWORD flProtect
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int flAllocationType, int flProtect);

        //WINBASEAPI
        //BOOL
        //WINAPI
        //VirtualFreeEx(
        //__in HANDLE hProcess,
        //__in LPVOID lpAddress,
        //__in SIZE_T dwSize,
        //__in DWORD  dwFreeType
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int dwFreeType);

        //WINBASEAPI      
        //BOOL
        //WINAPI
        //WriteProcessMemory(
        //__in      HANDLE hProcess,
        //__in      LPVOID lpBaseAddress,
        //__in_bcount(nSize) LPCVOID lpBuffer,
        //__in      SIZE_T nSize,
        //__out_opt SIZE_T * lpNumberOfBytesWritten
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, string lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(int hModule, string lpProcName);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int GetCurrentThreadId();

        //WINBASEAPI
        //__out_opt
        //HANDLE
        //WINAPI
        //CreateRemoteThread(
        //__in      HANDLE hProcess,
        //__in_opt  LPSECURITY_ATTRIBUTES lpThreadAttributes,
        //__in      SIZE_T dwStackSize,
        //__in      LPTHREAD_START_ROUTINE lpStartAddress,
        //__in_opt  LPVOID lpParameter,
        //__in      DWORD dwCreationFlags,
        //__out_opt LPDWORD lpThreadId
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, SECURITY_ATTRIBUTES lpThreadAttributes, int dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, int dwCreationFlags, out int lpThreadId);

        //WINBASEAPI
        //HANDLE
        //WINAPI
        //OpenProcess(
        //__in DWORD dwDesiredAccess,
        //__in BOOL bInheritHandle,
        //__in DWORD dwProcessId
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        //WINBASEAPI
        //__out_opt
        //HMODULE
        //WINAPI
        //GetModuleHandleW(
        //__in_opt LPCWSTR lpModuleName
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int GetModuleHandleA(string lpModuleName);

        //WINBASEAPI
        //DWORD
        //WINAPI
        //WaitForSingleObject(
        //__in HANDLE hHandle,
        //__in DWORD dwMilliseconds
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        //WINBASEAPI
        //BOOL
        //WINAPI
        //CloseHandle(
        //__in HANDLE hObject
        //);
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hHandle);

    }
}
