using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RegistrationOfTrafficAccidents
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=Admin; password=admin; database=registrationoftraficincedents;Convert Zero Datetime=True;");

        public void openConnection()
        {

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
