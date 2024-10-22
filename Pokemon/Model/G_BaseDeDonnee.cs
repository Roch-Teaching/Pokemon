using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Model
{
    public class G_BaseDeDonnee
    {
        protected string ChaineDeConnexion;
        public G_BaseDeDonnee()
        { }

        public G_BaseDeDonnee(string chConn)
        {
            ChaineDeConnexion = chConn;
        }
    }
}
