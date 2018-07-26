using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using $safeprojectname$.SheetMusic;

namespace humanmusic
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //PlayScale();
            ////return;

            //Boolean done = false;
            //while (!done)
            //{
            //    GenerateSong();
            //    Console.WriteLine("Song Complete. Anykey to continue, Esc to quit");
            //    while (Console.KeyAvailable) Console.ReadKey();
            //    var ch = Console.ReadKey(true);
            //    if (ch.Key == ConsoleKey.Escape)
            //        done = true;
            //}
        }
    }
}
