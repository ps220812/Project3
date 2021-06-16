using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace Project3_WPF.classes
{
    class Project3DB
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");
        #region SELECT function
        // Start SELECT function here
        public DataTable SelectedVerkiezingSoort()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezingsoort;";
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
        #endregion
        #region INSERT function
        // Start INSERT function here
        public bool insertThema(string thema)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `thema`(`ThemaId`, `Thema`) VALUES (NULL, @thema)";
                command.Parameters.AddWithValue("@thema", thema);
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
        public bool insertVerkiezingsoort(string verkiezingsoort)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `verkiezingsoort`(`SoortId`, `Verkiezingsoort`) VALUES (NULL, @verkiezingsoort)";
                command.Parameters.AddWithValue("@verkiezingsoort", verkiezingsoort);
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
        // End here
        #endregion
        #region UPDATE function
        // Start UPDATE function here
        public bool updateThema(string thema, string themaId)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `thema` SET `Thema`= @thema WHERE `ThemaId` = @themaId";
                command.Parameters.AddWithValue("@thema", thema);
                command.Parameters.AddWithValue("@themaId", themaId);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                result = (nrOfRowsAffected != 0);
            }
            catch (System.Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool updateVerkiezingsoort(string verkiezingsoort, string soortId)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `verkiezingsoort` SET `Verkiezingsoort`= @verkiezingsoort WHERE `SoortId` = @soortId";
                command.Parameters.AddWithValue("@verkiezingsoort", verkiezingsoort);
                command.Parameters.AddWithValue("@soortId", soortId);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                result = (nrOfRowsAffected != 0);
            }
            catch (System.Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        // End
        #endregion
        #region DELETE function
        // Start DELETE function here
        public bool deleteThema(string themaId)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `thema` WHERE `ThemaId` = @themaId;";
                command.Parameters.AddWithValue("@themaId", themaId);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                result = (nrOfRowsAffected != 0);
            }
            catch
            {

            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool deleteVerkiezingsoort(string soortId)
        {
            bool result = false;
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `verkiezingsoort` WHERE `SoortId` = @soortId;";
                command.Parameters.AddWithValue("@soortId", soortId);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                result = (nrOfRowsAffected != 0);
            }
            catch
            {

            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        // End
        #endregion
    }
}
