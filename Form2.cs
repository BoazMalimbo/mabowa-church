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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        connexionDB db = new connexionDB();

        public void CalculerStatistiques()
        {
            SqlConnection con = db.GetConnexion();
            try
            {
                con.Open();

                // 1. Récupérer le total des Revenus
                string queryRev = "SELECT SUM(Montant) FROM Revenus";
                SqlCommand cmdRev = new SqlCommand(queryRev, con);
                // ExecuteScalar est parfait ici car on ne veut qu'une seule valeur (le total)
                object resRev = cmdRev.ExecuteScalar();
                decimal totalRevenus = (resRev != DBNull.Value) ? Convert.ToDecimal(resRev) : 0;

                // 2. Récupérer le total des Dépenses
                string queryDep = "SELECT SUM(Montant) FROM Depenses";
                SqlCommand cmdDep = new SqlCommand(queryDep, con);
                object resDep = cmdDep.ExecuteScalar();
                decimal totalDepenses = (resDep != DBNull.Value) ? Convert.ToDecimal(resDep) : 0;

                // 3. Calcul du solde
                decimal soldes = totalRevenus - totalDepenses;

                // 4. Affichage dans les labels avec formatage monétaire (N2 pour 2 décimales)
                total_revenus.Text = totalRevenus.ToString("N2") + " $";
                total_depense.Text = totalDepenses.ToString("N2") + " $";
                solde.Text = soldes.ToString("N2") + " $";

                // Optionnel : Changer la couleur du solde s'il est négatif
                if (soldes < 0)
                {
                    solde.ForeColor = Color.Red;
                }
                else{
                    solde.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de calcul : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }
    }
}
