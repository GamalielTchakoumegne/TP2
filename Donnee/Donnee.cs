using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Donnee
{
    public class Donnee
    {
        SqlConnection connection;
        public Donnee() {
            connection = new SqlConnection("Data Source=LAPTOP-LLUB62OV\\SQLEXPRESS;Initial Catalog=CRIME;Integrated Security=True;TrustServerCertificate=Yes");
        }

        public List<(int, string, string)> ListeCriminels()
        {
            string queryString = "SELECT id, prenom, nom FROM Criminel";

            SqlCommand cmd = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<(int, string, string)> criminels = new List<(int, string, string)>();

            while (reader.Read())
            {
                criminels.Add(((int)(reader[0]), (string)(reader[1]), (string)(reader[2])));
            }
            connection.Close();

            return criminels;
        }

        public List<(int, string, string, DateOnly, string)> UnCriminel(int id)
        {
            string queryString = "SELECT Criminel.id, prenom, nom, date_naissance, Crime.description FROM Criminel JOIN Crime_commis on Criminel.id = Crime_commis.criminel_id " +
                "JOIN Crime on Crime_commis.crime_id = Crime.id WHERE Criminel.id = " + id;

            SqlCommand cmd = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<(int, string, string, DateOnly,string)> leCriminel = new List<(int, string, string,DateOnly,string)>();

            while (reader.Read())
            {
                leCriminel.Add(((int)(reader[0]), (string)(reader[1]), (string)(reader[2]), DateOnly.FromDateTime((DateTime)(reader[3])), (string)(reader[4])));
            }
            connection.Close();

            return leCriminel;
        }

    }
}
