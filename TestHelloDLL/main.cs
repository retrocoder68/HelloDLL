using System;
using System.Text;
using System.Runtime.InteropServices;

namespace TestHelloDLL
{
    class main
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var buf = new byte[1024];
            GCHandle handle = GCHandle.Alloc(buf, GCHandleType.Pinned);

            DllImporter.HelloFromCPP(handle.AddrOfPinnedObject(), buf.Length);
            Console.WriteLine(Encoding.Default.GetString(buf));

            DllImporter.HelloFromC(handle.AddrOfPinnedObject(), buf.Length);
            Console.WriteLine(Encoding.Default.GetString(buf));

            DllImporter.HelloFromAsm(handle.AddrOfPinnedObject(), buf.Length);
            Console.WriteLine(Encoding.Default.GetString(buf));

            handle.Free();
        }
    }
}
