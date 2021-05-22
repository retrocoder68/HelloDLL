using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TestHelloDLL
{
    public static class DllImporter
    {
        [DllImport("HelloDLL")]
        public static extern void HelloFromC(IntPtr buf, int len);

        [DllImport("HelloDLL", EntryPoint = "?HelloFromCPP@@YAXPEADH@Z")]
        public static extern void HelloFromCPP(IntPtr buf, int len);

        [DllImport("HelloDLL")]
        public static extern void HelloFromAsm(IntPtr buf, int len);
    }
}
