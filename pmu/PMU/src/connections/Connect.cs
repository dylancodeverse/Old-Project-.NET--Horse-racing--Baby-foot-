using System.Data;
using MySql.Data.MySqlClient;

namespace BabyFoot.connections
{
    public class Connect
    {
        public MySqlConnection getMySqlConnection()
        {
            // Connect to a MySQL database
            MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;User Id=root; " +
                "Password=root;Database=pmu;");

            return connection;
        }

        public List<DataTable> ExecuteSelectQuery(string[] queries){
            List<DataTable> result = new List<DataTable>();

            using (MySqlConnection connection = getMySqlConnection())
            {
                connection.Open();

                for (int i = 0; i < queries.Length; i++)
                {
                    DataTable dataTable = new DataTable();

                    using (MySqlCommand command = new MySqlCommand(queries[i], connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }

                    result.Add(dataTable);
                }
            }

            return result;
        }

        public void InsertQuery(string[] queries){
            using (MySqlConnection connection = getMySqlConnection()){
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction()){
                    MySqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;
                    try{
                        foreach (string query in queries){
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (MySqlException e){
                        transaction.Rollback();
                        MessageBox.Show("Erreur lors de l'insertion : " + e.Message);
                    }
                }
            }
        }
    }
}
