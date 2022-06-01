using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class MSSqlConnection
    {
        public SqlConnectionStringBuilder StringBuilder { get; set; }

        public SqlConnection Connection { get; set; }
        public MSSqlConnection()
        {
            StringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB", //имя сервера источника данных, к которому будем подключаться
                InitialCatalog = "AnimalsDB", //файл, к которому планируем подключаться
                IntegratedSecurity = true, //способ авторизации
                Pooling = false
            };
            Connection = new SqlConnection { ConnectionString = StringBuilder.ConnectionString };
        }
    }
}
