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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _21cardtrick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool GameStarted = false;
        Deck Deck;
        Dealer dealer;
        //internal object imgTheCard;

        public MainWindow()
        {
            InitializeComponent();
            Deck = new Deck();
            dealer = new Dealer();
        }

        private void cmd_PLayGame(object sender, RoutedEventArgs e)
        {
            GameStarted = true;
            dealer.ShowCards();
        }

        private void cmd_Column1(object sender, RoutedEventArgs e)
        {

        }

        private void cmd_Column2(object sender, RoutedEventArgs e)
        {

        }

        private void cmd_Column3(object sender, RoutedEventArgs e)
        {

        }
    }
}
