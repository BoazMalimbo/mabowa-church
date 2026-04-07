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
    public partial class revenus : Form
    {
        public revenus()
        {
            InitializeComponent();
        }

        private void btn_add_revenus_Click(object sender, EventArgs e)
        {
            addRevenus addRevenus = new addRevenus();
            addRevenus.Show();
        }
    }
}
