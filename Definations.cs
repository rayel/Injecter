using System;
using System.Runtime.InteropServices;

namespace Injector
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public int time;
        public int pt_x;
        public int pt_y;
    }

    public enum HookTypes
    {
        WH_MSGFILTER = -1,      //{线程级; 截获用户与控件交互的消息}
        WH_JOURNALRECORD = 0,   //{系统级; 记录所有消息队列从消息队列送出的输入消息, 在消息从队列中清除时发生; 可用于宏记录}
        WH_JOURNALPLAYBACK = 1, //{系统级; 回放由 WH_JOURNALRECORD 记录的消息, 也就是将这些消息重新送入消息队列}
        WH_KEYBOARD = 2,        //{系统级或线程级; 截获键盘消息}
        WH_GETMESSAGE = 3,      //{系统级或线程级; 截获从消息队列送出的消息}
        WH_CALLWNDPROC = 4,     //{系统级或线程级; 截获发送到目标窗口的消息, 在 SendMessage 调用时发生}
        WH_CBT = 5,             //{系统级或线程级; 截获系统基本消息, 譬如: 窗口的创建、激活、关闭、最大最小化、移动等等}
        WH_SYSMSGFILTER = 6,    //{系统级; 截获系统范围内用户与控件交互的消息}
        WH_MOUSE = 7,           //{系统级或线程级; 截获鼠标消息}
        WH_HARDWARE = 8,        //{系统级或线程级; 截获非标准硬件(非鼠标、键盘)的消息}
        WH_DEBUG = 9,           //{系统级或线程级; 在其他钩子调用前调用, 用于调试钩子}
        WH_SHELL = 10,          //{系统级或线程级; 截获发向外壳应用程序的消息}
        WH_FOREGROUNDIDLE = 11, //{系统级或线程级; 在程序前台线程空闲时调用}
        WH_CALLWNDPROCRET = 12,  //{系统级或线程级; 截获目标窗口处理完毕的消息, 在 SendMessage 调用后发生}
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }

    public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    internal class SECURITY_ATTRIBUTES
    {
        int nLength;
        IntPtr lpSecurityDescriptor;
        bool bInheritHandle;
    }

    enum AllocationTypes
    {
        MEM_COMMIT = 0x00001000,
        MEM_RESERVE = 0x00002000,
        MEM_RESET = 0x00080000,
        MEM_RESET_UNDO = 0x1000000,
        MEM_LARGE_PAGES = 0x20000000,
        MEM_PHYSICAL = 0x00400000,
        MEM_TOP_DOWN = 0x00100000,
    }

    enum FreeTypes
    {
        MEM_RELEASE = 0x8000,
        MEM_DECOMMIT = 0x4000
    }

    enum ProtectTypes
    {
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_NOACCESS = 0x01,
        PAGE_READONLY = 0x02,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400
    }

    [Flags]
    enum DesiredAccesstypes
    {
        DELETE = 0x00010000,
        READ_CONTROL = 0x00020000,
        SYNCHRONIZE = 0x00100000,
        WRITE_DAC = 0x00040000,
        WRITE_OWNER = 0x00080000,
        PROCESS_CREATE_PROCESS = 0x0080,
        PROCESS_CREATE_THREAD = 0x0002,
        PROCESS_DUP_HANDLE = 0x0040,
        PROCESS_QUERY_INFORMATION = 0x0400,
        PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
        PROCESS_SET_INFORMATION = 0x0200,
        PROCESS_SET_QUOTA = 0x0100,
        PROCESS_SUSPEND_RESUME = 0x0800,
        PROCESS_TERMINATE = 0x0001,
        PROCESS_VM_OPERATION = 0x0008,
        PROCESS_VM_READ = 0x0010,
        PROCESS_VM_WRITE = 0x0020,
    }
}
