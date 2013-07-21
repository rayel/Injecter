using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Injector
{
    public class Injector
    {
        private IntPtr hprocess;
        private IntPtr baseaddress;
        private IntPtr procaddress;
        private IntPtr hthread;

        public void doInject(string dllfullname, int pid)
        {
            try
            {
                hprocess = NativeMethods.OpenProcess((int)(DesiredAccesstypes.PROCESS_QUERY_INFORMATION | DesiredAccesstypes.PROCESS_CREATE_THREAD | DesiredAccesstypes.PROCESS_VM_OPERATION | DesiredAccesstypes.PROCESS_VM_WRITE), false, pid);
                if (hprocess == IntPtr.Zero)
                {
                    Debug.Print("OpenProcess Error");
                    return;
                }
                Debug.Print("OpenProcess OK");

                baseaddress = NativeMethods.VirtualAllocEx(hprocess, IntPtr.Zero, dllfullname.Length, (int)AllocationTypes.MEM_COMMIT, (int)ProtectTypes.PAGE_READWRITE);
                if (baseaddress == IntPtr.Zero)
                {
                    Debug.Print("VirtualAllocEx Error");
                    return;
                }
                Debug.Print("VirtualAllocEx OK");

                int szwritten = 0;
                if (!NativeMethods.WriteProcessMemory(hprocess, baseaddress, dllfullname, dllfullname.Length, out szwritten))
                {
                    Debug.Print("WriteProcessMemory Error");
                    return;
                }
                Debug.Print("WriteProcessMemory OK");

                procaddress = NativeMethods.GetProcAddress(NativeMethods.GetModuleHandleA("Kernel32"), "LoadLibraryA");
                if (procaddress == IntPtr.Zero)
                {
                    Debug.Print("GetProcAddress Error");
                    return;
                }
                Debug.Print("GetProcAddress OK");

                int outthreadid = 0;
                hthread = NativeMethods.CreateRemoteThread(hprocess, null, 0, procaddress, baseaddress, 0, out outthreadid);
                if (hthread == IntPtr.Zero)
                {
                    Debug.Print("CreateRemoteThread Error");
                    return;
                }
                Debug.Print("CreateRemoteThread OK");

                NativeMethods.WaitForSingleObject(hthread, 0xFFFFFFFF);
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace.ToString());
            }
            finally
            {
                if (baseaddress != IntPtr.Zero)
                {
                    NativeMethods.VirtualFreeEx(hprocess, baseaddress, 0, (int)FreeTypes.MEM_RELEASE);
                }
                if (hthread != IntPtr.Zero)
                {
                    NativeMethods.CloseHandle(hthread);
                }
                if (hprocess != IntPtr.Zero)
                {
                    NativeMethods.CloseHandle(hprocess);
                }
            }
        }



    }
}
