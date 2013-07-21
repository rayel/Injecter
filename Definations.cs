using System;
using System.Runtime.InteropServices;
namespace Injecter
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
}
