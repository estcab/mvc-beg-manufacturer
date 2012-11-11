using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace mvc_beg_manufacturer.Models
{
    public class ManufacturerDB
    {
        // Utilizando ADO.NET       
        public IDictionary<int, string> GetManufacturersList()
        {
            IDictionary<int, string> fabricantes = new Dictionary<int, string>();
           
            // Consulta de seleccion de todos los fabricantes
            string consulta = "SELECT ManufacturerID, ManufacturerName" +
                              " FROM Manufacturer ORDER BY ManufacturerName";                  

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {                   
                    while (reader.Read())
                    {
                        string ManufacturerName = 
                            reader.GetString(reader.GetOrdinal("ManufacturerName"));
                        int ManufacturerID = reader.GetInt32(reader.GetOrdinal("ManufacturerID"));
                        fabricantes.Add(ManufacturerID, ManufacturerName);
                    }
                }

                reader.Close();
            }

            return fabricantes;
        }

        public Manufacturer GetManufacturerByID(int id)
        {
            Manufacturer ma = null;

            string consulta = "SELECT ManufacturerID, ManufacturerName," +
                              " ManufacturerCountry, ManufacturerEmail, ManufacturerWebsite" +
                              " FROM Manufacturer WHERE ManufacturerID = @ManufacturerID";
            
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@ManufacturerID", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ma = new Manufacturer 
                        {
                            ManufacturerName = reader.GetString(reader.GetOrdinal("ManufacturerName")),
                            ManufacturerCountry = reader.GetString(reader.GetOrdinal("ManufacturerCountry")),
                            ManufacturerEmail = reader.GetString(reader.GetOrdinal("ManufacturerEmail")),
                            ManufacturerWebsite = reader.GetString(reader.GetOrdinal("ManufacturerWebsite")),
                        };
                    }
                }

                reader.Close();
            }


            return ma;
        }

        public bool AddManufacturer(Manufacturer m)
        {
            bool error = false;

            string consulta = "INSERT INTO Manufacturer (ManufacturerName, ManufacturerCountry)" +
                              " VALUES (@ManufacturerName, @ManufacturerCountry);";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@ManufacturerName", m.ManufacturerName);
                cmd.Parameters.AddWithValue("@ManufacturerCountry", m.ManufacturerCountry);

                try
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    error = true;
                }
            }


            return error;
        }

        private SqlConnection GetConnection()
        {
            
            string cadena = ConfigurationManager
                    .ConnectionStrings["PlayersConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(cadena);

            return conn;
        }

        
    }
}