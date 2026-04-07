using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eglise_mambowa
{
    public partial class depenses : Form
    {
        public depenses()
        {
            InitializeComponent();
        }

        private void btn_add_depenses_Click(object sender, EventArgs e)
        {
            addDepenses addDepenses = new addDepenses();
            addDepenses.Show();
        }
    }
}
