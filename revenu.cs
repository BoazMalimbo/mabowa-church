using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eglise_mambowa
{
    internal class revenu
    {

        // on instancie la classe de la connexion a la db
        connexionDB db = new connexionDB();

        public void ajouterRevenu(revenuModel rm)
        {
            SqlConnection con = db.GetConnexion();

            // la requete pour insertion
            string query = "INSERT INTO Revenus (DateRevenu, TypeRevenu, Montant, Description,idUser) " +
                   "VALUES (@date, @type, @montant, @desc, @idUser)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                // Passage des valeurs de l'objet vers les paramètres SQL
                cmd.Parameters.AddWithValue("@date", rm.Date);
                cmd.Parameters.AddWithValue("@type", rm.Typerevenu);
                cmd.Parameters.AddWithValue("@montant", rm.Montant);
                cmd.Parameters.AddWithValue("@desc", rm.Description);
                cmd.Parameters.AddWithValue("@idUser", rm.IdUser);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Revenu enregistré avec succès !");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
