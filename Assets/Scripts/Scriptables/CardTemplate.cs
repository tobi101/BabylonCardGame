using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Basic Card")]
public class CardTemplate : ScriptableObject
{

    public int cardId;
    public string cardName;
    public Sprite icon;

    [Header("Card Features")]
    public CardType cardType;
    public CardSuit cardSuit;
    public CardPip cardPip;

    public Texture2D cardTexture;

    public bool isVisible = false;
    
    public enum CardType
    {
        SimpleCard,
        Joker
    }
    public enum CardSuit
    {
        None,
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum CardPip
    {
        None,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
