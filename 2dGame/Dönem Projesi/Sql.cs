using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dönem_Projesi
{
    class Sql
    {
        public SqlConnection baglanti()
        {
            
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-8GBMVTE;Initial Catalog=Oyun;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
