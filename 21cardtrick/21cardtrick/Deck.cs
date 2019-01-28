using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21cardtrick
{
    class Deck
    {
        private List<Card> _deck;
        private int currentCard;
        private Card[] deck;
        private const int DECK_21 = 21; 

        private void GenerateDeck()
        {
            _deck = new List<Card>();
            for (int i = 0; i <= 3; i++)
            for (int j = 1; j <= 13; j++)
                _deck.Add(new Card((Card.Suit)i, j));
            Shuffle();
        }

        public void Shuffle()
        {
            _deck = _deck.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void Deal()
        {

        }


        public Card DealCard()
        {
            if (currentCard < deck.Length)
                return deck[currentCard++];
            else
                return null;
        }


        public void Deal21()
        {
            for (int i = 0; i < DECK_21; i++)
            {


                Console.Write(i + " [" + DealCard() + "]");

                //if ((i + 1) % 4 == 0)
                Console.WriteLine();
            }
            Console.ReadLine();
        }
}
