using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViServiceAdapter
{
    internal static class Utils
    {
        public static ProcessStartInfo MakeProc(this Options opt)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = opt.FileName;
            if (opt.Arguments != null)
                startInfo.Arguments = opt.Arguments;
            startInfo.WorkingDirectory = opt.GetPath();
            if (opt.EnvironmentVariables != null)
            {
                foreach (var e in opt.EnvironmentVariables)
                {
                    var ee = e.Split('=');
                    if (ee.Length != 2)
                        continue;
                    startInfo.EnvironmentVariables.Add(ee[0], ee[1]);
                }
            }
            return startInfo;
        }
    }
}
