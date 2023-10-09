using UnityEngine;

public enum CardColor
{
    Black,
    Green,
    Blue,
    Red,
    White
}

public enum CardDeckType
{
    Bottom,
    Middle,
    Top
}

[CreateAssetMenu(menuName = "Cards/Card")]
public class CardAsset : ScriptableObject
{
    public int CardsAmountInHighDeck;
    public int CardsAmountInMiddleDeck;
    public int CardsAmountInBottomDeck;
    public CardColor cardColor;
    public CardDeckType DeckType;
    public int AwardedPoints;
    public bool IsSpecialTopCard;
    
}
