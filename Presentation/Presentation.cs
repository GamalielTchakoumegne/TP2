using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TP2.Application;

namespace TP2.Presentation
{
    public class Presentation
    {
        //déclaration pour l'appel à l'application
        Application.Application Application;

        public Presentation()
        {
            //creation de l'appel
            Application = new Application.Application();
        }




        //affichage


        //ajout d'un criminel
        public void AjoutCriminel()
        {



            string nom = "";
            string prenom = "";
            string crime = "";
            DateTime dateNaissance= DateTime.Now ;
            Boolean ok;

            //boucles pour recommencer en cas d'erreur

            //boucle nom
            do
            {
                ok = false;

                Console.WriteLine("Quel est le nom?");
                nom = Console.ReadLine().Trim();
                try
                {
                    if (nom == "")
                    {
                        throw new Exception("le nom ne doit pas être vide.");
                    }
                    else if (nom.Any(char.IsDigit))
                    {
                        throw new Exception("Le nom ne doit pas contenire de chiffre.");
                    }
                    else
                        ok = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            } while (ok == false);


            //boucle prenom
            do
            {
                ok = false;

                Console.WriteLine("Quel est le prénom?");
                prenom = Console.ReadLine().Trim();
                try
                {
                    if (prenom == "")
                    {
                        throw new Exception("le prénom ne doit pas être vide.");
                    }
                    else if (prenom.Any(char.IsDigit))
                    {
                        throw new Exception("Le prénom ne doit pas contenire de chiffre.");
                    }
                    else
                        ok = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            } while (ok == false);


            //Dates
            Console.WriteLine("==Date de naissance==");
            ok = false;
            do
            {
                string jour;
                string mois;
                string annee;
                
                Console.WriteLine("Le jour?");
                jour = Console.ReadLine().Trim();
                try
                {
                    if(jour == "")
                    {
                        throw new Exception("le jour ne doit pas être vide.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }


                Console.WriteLine("Le mois?");
                mois = Console.ReadLine().Trim();
                try
                {
                    if (mois == "")
                    {
                        throw new Exception("le mois ne doit pas être vide.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                Console.WriteLine("L'année?");
                annee = Console.ReadLine().Trim();
                try
                {
                    if (annee == "")
                    {
                        throw new Exception("l'année ne doit pas être vide.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                string dateAssemblee = annee + "-" + mois + "-" + jour;
                try
                {
                    dateNaissance = DateTime.Parse(dateAssemblee);
                    ok = true;
                }
                catch
                {
                    Console.WriteLine("Date non valide");
                }
                

            } while (ok == false);


            //affichage des crimes de la BD
            Console.WriteLine("Quel crime à été commis?");

            foreach (string CrimePossible in Application.AffichageLesCrimesPossibles())
            {
                Console.WriteLine(" -" + CrimePossible);
            }
            Console.WriteLine(" -Autre");


            //boucle crime
            do
            {
                ok = false;
                crime = Console.ReadLine().Trim();
                try
                {
                    if (crime == "")
                    {
                        throw new Exception("le crime ne doit pas être vide.");
                    }
                    else if (crime.Any(char.IsDigit))
                    {
                        throw new Exception("Le crime ne doit pas contenire de chiffre.");
                    }
                    else
                        ok = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            } while (ok == false);

            if (Application.VerificationNouveauCrime(crime) == true)
            {
                Console.WriteLine("Écrire le nouveu crime :");
                crime = Console.ReadLine();
                Application.AjoutCrime(crime);
            }

            //creation du criminel
            Application.AjoutCriminel(nom, prenom, dateNaissance, crime);

            Console.WriteLine("Le criminel a àtà ajouté.\n");

        }
    }
}
