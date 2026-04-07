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

        // l'instance de la classe de connexion
        connexionDB db = new connexionDB();
        private void revenus_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnexion();

                // La requête SQL pour récupérer tous les revenus
                string query = "SELECT DateRevenu, TypeRevenu, Montant, Description FROM Revenus ORDER BY DateRevenu DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt); // Remplit la table virtuelle avec les données de la BDD

                // "dataGridView1" est le nom par défaut, vérifie le nom du tien dans les propriétés
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'affichage : " + ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Vérifie que l'utilisateur a cliqué sur une ligne valide (pas l'en-tête)
                if (e.RowIndex >= 0)
                {
                    // On récupère la ligne sélectionnée
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // On remplit les champs avec les valeurs des cellules correspondantes
                    // Remplacez "Montant" et "Description" par les noms exacts de vos colonnes ou leurs index (ex: 2, 3)
                    tb_montant.Text = row.Cells["Montant"].Value.ToString();
                    rtb_description.Text = row.Cells["Description"].Value.ToString();

                    // Si vous utilisez un DateTimePicker pour la date :
                    // dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
    

