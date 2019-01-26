using System;

public class Deck
{
    private Random randNum;
    private Card[] deck;
    private int currentCard;
    private const int FULL_DECK = 52;
    private const int DECK_21 = 21;


    public Deck()
    {
        string[] faces = {"Ace", "Tow", "Tree", "Four", "Five", "Six", "Seven",
                             "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
        string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
        deck = new Card[FULL_DECK];
        currentCard = 0;
        randNum = new Random();
        for (int count = 0; count < deck.Length; count++)
            deck[count] = new Card(faces[count % 11], suits[count / 13]);

    }

    public void Shuffle()
    {
        currentCard = 0;
        for(int first = 0; first < deck.Length; first++)
        {
            int second = randNum.Next(FULL_DECK);
            Card temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
        }

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


            Console.Write(i +" [" + DealCard() + "]");
           
           //if ((i + 1) % 4 == 0)
                Console.WriteLine();
        }
        Console.ReadLine();

    }
}