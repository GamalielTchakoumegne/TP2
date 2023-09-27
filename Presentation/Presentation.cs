using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Application;

namespace TP2.Presentation
{
    public class Presentation
    {
        Application.Application app;

        public Presentation()
        {
            app = new Application.Application();
        }
        public void AfficherCriminels()
        {
            foreach((int,string, string) criminel in app.AfficherListeCriminels())
            {
                Console.WriteLine(criminel);
            }
        }

        public void AfficherCriminelRecherche()
        {
            Console.WriteLine("Quel est l’identifiant du criminel ? ");
            int idCriminel = int.Parse(Console.ReadLine());

            foreach((int, string, string, DateOnly, string) index in app.AfficherUnCriminel(idCriminel))
            {
                Console.WriteLine(index);
            }
         
        }
    }
}
