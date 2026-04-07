using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eglise_mambowa
{
    public partial class addRevenus : Form
    {
        public addRevenus()
        {
            InitializeComponent();
        }

        // initialiser la classe de connexion
        connexionDB db = new connexionDB();

        private void addRevenus_Load(object sender, EventArgs e)
        {
            SqlConnection conn = db.GetConnexion();
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                MessageBox.Show("Connexion réussie !");
            }
            else
            {
                MessageBox.Show("Connexion échouée !");
            }

            conn.Close();

        }
    }
}
