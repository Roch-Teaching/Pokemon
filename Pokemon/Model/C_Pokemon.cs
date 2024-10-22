using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Model
{
    public class C_Pokemon
    {
        private int _Id;
        private string _Name;
        private Element _Element;
        private int _MaxPV;
        private int _PV;
        private int _IdAttaque1;
        private int _IdAttaque2;
        private Joueur _Joueur;

        public static readonly ImmutableList<Attaque> _DICOATTAQUES = ImmutableList.Create<Attaque>
            (
                new Attaque(0, "Flammeche", Element.Feu, 1),
                new Attaque(1, "Lance-flamme", Element.Feu, 10),
                new Attaque(2, "Tornade", Element.Air, 1),
                new Attaque(3, "Bourrasque", Element.Air, 2),
                new Attaque(4, "Tourbillon", Element.Eau, 1),
                new Attaque(5, "Vague", Element.Eau, 2)
            );
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Element Element
        {
            get { return _Element; }
            set { _Element = value; }
        }

        public int MaxPV
        {
            get { return _MaxPV; }
            set { _MaxPV = value; }
        }
        public int PV
        {
            get { return _PV; }
            set { _PV = value; }
        }

        public int IdAttaque1
        {
            get { return _IdAttaque1; }
            set { _IdAttaque1 = value;}
        }

        public int IdAttaque2
        {
            get { return _IdAttaque2; }
            set { _IdAttaque2 = value; }
        }

        public Joueur Joueur
        {
            get { return _Joueur; }
            set { _Joueur = value; }
        }


        public C_Pokemon(){}

        public C_Pokemon(int Id_, string Name_, Element Element_, int MaxPV_, int PV_, int IdAttaque1_, int IdAttaque2_, Joueur Joueur_)
        {
            Id = Id_;
            Name = Name_;
            Element = Element_;
            MaxPV = MaxPV_;
            PV = PV_;
            IdAttaque1 = IdAttaque1_;
            IdAttaque2 = IdAttaque2_;
            Joueur = Joueur_;
        }

        public void EncaisserAttaque (int idAttaque)
        {
            int Pvtmp;
            Pvtmp = this.PV - (_DICOATTAQUES[idAttaque].Damage * CalculateCoeffDamage(this.Element, _DICOATTAQUES[idAttaque].Element));
            if (Pvtmp < 0)
            {
                this.PV = 0;
            }
            else
            {
                this.PV = Pvtmp;
            }
        }

        static int CalculateCoeffDamage(Element elementPokemon,Element elementAttaque)
        {
            switch (elementAttaque)
            {
                case Element.Feu:
                    switch (elementPokemon)
                    {
                        case Element.Feu: return 2;
                        case Element.Air: return 4;
                        case Element.Eau: return 1;
                    }
                break;
                case Element.Air:
                    switch (elementPokemon)
                    {
                        case Element.Feu: return 1;
                        case Element.Air: return 2;
                        case Element.Eau: return 4;
                    }
                break;
                case Element.Eau:
                    switch (elementPokemon)
                    {
                        case Element.Feu: return 4;
                        case Element.Air: return 1;
                        case Element.Eau: return 2;

                    }
                break;
            }
            return 0;

        }
    }

    public enum Element
    {
        Feu,
        Air,
        Eau
    }

    public enum Joueur
    {
        Joueur1,
        Joueur2,
    }

    public class Attaque
    {
        private int _Id;
        private string _Name;
        private Element _Element;
        private int _Damage;

        public int Id
        {
            get { return _Id; } 
            set { _Id = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Element Element
        {
            get { return _Element; }
            set { _Element = value; }
        }

        public int Damage
        {
            get { return _Damage; }
            set { _Damage = value; }
        }

        public Attaque() { }

        public Attaque(int Id_, string Name_, Element Element_, int Damage_)
        {
            Id = Id_;
            Name = Name_;
            Element = Element_;
            Damage = Damage_;
        }


    }
}
