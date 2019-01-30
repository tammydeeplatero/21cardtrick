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

        Deck deck = new Deck();
        List<Card> deck21 = new List<Card>(21);

        static List<Card> cardList0 = new List<Card>();
        static List<Card> cardList1 = new List<Card>();
        static List<Card> cardList2 = new List<Card>();

        public Dealer()
        {

            deck21 = deck.GenerateDeck();

            //deck21 = deck.Deal21();


        }

        public void ShowCards() // Testing taking out args deck is never used. Deck deck
        {


            ImageSourceConverter imgs = new ImageSourceConverter();
            MainWindow window = App.Current.Windows.OfType<MainWindow>().SingleOrDefault(x => x.IsActive);


            RectangleGeometry rect = new RectangleGeometry(new System.Windows.Rect(new System.Windows.Size(363, 250)));
            Image img = new Image();

            img.Height = 60;
            img.Width = 25;
            img.Stretch = Stretch.Fill;

            cardList0.Add(deck21[0]);
            cardList0.Add(deck21[3]);
            cardList0.Add(deck21[6]);
            cardList0.Add(deck21[9]);
            cardList0.Add(deck21[12]);
            cardList0.Add(deck21[15]);
            cardList0.Add(deck21[18]);

            cardList1.Add(deck21[1]);
            cardList1.Add(deck21[4]);
            cardList1.Add(deck21[7]);
            cardList1.Add(deck21[10]);
            cardList1.Add(deck21[13]);
            cardList1.Add(deck21[16]);
            cardList1.Add(deck21[19]);

            cardList2.Add(deck21[2]);
            cardList2.Add(deck21[5]);
            cardList2.Add(deck21[8]);
            cardList2.Add(deck21[11]);
            cardList2.Add(deck21[14]);
            cardList2.Add(deck21[17]);
            cardList2.Add(deck21[20]);


            window.img1.Source = imgs.ConvertFromString( deck21[0].GetCardPicture()) as ImageSource;
            window.img2.Source = imgs.ConvertFromString( deck21[1].GetCardPicture()) as ImageSource;
            window.img3.Source = imgs.ConvertFromString( deck21[2].GetCardPicture()) as ImageSource;
            window.img4.Source = imgs.ConvertFromString( deck21[3].GetCardPicture()) as ImageSource;
            window.img5.Source = imgs.ConvertFromString( deck21[4].GetCardPicture()) as ImageSource;
            window.img6.Source = imgs.ConvertFromString( deck21[5].GetCardPicture()) as ImageSource;
            window.img7.Source = imgs.ConvertFromString( deck21[6].GetCardPicture()) as ImageSource;
            window.img8.Source = imgs.ConvertFromString( deck21[7].GetCardPicture()) as ImageSource;
            window.img9.Source = imgs.ConvertFromString( deck21[8].GetCardPicture()) as ImageSource;

            window.img10.Source = imgs.ConvertFromString( deck21[9].GetCardPicture()) as ImageSource;
            window.img11.Source = imgs.ConvertFromString( deck21[10].GetCardPicture()) as ImageSource;
            window.img12.Source = imgs.ConvertFromString(deck21[11].GetCardPicture()) as ImageSource;
            window.img13.Source = imgs.ConvertFromString( deck21[12].GetCardPicture()) as ImageSource;
            window.img14.Source = imgs.ConvertFromString( deck21[13].GetCardPicture()) as ImageSource;
            window.img15.Source = imgs.ConvertFromString( deck21[14].GetCardPicture()) as ImageSource;
            window.img16.Source = imgs.ConvertFromString(deck21[15].GetCardPicture()) as ImageSource;
            window.img17.Source = imgs.ConvertFromString( deck21[16].GetCardPicture()) as ImageSource;
            window.img18.Source = imgs.ConvertFromString( deck21[17].GetCardPicture()) as ImageSource;
            window.img19.Source = imgs.ConvertFromString( deck21[18].GetCardPicture()) as ImageSource;
            window.img20.Source = imgs.ConvertFromString(deck21[19].GetCardPicture()) as ImageSource;
            window.img21.Source = imgs.ConvertFromString( deck21[20].GetCardPicture()) as ImageSource;
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

            //window.imgTheCard.Source = imgs.ConvertFromString(@"C:\Users\Ahmed\Desktop\21cardtrick-master (1)\21cardtrick-master\21cardtrick\21cardtrick\CardImages\" + deck21[10].GetCardPicture()) as ImageSource;

            window.imgTheCardRevealed.Source = imgs.ConvertFromString(deck21[10].GetCardPicture()) as ImageSource;


        }

        public void PickupCards(int columnId)
        {
            // after Player IndicateColumn()
            // indicated column needs to be picked up 2nd.
            // Deal() should be called from here
            List<Card> deck = new List<Card>();


            //column0 = board.getColumn(0);
            //column1 = board.getColumn(1);
            //column2 = board.getColumn(2);

            if (columnId == 0)
            {
                addCardsToDeck(cardList1, deck);
                addCardsToDeck(cardList0, deck);
                addCardsToDeck(cardList2, deck);
            }

            if (columnId == 1)
            {
                addCardsToDeck(cardList0, deck);
                addCardsToDeck(cardList1, deck);
                addCardsToDeck(cardList2, deck);
            }

            if (columnId == 2)
            {
                addCardsToDeck(cardList0, deck);
                addCardsToDeck(cardList2, deck);
                addCardsToDeck(cardList1, deck);
            }

            cardList0.Clear();
            cardList1.Clear();
            cardList2.Clear();

            ////////need this to update the deck21 list so the showCard will show the new deck.
            deck21 = deck;

            ShowCards();
            dealNumber++;
            return;
        }

        public void addCardsToDeck(List<Card> cardList, List<Card> deck)
        {
            foreach (Card card in cardList)
            {
                deck.Add(card);
            }
        }


    } // end Dealer()

}



