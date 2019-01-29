using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace _21cardtrick
{
    class Dealer
    {
        public static int dealNumber = 0; // needs to be dealt and selected at least 3 times. 

        //public static Deck deck = new Deck(); // just want the top 21 cards to work with
        //public static List<Card> deck21 = new List<Card>(21);
        Board board = new Board();

        Column column0 = new Column(0);
        Column column1 = new Column(1);
        Column column2 = new Column(2);

        Deck deck = new Deck();
        List<Card> deck21 = new List<Card>(21);

        public Dealer()
        {
            deck21 = deck.Deal21();


        }

        public void ShowCards() // Testing taking out args deck is never used. Deck deck
        {
            List<Card> cardList = new List<Card>();
            ImageSourceConverter imgs = new ImageSourceConverter();
            MainWindow window = App.Current.Windows.OfType<MainWindow>().SingleOrDefault(x => x.IsActive);


            RectangleGeometry rect = new RectangleGeometry(new System.Windows.Rect(new System.Windows.Size(363, 250)));
            Image img = new Image();

            img.Height = 60;
            img.Width = 25;
            img.Stretch = Stretch.Fill;

            window.img1.Source = imgs.ConvertFromString("..\\..\\" + deck21[0].getFace()) as ImageSource;
            window.img2.Source = imgs.ConvertFromString("..\\..\\" + deck21[1].getFace()) as ImageSource;
            window.img3.Source = imgs.ConvertFromString("..\\..\\" + deck21[2].getFace()) as ImageSource;
            window.img4.Source = imgs.ConvertFromString("..\\..\\" + deck21[3].getFace()) as ImageSource;
            window.img5.Source = imgs.ConvertFromString("..\\..\\" + deck21[4].getFace()) as ImageSource;
            window.img6.Source = imgs.ConvertFromString("..\\..\\" + deck21[5].getFace()) as ImageSource;
            window.img7.Source = imgs.ConvertFromString("..\\..\\" + deck21[6].getFace()) as ImageSource;
            window.img8.Source = imgs.ConvertFromString("..\\..\\" + deck21[7].getFace()) as ImageSource;
            window.img9.Source = imgs.ConvertFromString("..\\..\\" + deck21[8].getFace()) as ImageSource;

            window.img10.Source = imgs.ConvertFromString("..\\..\\" + deck21[9].getFace()) as ImageSource;
            window.img11.Source = imgs.ConvertFromString("..\\..\\" + deck21[10].getFace()) as ImageSource;
            window.img12.Source = imgs.ConvertFromString("..\\..\\" + deck21[11].getFace()) as ImageSource;
            window.img13.Source = imgs.ConvertFromString("..\\..\\" + deck21[12].getFace()) as ImageSource;
            window.img14.Source = imgs.ConvertFromString("..\\..\\" + deck21[13].getFace()) as ImageSource;
            window.img15.Source = imgs.ConvertFromString("..\\..\\" + deck21[14].getFace()) as ImageSource;
            window.img16.Source = imgs.ConvertFromString("..\\..\\" + deck21[15].getFace()) as ImageSource;
            window.img17.Source = imgs.ConvertFromString("..\\..\\" + deck21[16].getFace()) as ImageSource;
            window.img18.Source = imgs.ConvertFromString("..\\..\\" + deck21[17].getFace()) as ImageSource;
            window.img19.Source = imgs.ConvertFromString("..\\..\\" + deck21[18].getFace()) as ImageSource;
            window.img20.Source = imgs.ConvertFromString("..\\..\\" + deck21[19].getFace()) as ImageSource;
            window.img21.Source = imgs.ConvertFromString("..\\..\\" + deck21[20].getFace()) as ImageSource;
        }


        public void Deal()
        {
            // arranges cards on board into columns
            for (int i = 0; i < 21; i++)
            {
                board.addToColumn(i % 3, deck21[i]);
            }
        }

        public void RevealCard()
        {
            ImageSourceConverter imgs = new ImageSourceConverter();
            MainWindow window = App.Current.Windows.OfType<MainWindow>().SingleOrDefault(x => x.IsActive);

            RectangleGeometry rect = new RectangleGeometry(new System.Windows.Rect(new System.Windows.Size(363, 250)));
            Image img = new Image();

            img.Height = 60;
            img.Width = 25;
            img.Stretch = Stretch.Fill;
            // after DealNumber is at least 3
            // selected card is the 11th
            window.imgTheCardRevealed.Source = imgs.ConvertFromString("..\\..\\" + deck21[10].getFace()) as ImageSource;

        }

        public void PickupCards(int columnId)
        {
            // after Player IndicateColumn()
            // indicated column needs to be picked up 2nd.
            // Deal() should be called from here
            List<Card> deck = new List<Card>();


            column0 = board.getColumn(0);
            column1 = board.getColumn(1);
            column2 = board.getColumn(2);

            if (columnId == 0)
            {
                addCardsToDeck(column1, deck);
                addCardsToDeck(column0, deck);
                addCardsToDeck(column2, deck);
            }

            if (columnId == 1)
            {
                addCardsToDeck(column0, deck);
                addCardsToDeck(column1, deck);
                addCardsToDeck(column2, deck);
            }

            if (columnId == 2)
            {
                addCardsToDeck(column0, deck);
                addCardsToDeck(column2, deck);
                addCardsToDeck(column1, deck);
            }

            column0.clearList();
            column1.clearList();
            column2.clearList();

            ////////need this to update the deck21 list so the showCard will show the new deck.
            deck21 = deck;

            Deal();
            dealNumber++;
            return;
        }

        public void addCardsToDeck(Column column, List<Card> deck)
        {
            foreach (Card card in column.getCardList())
            {
                deck.Add(card);
            }
        }


    } // end Dealer()
}
