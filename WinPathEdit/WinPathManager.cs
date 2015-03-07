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

        public string PathVar { get; private set; }

        public string[] Values { get; private set; }

        public WinPathsSet.PathVarDataTable Table { get; private set; }

        public WinPathManager()
        {
            SetValues();
        }

        private void SetValues()
        {
            PathVar = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process);
            Values = PathVar.Split(';');
            InitiateDataSet();
        }

        public bool UpdatePath()
        {
            string newPathVar = ConvertDataSetToString();
            Environment.SetEnvironmentVariable("path", "", EnvironmentVariableTarget.Process);
            return false;
        }

        private void InitiateDataSet()
        {
            Table = new WinPathsSet.PathVarDataTable();
            foreach (string v in Values)
            {
                Table.AddPathVarRow(v);
            }
        }

        private string ConvertDataSetToString()
        {
            
            if (Table != null)
            {
                try
                {
                    Table.VarColumn.ReadOnly = true;
                    List<string> rowStrings = new List<string>(Table.Rows.Count);
                    foreach (WinPathsSet.PathVarRow row in Table.Rows)
                    {
                        rowStrings.Add(row.Var);
                    }

                    return string.Join(";", rowStrings);
                }
                finally
                {
                    Table.VarColumn.ReadOnly = false;
                }


                    
            }
            return null;
        }
    }
}
