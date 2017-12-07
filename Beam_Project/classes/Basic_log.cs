using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beam_Project.classes
{
    class Basic_log
    {
        static StreamWriter swt;
        static string logFile = @"C:\Users\Tony Dai\source\repos\Beam_Project\Beam_Project\log.txt";
        static FileStream fs;
        static void Write(string args)
        {
            Console.Out.WriteLine(swt);
            string root = args;
            if (!File.Exists(logFile))
            {
                try
                {
                    fs = File.Create(logFile);
                }
                catch (Exception ex)
                {
                    swt.WriteLine("EXCEPTION HAS BEEN THROWN:\n " + ex + "\n");
                }
            }
        }
    }
}
