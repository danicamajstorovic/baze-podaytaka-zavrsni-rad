using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FrizerskiSalon
{
    class Konekcija
    {
        static public SqlConnection konektovanje()
        {
            String connection_string = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection konekcija = new SqlConnection(connection_string);
            return konekcija;
        }
    }
}
