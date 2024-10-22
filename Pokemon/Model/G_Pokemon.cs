using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Model
{
    public class G_Pokemon : G_BaseDeDonnee
    {
        public G_Pokemon() : base()
        { }

        public G_Pokemon(string ChConn) : base(ChConn)
        { }

        public int AjouterPokemon(C_Pokemon pokemon)
        {
            return new A_Pokemon(ChaineDeConnexion).AjouterPokemon(pokemon);
        }     

        public C_Pokemon ChargerPokemonJoueur(Joueur joueur)
        {

           return new A_Pokemon(ChaineDeConnexion).SelectionnerPokemonJoueur(joueur);
            
        }

        public int NouvellePartie()
        {
            return new A_Pokemon(ChaineDeConnexion).ViderTablePokemon();
        }

        public int EncaisserAttaque(C_Pokemon pokemon,int idAttaque)
        {
            pokemon.EncaisserAttaque(idAttaque);
            return new A_Pokemon(ChaineDeConnexion).ModifierPokemon(pokemon);
        }
    }
}
