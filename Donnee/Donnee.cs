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
        public Donnee()
        {
            connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CRIME;Integrated Security=True;TrustServerCertificate=Yes");
        }

        public List<string> AffichageLesCrimesPossibles()
        {
            //demande
            string queryString = "SELECT * FROM CRIME";

            //déclaration
            SqlCommand cmd = new SqlCommand(queryString, connection);

            //ouverture
            connection.Open();

            //execution
            SqlDataReader reader = cmd.ExecuteReader();

            //declaration de la reception
            List<string> listCrime = new List<string>();

            while (reader.Read())
            {
                listCrime.Add( (string)(reader[1]) );
            }

            //fermeture
            connection.Close();

            return listCrime;
        }

        public int AjoutCriminel(string nom, string prenom, DateTime dateNaissance)
        {
            //ajout criminel
            string queryStringAjoutCriminel = "INSERT INTO Criminel VALUES ('" + nom + "', '" + prenom + "', '" + dateNaissance + "' )";

            //get id
            string queryStringGetId = "SELECT @@IDENTITY AS [@@IDENTITY];";

            //reception du id
            Decimal idNouveauCriminel = 0;

            //commande d'ajout du criminel
            SqlCommand cmdAjoutCriminel = new SqlCommand(queryStringAjoutCriminel, connection);
            
            //commande get id du nouveau criminel
            SqlCommand cmdGetId = new SqlCommand(queryStringGetId, connection);

            connection.Open();

            cmdAjoutCriminel.ExecuteNonQuery();

            SqlDataReader reader = cmdGetId.ExecuteReader();

            while(reader.Read())
            {
                idNouveauCriminel = (Decimal)(reader[0]);
            }

            connection.Close();
            
            return Decimal.ToInt32(idNouveauCriminel);
        }

        //créeation d'un crime
        public void AjoutCrime(string crime)
        {
            string queryStringAjoutCrime = "INSERT INTO Crime VALUES ('" + crime + "')";
            
            //commande d'ajout du crime
            SqlCommand cmdAjoutCrime = new SqlCommand(queryStringAjoutCrime, connection);

            connection.Open();

            cmdAjoutCrime.ExecuteNonQuery();

            connection.Close();
        }

        //trouver le id d'un crime déjà existant
        public int GetIdCrime(string crime)
        {
            int idCrime = 0;
            string queryStringCrimeId = "SELECT ID FROM CRIME WHERE description= '" + crime+"' ";

            SqlCommand cmdCrimeId = new SqlCommand(queryStringCrimeId, connection);

            connection.Open();
            SqlDataReader reader = cmdCrimeId.ExecuteReader();

            while ( reader.Read())
            {
                idCrime = (int)(reader[0]);
            }

            connection.Close();
            return idCrime;
        }

        //attribuation du IdCrime au IdCriminel
        public void attribuationCrimeCommis(int idCrime, int idCriminel)
        {
            string queryString = "INSERT INTO Crime_commis VALUES (" + idCrime + ", "+ idCriminel + " )";

            SqlCommand cmd = new SqlCommand(queryString, connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
