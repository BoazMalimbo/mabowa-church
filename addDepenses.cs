using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eglise_mambowa
{
    public partial class addDepenses : Form
    {
        public addDepenses()
        {
            InitializeComponent();
        }

        connexionDB db = new connexionDB();

        private void tbn_enregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                revenuModel rvml = new revenuModel();

                rvml.Date = dateTimePicker1.MaxDate;
                rvml.Typerevenu = tb_categorie.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }
        }
    }
}
