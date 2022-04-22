using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppR
{
    public class DBConnection
    {
        private SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
        private SqlConnection _connection;


        public void SetSqlConnection(string serverName, string dbName)
        {
            string connectionString = $"Server={serverName};Database={dbName};Trusted_Connection=True;MultipleActiveResultSets=true;";

            try
            {
                _connection = new SqlConnection(connectionString);
                SaveConnectionInfo(serverName, dbName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Open()
        {
            if (_connection.State == System.Data.ConnectionState.Closed )
            {
                try
                {
                    _connection.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Close()
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

//      Сохраняем имя сервера и имя бд в файл
        public void SaveConnectionInfo(string serverName, string dbName)
        {
            using (StreamWriter sw = new StreamWriter("ConnectionInfo.txt"))
            {
                sw.WriteLine(serverName);
                sw.WriteLine(dbName);
            }
        }

//      Получаем имя сервера и имя бд из файла
        public List<string> GetConnectionInfo()
        {
            List<string> lst = new List<string>();

            if (File.Exists("ConnectionInfo.txt"))
            {
                using (StreamReader sr = new StreamReader("ConnectionInfo.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lst.Add(line);
                    }
                }
            }

            return lst;
        }
    
    }
}
