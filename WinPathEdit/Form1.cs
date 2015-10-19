using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPathEdit
{
    public sealed partial class Form1 : Form
    {
        private readonly WinPathManager _pathManager;
        private readonly string _baseTitle;

        #region ctors

        public Form1()
        {
            InitializeComponent();
            _baseTitle = this.Text;
            _pathManager = new WinPathManager();
            _pathManager.TargetChanged += _pathManager_TargetChanged;
        }

        #endregion

        #region Private handlers

        private void _pathManager_TargetChanged(object sender, EnvironmentVariableTarget currentTarget)
        {
            switch (currentTarget)
            {
                case EnvironmentVariableTarget.Machine:
                    btnVarType.Text = "User";
                    break;
                case EnvironmentVariableTarget.Process:
                    break;
                case EnvironmentVariableTarget.User:
                    btnVarType.Text = "Machine";
                    break;
                default:
                    break;
            }

            ShowLength();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLength();
            dgvPaths.DataSource = _pathManager.Table;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _pathManager.UpdatePath(this);
        }

        private void btnVarType_Click(object sender, EventArgs e)
        {
            ChangeType();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPaths.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPaths.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvPaths.Rows.Remove(row);
                    }
                }
            }
            else if (dgvPaths.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dgvPaths.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    if (!row.IsNewRow)
                    {
                        dgvPaths.Rows.Remove(row);
                    }
                }
            }
        }

        #endregion

        #region Private methods

        private void ChangeType()
        {
            string text = btnVarType.Text;
            string user = EnvironmentVariableTarget.User.AsString();
            string machine = EnvironmentVariableTarget.Machine.AsString();

            if (text.Equals(user))
            {
                _pathManager.SetTargetUser();
            }
            if (text.Equals(machine))
            {
                _pathManager.SetTargetMachine();
            }
        }

        private void ChangeTitle(string infoAdded)
        {
            this.Text = string.Format(CultureInfo.InvariantCulture, "{0}\t - {1}", _baseTitle, infoAdded);
        }

        private void ResetTitle()
        {
            this.Text = _baseTitle;
        }

        private void ShowLength()
        {

            if (!string.IsNullOrWhiteSpace(_pathManager.PathVar))
            {
                int length = _pathManager.PathVar.Length;
                ChangeTitle("length: " + length);
            }
            else
            {
                ResetTitle();
            }
        }

        #endregion
    }
}
