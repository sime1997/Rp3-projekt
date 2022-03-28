using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinaleProjekta
{
    public class Baza
    {
        public MySqlConnection baza;
        public void Connect()
        {
            baza = new MySqlConnection("SERVER = SQL11.freemysqlhosting.net; " +
                "Database = sql11467717; Uid=sql11467717; Pwd=MwTbQZS2fV");
        }
    }
}
