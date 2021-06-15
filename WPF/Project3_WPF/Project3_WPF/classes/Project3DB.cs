using MySql.Data.MySqlClient;
using System.Data;

namespace Project3_WPF.classes
{
    class Project3DB
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        public DataTable SelectedThemas()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM thema;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (System.Exception)
            {

            }
            finally
            {
                _connection.Close();
            }

            return result;
        }
        public DataTable SelectedPartij()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM partij;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (System.Exception)
            {
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

    }
}
