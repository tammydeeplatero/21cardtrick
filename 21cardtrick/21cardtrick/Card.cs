using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21cardtrick
{
    class Card
    {
        public enum Suit { Club, Spade, Heart, Diamond }

        private readonly Suit _suit;

        public int CardNum { get; set; }
        public int Value { get; set; }
        public string CardFaceImg { get; set; }
        public string CardBackImg { get; set; } = "Cards/CardBack.jpg";
        public bool FaceUp { get; set; }

        public Card(Suit suit, int cardNum)
        {
            FaceUp = true;
            _suit = suit;
            CardNum = cardNum;
            switch (CardNum)
            {
                case 1:
                    Value = 11;
                    break;
                case 11:
                case 12:
                case 13:
                    Value = 10;
                    break;
                default:
                    Value = cardNum;
                    break;
            }
            CardFaceImg = "Cards/" + (int)_suit + "-" + CardNum + ".jpg";
        }

        public string GetCardPicture()
        {
            return FaceUp ? CardFaceImg : CardBackImg;
        }
    }
}