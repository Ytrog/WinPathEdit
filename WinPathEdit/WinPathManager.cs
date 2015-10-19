using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPathEdit.Properties;

namespace WinPathEdit
{
    /// <summary>
    /// Manages the Windows Path variable
    /// </summary>
    class WinPathManager
    {

        private EnvironmentVariableTarget _target;
        private const int _lengthLimit = 2047;

        #region Properties

        public string PathVar { get; private set; }

        public string[] Values { get; private set; }

        public WinPathsSet.PathVarDataTable Table { get; private set; }

        #endregion

        #region Events

        public event EventHandler<EnvironmentVariableTarget> TargetChanged;

        #endregion

        #region ctors

        public WinPathManager()
        {
            SetTargetMachine();
            SetValues();
        }

        #endregion

        #region Public methods

        public bool UpdatePath(Form1 form)
        {
            if (form == null)
            {
                return false;
            }
            string newPathVar = ConvertDataSetToString();

            if (ValidateString(newPathVar, true) && MessageBox.Show(form, newPathVar, Resources.WinPathManager_UpdatePath_Is_this_correct_, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                try
                {
                    Environment.SetEnvironmentVariable("path", newPathVar, _target);
                }
                catch (Exception e)
                {
                    MessageBox.Show(form, e.Message, Resources.WinPathManager_UpdatePath_Error,  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetValues();
                    return false;
                }
                SetValues();
                return true;
            }
            return false;
        }

        public void SetTargetMachine()
        {
            SetTarget(EnvironmentVariableTarget.Machine);
        }

        public void SetTargetUser()
        {
            SetTarget(EnvironmentVariableTarget.User);
        }

        public void SetTargetProcess()
        {
            SetTarget(EnvironmentVariableTarget.Process);
        }

        #endregion

        #region Private methods

        private bool ValidateString(string pathString, bool showWarning)
        {
            if (pathString.Length > _lengthLimit)
            {
                return showWarning ? LengthWarning() : false;
            }

            return true;
        }

        private bool LengthWarning()
        {
            DialogResult result = MessageBox.Show(Resources.WinPathManager_ShowLengthWarning_path_too_long, Resources.WinPathManager_ShowLengthWarning_Warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            return result == DialogResult.OK;
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

        private void InitiateDataSet()
        {

            if (Table == null)
            {
                Table = new WinPathsSet.PathVarDataTable(); 
            }
            else
            {
                Table.Clear();
            }

            foreach (string v in Values)
            {
                Table.AddPathVarRow(v);
            }
        }

        private void SetTarget(EnvironmentVariableTarget target)
        {
            _target = target;
            SetTargetChanged();
        }

        private void SetTargetChanged()
        {
            SetValues();
            if (TargetChanged != null)
            {
                TargetChanged(this, _target);
            }
        }

        private void SetValues()
        {
            PathVar = Environment.GetEnvironmentVariable("path", _target);
            ValidateString(PathVar, true);
            Values = PathVar.Split(';');
            InitiateDataSet();
        }

        #endregion
    }
}
