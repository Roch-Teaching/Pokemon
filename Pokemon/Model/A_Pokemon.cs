using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Model
{
    public class A_Pokemon : A_BaseDeDonnee
    {
        public A_Pokemon() { }
        
        public A_Pokemon(string chConn) : base(chConn) { }

        public int AjouterPokemon(C_Pokemon pokemon)
        {
            int res = -1;
            _Commande.CommandText = "AjouterPokemon";
            _Commande.Parameters.Add("@ID", System.Data.SqlDbType.Int);
            _Commande.Parameters["@ID"].Direction = System.Data.ParameterDirection.Output;
            _Commande.Parameters.AddWithValue("@NOM", pokemon.Name);
            _Commande.Parameters.AddWithValue("@ELEMENT", pokemon.Element);
            _Commande.Parameters.AddWithValue("@MAXPV", pokemon.MaxPV);
            _Commande.Parameters.AddWithValue("@PV", pokemon.PV);
            _Commande.Parameters.AddWithValue("@ATTAQUE1", pokemon.IdAttaque1);
            _Commande.Parameters.AddWithValue("@ATTAQUE2", pokemon.IdAttaque2);
            _Commande.Parameters.AddWithValue("@JOUEUR", pokemon.Joueur);
            _Commande.Connection.Open();
            _Commande.ExecuteNonQuery();
            res = (int)_Commande.Parameters["@ID"].Value;
            _Commande.Connection.Close();
            return res;
        }

        public int ViderTablePokemon()
        {
            int res = -1;
            _Commande.CommandText = "ViderTablePokemon";
            _Commande.Connection.Open();
            res = _Commande.ExecuteNonQuery();
            _Commande.Connection.Close();
            return res;
        }

        public int ModifierPokemon(C_Pokemon pokemon)
        {
            int res = -1;
            _Commande.CommandText = "ModifierPokemon";
            _Commande.Parameters.AddWithValue("@ID", pokemon.Id);
            _Commande.Parameters.AddWithValue("@NOM", pokemon.Name);
            _Commande.Parameters.AddWithValue("@ELEMENT", pokemon.Element);
            _Commande.Parameters.AddWithValue("@MAXPV", pokemon.MaxPV);
            _Commande.Parameters.AddWithValue("@PV", pokemon.PV);
            _Commande.Parameters.AddWithValue("@ATTAQUE1", pokemon.IdAttaque1);
            _Commande.Parameters.AddWithValue("@ATTAQUE2", pokemon.IdAttaque2);
            _Commande.Parameters.AddWithValue("@JOUEUR", pokemon.Joueur);
            _Commande.Connection.Open();
            res = _Commande.ExecuteNonQuery();
            _Commande.Connection.Close();
            return res;
        }

        public C_Pokemon SelectionnerPokemonJoueur(Joueur joueur)
        {          
            _Commande.CommandText = "SelectionnerPokemonJoueur";
            _Commande.Parameters.AddWithValue("@JOUEUR", joueur);
            _Commande.Connection.Open();
            SqlDataReader dr = _Commande.ExecuteReader();
            dr.Read();
            C_Pokemon res = new C_Pokemon(int.Parse(dr["ID"].ToString()), dr["NOM"].ToString(), (Element)int.Parse(dr["ELEMENT"].ToString()), int.Parse(dr["MAXPV"].ToString()),
                    int.Parse(dr["PV"].ToString()), int.Parse(dr["ATTAQUE1"].ToString()), int.Parse(dr["ATTAQUE2"].ToString()), (Joueur)int.Parse(dr["JOUEUR"].ToString()));
            dr.Close();
            _Commande.Connection.Close();
            return res;
        }

        public List<C_Pokemon> ChargerTousPokemon()
        {
            List<C_Pokemon> res = new List<C_Pokemon>();
            _Commande.CommandText = "SelectionnerTousPokemon";
            _Commande.Connection.Open();
            SqlDataReader dr = _Commande.ExecuteReader();
            while (dr.Read())
            {
                res.Add(new C_Pokemon(int.Parse(dr["ID"].ToString()), dr["NOM"].ToString(), (Element)int.Parse(dr["ELEMENT"].ToString()), int.Parse(dr["MAXPV"].ToString()),
                    int.Parse(dr["PV"].ToString()), int.Parse(dr["ATTAQUE1"].ToString()), int.Parse(dr["ATTAQUE2"].ToString()), (Joueur)int.Parse(dr["JOUEUR"].ToString()) ));
            }
            dr.Close();
            _Commande.Connection.Close();
            return res;
        }
    }
}
