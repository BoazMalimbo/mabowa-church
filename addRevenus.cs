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

            

        }

        private void tbn_enregistrer_Click(object sender, EventArgs e)
        {
            // instanciation de la classe model

            try
            {
                revenuModel rvml = new revenuModel();

                rvml.Date = dateTimePicker1.MaxDate;
                rvml.Typerevenu = cb_type.Text;
                rvml.Montant = decimal.Parse(tb_montant.Text);
                rvml.Description = rtb_description.Text;
                rvml.IdUser = 1;

                // on instancie la classe revenu pour avoir acces a la mathode ajouterRevenu
                revenu revenu = new revenu();
                revenu.ajouterRevenu(rvml);

                tb_montant.Clear();
                rtb_description.Clear();

                MessageBox.Show("l'enregistrement a réussi avec succès");
            }
            catch (Exception ex) {
                MessageBox.Show("Erreur"+ ex);
            }

        }
    }
}
