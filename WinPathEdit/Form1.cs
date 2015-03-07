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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _pathManager = new WinPathManager();
            dgvPaths.DataSource
        }
    }
}
