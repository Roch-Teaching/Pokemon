using Pokemon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Windows;
using Pokemon.View;

namespace Pokemon.ViewModel
{
    public class VM_Pokemon : ProprieteDeBase
    {
        private string chConnexion = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Pokemon;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False";
        #region Donnée

        private VM_unJoueur _Joueur1;
        private VM_unJoueur _Joueur2;
        private VM_unJoueur _JoueurActif;
        private ObservableCollection<Attaque> _lsAttaque = new ObservableCollection<Attaque>();
        private Attaque _AttaqueEnCours;
		private Attaque _sAttaque1;
		private Attaque _sAttaque2;

		public VM_unJoueur Joueur1
        {
            get { return _Joueur1; }
            set { AssignerChamp<VM_unJoueur>(ref _Joueur1, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        public VM_unJoueur Joueur2
        {
            get { return _Joueur2; }
            set { AssignerChamp<VM_unJoueur>(ref _Joueur2, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        public VM_unJoueur JoueurActif
        {
            get { return _JoueurActif; }
            set { AssignerChamp<VM_unJoueur>(ref _JoueurActif, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        public ObservableCollection<Attaque> lsAttaque
        {
            get { return _lsAttaque; }
            set { _lsAttaque = value; }
        }

        public Attaque AttaqueEnCours
        {
            get { return _AttaqueEnCours; }
            set { AssignerChamp<Attaque>(ref _AttaqueEnCours, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

		public Attaque sAttaque1
		{
			get { return _sAttaque1; }
			set { _sAttaque1 = value; }
		}

		public Attaque sAttaque2
        {
            get { return _sAttaque2; }
            set { _sAttaque2 = value; }
        }

		#endregion

			#region Commandes
		public BaseCommande cAttaquer { get; set; }
        public BaseCommande cLoadCommand { get; set; }
		public BaseCommande cNewGame { get; set; }
		public BaseCommande cNewPokemon1 { get; set; }
		public BaseCommande cNewPokemon2 { get; set; }




		public void Attaquer()
        {
            Attaque tmpAttaque = AttaqueEnCours;
            if (JoueurActif.Joueur == Joueur.Joueur1)
            {
                JoueurActif = Joueur2;
            }
            else
            {
                JoueurActif = Joueur1;
            }
            C_Pokemon tmppokemon = new C_Pokemon();
            tmppokemon.Id = JoueurActif.Id;
            tmppokemon.Name = JoueurActif.Name;
            tmppokemon.Element = JoueurActif.Element;
            tmppokemon.MaxPV = JoueurActif.MaxPV;
            tmppokemon.PV = JoueurActif.PV;
            tmppokemon.Joueur = JoueurActif.Joueur;
            tmppokemon.IdAttaque1 = JoueurActif.Attaques[0].Id;
            tmppokemon.IdAttaque2 = JoueurActif.Attaques[1].Id;
            new Model.G_Pokemon(chConnexion).EncaisserAttaque(tmppokemon,tmpAttaque.Id);
            JoueurActif.PV=tmppokemon.PV;

        }
        #endregion
        public void Charger()
        {
            Joueur1 = ChargerJoueur(Joueur.Joueur1);
            Joueur2 = ChargerJoueur(Joueur.Joueur2);
            JoueurActif = Joueur1;
        }

		public void NewGame()
		{
			new G_Pokemon(chConnexion).NouvellePartie();
			DisplayJ1();
			DisplayJ2();
            Charger();
		}

		public void NewPokemon1()
		{
			C_Pokemon pokemon = new C_Pokemon()
			{
				Joueur = Joueur.Joueur1,
				Name = Joueur1.Name,
				Element = Joueur1.Element,
				MaxPV = Joueur1.MaxPV,
				PV = Joueur1.PV,
				IdAttaque1 = sAttaque1.Id,
				IdAttaque2 = sAttaque2.Id
			};

			new G_Pokemon(chConnexion).AjouterPokemon(pokemon);
		}

		public void NewPokemon2()
		{
			C_Pokemon pokemon = new C_Pokemon()
			{
				Joueur = Joueur.Joueur2,
				Name = Joueur2.Name,
				Element = Joueur2.Element,
				MaxPV = Joueur2.MaxPV,
				PV = Joueur2.PV,
				IdAttaque1 = sAttaque1.Id,
				IdAttaque2 = sAttaque2.Id
			};

            new G_Pokemon(chConnexion).AjouterPokemon(pokemon);
		}

		#region Constructeur

		public void DisplayJ1()
		{
			Joueur1 joueur1 = new Joueur1();
			joueur1.DataContext = this;
			joueur1.ShowDialog();
		}

		public void DisplayJ2()
		{
			Joueur2 joueur2 = new Joueur2();
			joueur2.DataContext = this;
			joueur2.ShowDialog();
		}

		public VM_Pokemon()
        {
            Joueur1 = new VM_unJoueur();
            Joueur2 = new VM_unJoueur();
            JoueurActif = Joueur1;
            lsAttaque = ChargerlsAttaque();
            AttaqueEnCours = new Attaque();
			sAttaque1 = new Attaque();
			sAttaque2 = new Attaque();

			cAttaquer = new BaseCommande(Attaquer);
            cLoadCommand = new BaseCommande(Charger);
            cNewGame = new BaseCommande(NewGame);
            cNewPokemon1 = new BaseCommande(NewPokemon1);
            cNewPokemon2 = new BaseCommande(NewPokemon2);
        }

        private ObservableCollection<Attaque> ChargerlsAttaque()
        {
            ObservableCollection<Attaque> res = new ObservableCollection<Attaque>();
            foreach (Attaque c in C_Pokemon._DICOATTAQUES)
            {
                res.Add(c);
            }
            return res;
        }
       
        private VM_unJoueur ChargerJoueur(Joueur joueur)
        {
            VM_unJoueur res = new VM_unJoueur();
            C_Pokemon tmpPokemon = new C_Pokemon();
            tmpPokemon = new Model.G_Pokemon(chConnexion).ChargerPokemonJoueur(joueur);
            res.Id = tmpPokemon.Id;
            res.Name = tmpPokemon.Name;
            res.Element = tmpPokemon.Element;
            res.MaxPV = tmpPokemon.MaxPV;
            res.Joueur = tmpPokemon.Joueur;
            res.PV = tmpPokemon.PV;
            

            res.Attaques = new ObservableCollection<Attaque>();
            res.Attaques.Add(C_Pokemon._DICOATTAQUES[tmpPokemon.IdAttaque1]);
            res.Attaques.Add(C_Pokemon._DICOATTAQUES[tmpPokemon.IdAttaque2]);
            return res;
        }

        #endregion
    }

    public class VM_unJoueur : ProprieteDeBase
    {
        private int _Id;
        private string _Name;
        private Element _Element;
        private int _MaxPV;
        private int _PV;
        private ObservableCollection<Attaque> _Attaques;
        private Joueur _Joueur;

        public int Id
        {
            get { return _Id; }
            set
            {
                AssignerChamp<int>(ref _Id, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                AssignerChamp<string>(ref _Name, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public Element Element
        {
            get { return _Element; }
            set
            {
                AssignerChamp<Element>(ref _Element, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public int MaxPV
        {
            get { return _MaxPV; }
            set
            {
                AssignerChamp<int>(ref _MaxPV, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public int PV
        {
            get { return _PV; }
            set
            {
                AssignerChamp<int>(ref _PV, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (value == 0)
                {
                    MessageBox.Show("La partie est terminée ! " + this.Joueur +" a perdu");
                }
            }
        }

        public ObservableCollection<Attaque> Attaques
        {
            get { return _Attaques; }
            set { _Attaques = value; }
        }

        public Joueur Joueur
        {
            get { return _Joueur; }
            set
            {
                AssignerChamp<Joueur>(ref _Joueur, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

    }
}