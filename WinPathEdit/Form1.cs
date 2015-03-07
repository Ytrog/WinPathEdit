using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPathEdit
{
    public partial class Form1 : Form
    {
        private WinPathManager _pathManager;
        public Form1()
        {
            InitializeComponent();
            _pathManager = new WinPathManager();
            _pathManager.TargetChanged += _pathManager_TargetChanged;
        }

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}
