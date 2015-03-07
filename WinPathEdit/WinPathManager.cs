using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPathEdit
{
    /// <summary>
    /// Manages the Windows Path variable
    /// </summary>
    class WinPathManager
    {

        public string PathVar { get; set; }

        public string[] Values { get; set; }

        public WinPathManager()
        {
            PathVar = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process);
            Values = PathVar.Split(';');
        }



    }
}
