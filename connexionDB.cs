using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eglise_mambowa
{
    internal class connexionDB
    {
        private string chaine = @"Data Source=MALIMBO\SQLEXPRESS;Initial Catalog=gestionRevenus;Integrated Security=True";
        public SqlConnection GetConnexion()
        {
            SqlConnection con = new SqlConnection(chaine);
            return con;
        }
    }
}
