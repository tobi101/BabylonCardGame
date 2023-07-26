using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{
    public List<CardTemplate> cardTemplates = new();
    public CardTemplate joker;

    public List<GameObject> bottomPositions = new();
    public List<GameObject> horizontalPositions = new();
    public List<GameObject> verticalVisiblePositions = new();
    public List<GameObject> verticalInvisiblePositions = new();

    private List<Card> cards = new();

    // Start is called before the first frame update
    void Start()
    {
        CardShuffle(cardTemplates);
        cardTemplates.Insert(Random.Range(0, 3), joker);

        foreach (var card in cardTemplates)
        {
            cards.Add(Card.CreateCard(card));
        }

        for (int i = 0; i < bottomPositions.Count; i++)
        {
            bottomPositions[i].AddComponent<Card>().template = cards[i].template;
        }

        
    }

    void CardShuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}
