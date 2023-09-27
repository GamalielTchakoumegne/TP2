using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Donnee;

namespace TP2.Application
{
    public class Application
    {
        Donnee.Donnee Donnee;
        public Application()
        {
            // J'instancie mon attribut pour faire appel à ma 3e couche
            Donnee = new Donnee.Donnee();
        }

        //envoie pour l'affichage des crimes possibles
        public List<string> AffichageLesCrimesPossibles()
        {
            List<string> ListeCrimesPossible;

            ListeCrimesPossible = Donnee.AffichageLesCrimesPossibles();
            
            return ListeCrimesPossible;
            
        }

        //Creation d'un nouveau criminel
        public void AjoutCriminel(string nom, string prenom, DateTime dateNaissance, string crime)
        {
            int idCriminel = Donnee.AjoutCriminel(nom, prenom, dateNaissance);

            int idCrime = Donnee.GetIdCrime(crime);

            Donnee.attribuationCrimeCommis(idCrime, idCriminel);
        }

        //creation d'un nouveau crime
        public void AjoutCrime(string crime)
        {
            Donnee.AjoutCrime(crime);
        }

        public Boolean VerificationNouveauCrime(string crime)
        {
            //si nouveau crime, creation de celui-ci
            if (crime.Equals("autre", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else 
            {
                return false;
            } 
        }
    }
}
