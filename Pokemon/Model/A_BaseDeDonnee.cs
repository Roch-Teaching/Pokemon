using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Pokemon.Model
{
 
        public class A_BaseDeDonnee
        {
            protected SqlCommand _Commande;

            public A_BaseDeDonnee()
            { }

            public A_BaseDeDonnee(string chConn)
            {
                _Commande = new SqlCommand();
                _Commande.Connection = new SqlConnection(chConn);
                _Commande.CommandType = System.Data.CommandType.StoredProcedure;
            }

            public A_BaseDeDonnee(string chConn, string sComm)
            {
                _Commande = new SqlCommand();
                _Commande.Connection = new SqlConnection(chConn);
                _Commande.CommandType = System.Data.CommandType.StoredProcedure;
                _Commande.CommandText = sComm;
            }

        } 
}
