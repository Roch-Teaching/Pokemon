using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pokemon.ViewModel;

namespace Pokemon.View
{
    /// <summary>
    /// Logique d'interaction pour PokemonCombat.xaml
    /// </summary>
    public partial class PokemonCombat : Window
    {
        private ViewModel.VM_Pokemon LocalPokemon;
        public PokemonCombat()
        {
            InitializeComponent();
            LocalPokemon = new VM_Pokemon();
            DataContext = LocalPokemon;
        }
    }
}
