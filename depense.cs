using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eglise_mambowa
{
    internal class depense
    {
        // on instancie la classe de la connexion a la db
        connexionDB db = new connexionDB();

        public void ajouterRevenu(depenseModel rm)
        {
            SqlConnection con = db.GetConnexion();

            // la requete pour insertion
            string query = "INSERT INTO Depenses (DateDepense, TypeDepense, Montant, Description,idUser) " +
                   "VALUES (@date, @type, @montant, @desc, @idUser)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                // Passage des valeurs de l'objet vers les paramètres SQL
                cmd.Parameters.AddWithValue("@date", rm.Date);
                cmd.Parameters.AddWithValue("@type", rm.TypeDepense);
                cmd.Parameters.AddWithValue("@montant", rm.Montant);
                cmd.Parameters.AddWithValue("@desc", rm.Description);
                cmd.Parameters.AddWithValue("@idUser", rm.IdUser);

                con.Open();
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
