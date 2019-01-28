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
    }
}
