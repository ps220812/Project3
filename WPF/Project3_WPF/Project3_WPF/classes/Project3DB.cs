using MySql.Data.MySqlClient;
using System.Data;

namespace Project3_WPF.classes
{
    class Project3DB
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        //Function start to see table Database
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

        // End here

        // Here start the inserts in Database table functions

        public bool InsertPartij(string naam, string adress, string postcode, string gemeente, string email, string telefoonnummer)
        {
            bool result = false;

            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `partij`(`PartijId`, `PartijName`, `Adres`, `Postcode`, `Gemeente`, `EmailAdres`, `Telefoonnummer`) VALUES (NULL,@naam,@adress,@postcode,@gemeente,@email,@telefoonnummer)";
                command.Parameters.AddWithValue("@naam", naam);
                command.Parameters.AddWithValue("@adress", adress);
                command.Parameters.AddWithValue("@postcode", postcode);
                command.Parameters.AddWithValue("@gemeente", gemeente);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                result = (nrOfRowsAffected != 0);

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

        //End here
    }
}
