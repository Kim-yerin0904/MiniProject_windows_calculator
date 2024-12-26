using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_windows_calculator
{
    internal class ClearFunction
    {
        public string BackspaceButton(string RHS_output)
        {
            RHS_output = RHS_output.Remove(RHS_output.Length - 1);
            if (RHS_output.Length == 0) RHS_output = "0";
            return RHS_output;
        }
        public void ClearCondition()
        {

        }
    }
}
