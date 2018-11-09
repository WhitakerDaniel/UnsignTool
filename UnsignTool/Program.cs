using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsigntool
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("Imagehlp.dll ")]
        private static extern bool ImageRemoveCertificate(IntPtr handle, int index);

        private static void UnsignFile(string file)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
            {
                ImageRemoveCertificate(fs.SafeFileHandle.DangerousGetHandle(), 0);
                fs.Close();
            }
        }

        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                UnsignFile(arg);
            }
        }
    }
}
