using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise3Boot
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Szakolczai Martin\Desktop\titkos.txt");
            StreamWriter sw = new StreamWriter(@"C:\Users\Szakolczai Martin\Desktop\boot-utf7.txt", false, Encoding.UTF7);

            sw.WriteLine(sr.ReadToEnd());
            sw.Close();
            sr.Close();

        }
    }
}
