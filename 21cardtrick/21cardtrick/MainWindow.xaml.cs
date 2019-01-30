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
        public static bool PickedCard = false;
        public static int counter = 0;
        public static int chosenColumn = 0;
        Deck Deck;
        Dealer dealer;
        //internal object imgTheCard;

        public MainWindow()
        {
            InitializeComponent();
            Deck = new Deck();
            dealer = new Dealer();
            ButtonVisibility();
            
        }

        private void ButtonVisibility()
        {
            if (GameStarted == false)
            {
                Column1.IsEnabled = false;
                Column2.IsEnabled = false;
                Column3.IsEnabled = false;
                PlayGame.IsEnabled = true;
                Pick.IsEnabled = false;
            }
            else if (GameStarted == true && PickedCard == true)
            {
                PlayGame.IsEnabled = false;
                Pick.IsEnabled = false;
                Column1.IsEnabled = true;
                Column2.IsEnabled = true;
                Column3.IsEnabled = true;
            }
            else if (GameStarted == true && PickedCard == false)
            {
                Pick.IsEnabled = true;
                PlayGame.IsEnabled = false;
            }
            else
            {

            }
        }

        private void cmd_PLayGame(object sender, RoutedEventArgs e)
        {

            GameStarted = true;
            ButtonVisibility();
            dealer.ShowCards();
        }

        private void cmd_Column1(object sender, RoutedEventArgs e)
        {
            counter += 1;
            chosenColumn = 0;
            checkGame(); 

        }

        private void cmd_Column2(object sender, RoutedEventArgs e)
        {
            counter += 1;
            chosenColumn = 1;
            checkGame();

        }

        private void cmd_Column3(object sender, RoutedEventArgs e)
        {
            counter += 1;
            chosenColumn = 2;
            checkGame();

        }

        private void checkGame()
        {
            if (counter == 3)
            {
                dealer.RevealCard();
                GameStarted = false;
                PickedCard = false;
                ButtonVisibility();
                //disable column buttons
                
            }
            else
            {
                dealer.PickupCards(chosenColumn);
            }

        }

        private void cmd_PickYourCard(object sender, RoutedEventArgs e)
        {
            GameStarted = true;
            PickedCard = true;
            ButtonVisibility();
        }
    }
}
