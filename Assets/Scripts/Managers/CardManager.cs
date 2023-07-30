using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        cardTemplates.Insert(Random.Range(0, 4), joker);

        for (int i = 0; i < cardTemplates.Count; i++)
        {
            cards.Add(Card.CreateCard(cardTemplates[i]));
        }

        for (int i = 0; i < bottomPositions.Count; i++)
        {
            bottomPositions[i].AddComponent<Card>().template = cards[i].template;
            if (cards[i].template.cardType == CardTemplate.CardType.Joker)
            {
                bottomPositions[i].GetComponentInChildren<TMP_Text>().text = cards[i].template.cardType.ToString();
            }
            else
            {
                bottomPositions[i].GetComponentInChildren<TMP_Text>().text = cards[i].template.cardPip.ToString() + "\n" + cards[i].template.cardSuit.ToString();
            }
        }

        for (int i = 0; i < horizontalPositions.Count; i++)
        {
            horizontalPositions[i].AddComponent<Card>().template = cards[i + bottomPositions.Count].template;
            horizontalPositions[i].GetComponentInChildren<TMP_Text>().text = 
                cards[i + bottomPositions.Count].template.cardPip.ToString() + 
                "\n" + 
                cards[i + bottomPositions.Count].template.cardSuit.ToString();
        }

        for (int i = 0; i < verticalVisiblePositions.Count; i++)
        {
            verticalVisiblePositions[i].AddComponent<Card>().template = cards[i + bottomPositions.Count + horizontalPositions.Count].template;
            verticalVisiblePositions[i].GetComponentInChildren<TMP_Text>().text =
                cards[i + bottomPositions.Count + horizontalPositions.Count].template.cardPip.ToString() +
                "\n" +
                cards[i + bottomPositions.Count + horizontalPositions.Count].template.cardSuit.ToString();
        }

        for (int i = 0; i < verticalInvisiblePositions.Count; i++)
        {
            verticalInvisiblePositions[i].AddComponent<Card>().template = cards[i + bottomPositions.Count + horizontalPositions.Count + verticalVisiblePositions.Count].template;
            verticalInvisiblePositions[i].GetComponentInChildren<TMP_Text>().text =
                cards[i + bottomPositions.Count + horizontalPositions.Count + verticalVisiblePositions.Count].template.cardPip.ToString() +
                "\n" +
                cards[i + bottomPositions.Count + horizontalPositions.Count + verticalVisiblePositions.Count].template.cardSuit.ToString();
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
