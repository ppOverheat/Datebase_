using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase_
{
    internal class Log
    {
        public static async Task WriteLog(string line)
        {
            await File.AppendAllTextAsync("log.log", line+"\n");
        }
        public static async Task Empty()
        {
            await File.WriteAllTextAsync("log.log","");
        }
    }
}
