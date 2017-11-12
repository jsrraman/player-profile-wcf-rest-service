using Rajaraman.PlayerProfile.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Rajaraman.PlayerProfile.Dao
{
    public class DbDao
    {
        private static string connString = string.Empty;

        static DbDao()
        {
            //connString = ConfigurationManager.AppSettings["DbConnString"];
            //connString = "Persist Security Info = false; Integrated Security = true; Initial Catalog = PlayerProfile;Server =.\\SQLEXPRESS";
            connString = "server=.\\SQLEXPRESS;database=PlayersProfile;trusted_connection=true";
        }

        public static List<Country> GetCountries()
        {
            List<Country> countryList = new List<Country>();
            string sqlCommand = "select * from Countries";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    Country country = null;

                    while (reader.Read())
                    {
                        country = new Country
                        {
                            Name = reader["name"] as string
                        };

                        countryList.Add(country);
                    };

                    reader.Close();
                }
            }

            return countryList;
        }
    }
}
