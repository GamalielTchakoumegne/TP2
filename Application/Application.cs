using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Donnee;

namespace TP2.Application
{
    public class Application
    {
        Donnee.Donnee donnee;
        public Application() {
            donnee = new Donnee.Donnee();
        }
        public List <(int, string, string)> AfficherListeCriminels()
        {
            try
            {
                return donnee.ListeCriminels();
            }
            catch { throw new Exception("Erreur avec la base de données"); }
            
        }

        public List<(int, string, string, DateOnly,string)> AfficherUnCriminel(int id)
        {
            try
            {
                return donnee.UnCriminel(id);
            }
            catch { throw new Exception("Erreur avec la base de données"); }
        }

    }
}
