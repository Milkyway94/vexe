using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAC
{
    public class WriteLog
    {
        public static void Write(string log, string address)
        {

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@address))
            {
                file.Write("[" + DateTime.Now + "]");
                file.Write(log);
                file.WriteLine();
            }
        }
    }
}
