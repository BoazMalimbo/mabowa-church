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
using System.Xml.Schema;

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

        public void remplirTableau()
        {
            try
            {
                SqlConnection con = db.GetConnexion();

                // La requête SQL pour récupérer tous les revenus
                string query = "SELECT Id, DateRevenu, TypeRevenu, Montant, Description FROM Revenus ORDER BY DateRevenu DESC";

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
        private void revenus_Load(object sender, EventArgs e)
        {
            remplirTableau();
           
        }

        public int selectecId = 0;

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

                    //recuper l'id de l'element clique
                    selectecId = Convert.ToInt32(row.Cells["Id"].Value); // Remplacez par le nom exact de votre colonne ID
                    // Si vous utilisez un DateTimePicker pour la date :
                    // dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void tbn_modifier_Click(object sender, EventArgs e)
        {
            SqlConnection con = db.GetConnexion();
            if (selectecId == 0) { MessageBox.Show("Sélectionnez d'abord une ligne !"); return; }
            try
            {
                // 2. Requête propre avec uniquement des paramètres
                string query = "UPDATE Revenus SET Montant = @montant, Description = @desc WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                // 3. Passage des valeurs aux paramètres
                // Note: Assurez-vous que tb_montant.Text est bien un nombre
                cmd.Parameters.AddWithValue("@montant", tb_montant.Text);
                cmd.Parameters.AddWithValue("@desc", rtb_description.Text);
                cmd.Parameters.AddWithValue("@id", selectecId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); // Renvoie le nombre de lignes modifiées
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Revenu modifié avec succès !");
                    remplirTableau(); // Rafraîchit le DataGridView
                }
                else
                {
                    MessageBox.Show("Aucune modification n'a été effectuée.");
                }

                // vider les champs apres la mis a jour
                tb_montant.Clear();
                rtb_description.Clear();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            SqlConnection con = db.GetConnexion();

            if (selectecId == 0) { MessageBox.Show("Sélectionnez une ligne !"); return; }

            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce revenu ?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM Revenus WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectecId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Revenu supprimé !");
                remplirTableau(); // Recharger la liste
            }

    }
    }
}
    

