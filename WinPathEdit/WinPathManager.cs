﻿using System;
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

        private readonly EnvironmentVariableTarget _target = EnvironmentVariableTarget.Machine; 

        public string PathVar { get; private set; }

        public string[] Values { get; private set; }

        public WinPathsSet.PathVarDataTable Table { get; private set; }

        public WinPathManager()
        {
            SetValues();
        }

        private void SetValues()
        {
            PathVar = Environment.GetEnvironmentVariable("path", _target);
            Values = PathVar.Split(';');
            InitiateDataSet();
        }

        public bool UpdatePath(Form1 form)
        {
            if (form == null)
            {
                return false;
            }
            string newPathVar = ConvertDataSetToString();

            if (System.Windows.Forms.MessageBox.Show(form, newPathVar, "Is this correct?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    Environment.SetEnvironmentVariable("path", newPathVar, _target);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(form, e.Message, "Error",  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    SetValues();
                    return false;
                }
                SetValues();
                return true;
            }
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
