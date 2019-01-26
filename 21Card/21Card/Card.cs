public class Card
{
    private string face;
    private string suit;

    public Card(string theFace,string theSuit)
    {
        face = theFace;
        suit = theSuit;

    }

    public override string ToString()
    {
        return face + " of " + suit;
    }

}