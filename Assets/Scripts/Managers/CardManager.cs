using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : Singleton<CardManager>
{
    public Material sharedMaterial;

    public List<CardTemplate> cardTemplates = new();
    public CardTemplate joker;

    public List<GameObject> bottomPositions = new();
    public List<GameObject> horizontalPositions = new();
    public List<GameObject> verticalVisiblePositions = new();
    public List<GameObject> verticalInvisiblePositions = new();

    public List<GameObject> selectedCard = null;

    private Renderer _objectRenderer;
    private MaterialPropertyBlock _propertyBlock;

    private List<Card> cards = new();

    // Start is called before the first frame update
    void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();

        CardShuffle(cardTemplates);
        cardTemplates.Insert(Random.Range(0, 4), joker);

        for (int i = 0; i < cardTemplates.Count; i++)
        {
            cards.Add(Card.CreateCard(cardTemplates[i]));
        }

        for (int i = 0; i < bottomPositions.Count; i++)
        {
            _objectRenderer = bottomPositions[i].GetComponent<Renderer>();
            Material newMaterial = new Material(_objectRenderer.sharedMaterial);

            bottomPositions[i].AddComponent<Card>().template = cards[i].template;

            newMaterial.mainTexture = bottomPositions[i].GetComponent<Card>().template.cardTexture;

            bottomPositions[i].GetComponent<Card>().isVisible = true;
            bottomPositions[i].GetComponent<Card>().isChanged = false;

            _objectRenderer.material = newMaterial;

        }

        for (int i = 0; i < horizontalPositions.Count; i++)
        {
            _objectRenderer = horizontalPositions[i].GetComponent<Renderer>();
            Material newMaterial = new Material(_objectRenderer.sharedMaterial);

            horizontalPositions[i].AddComponent<Card>().template = cards[i + bottomPositions.Count].template;

            newMaterial.mainTexture = horizontalPositions[i].GetComponent<Card>().template.cardTexture;

            horizontalPositions[i].GetComponent<Card>().isVisible = true;
            horizontalPositions[i].GetComponent<Card>().isChanged = false;

            _objectRenderer.material = newMaterial;
        }

        for (int i = 0; i < verticalVisiblePositions.Count; i++)
        {
            _objectRenderer = verticalVisiblePositions[i].GetComponent<Renderer>();
            Material newMaterial = new Material(_objectRenderer.sharedMaterial);

            verticalVisiblePositions[i].AddComponent<Card>().template = cards[i + bottomPositions.Count + horizontalPositions.Count].template;

            newMaterial.mainTexture = verticalVisiblePositions[i].GetComponent<Card>().template.cardTexture;

            verticalVisiblePositions[i].GetComponent<Card>().isVisible = true;
            verticalVisiblePositions[i].GetComponent<Card>().isChanged = false;

            _objectRenderer.material = newMaterial;
        }

        for (int i = 0; i < verticalInvisiblePositions.Count; i++)
        {
            _objectRenderer = verticalInvisiblePositions[i].GetComponent<Renderer>();
            Material newMaterial = new Material(_objectRenderer.sharedMaterial);

            verticalInvisiblePositions[i].AddComponent<Card>().template = cards[i + bottomPositions.Count + horizontalPositions.Count + verticalVisiblePositions.Count].template;

            newMaterial.mainTexture = verticalInvisiblePositions[i].GetComponent<Card>().template.cardTexture;

            verticalInvisiblePositions[i].GetComponent<Card>().isVisible = false;
            verticalInvisiblePositions[i].GetComponent<Card>().isChanged = false;

            _objectRenderer.material = newMaterial;
        }
    }

    private void FixedUpdate()
    {
        // Проверяем клик левой кнопкой мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из точки клика мыши
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, попал ли луч в какой-либо объект
            if (Physics.Raycast(ray, out hit))
            {
                if (CardManager.instance.selectedCard.Count < 2)
                {
                    if (hit.collider.gameObject.GetComponent<Card>().isVisible)
                    {
                        selectedCard.Add(hit.collider.gameObject);
                        Debug.Log("Added" + hit.collider.gameObject.name);
                    }
                }
            }
        }

        if (CardManager.instance.selectedCard.Count == 2)
        {
            if (CardManager.instance.selectedCard[0].GetComponent<Card>().template.cardPip == 
                CardManager.instance.selectedCard[1].GetComponent<Card>().template.cardPip)
            {
                Destroy(CardManager.instance.selectedCard[0]);
                Destroy(CardManager.instance.selectedCard[1]);

                Debug.Log("They are equal!");
            }
            else if (
                CardManager.instance.selectedCard[0].GetComponent<Card>().template.cardSuit ==
                CardManager.instance.selectedCard[1].GetComponent<Card>().template.cardSuit)
            {
                CardManager.instance.selectedCard[0].transform.position = CardManager.instance.selectedCard[1].transform.GetChild(0).transform.position;
                CardManager.instance.selectedCard[0].transform.rotation = CardManager.instance.selectedCard[1].transform.GetChild(0).transform.rotation;
                CardManager.instance.selectedCard[0].GetComponent<Card>().isChanged = true;
            }
            else
            {
                Debug.Log("They aren't equal!");
            }

            CardManager.instance.selectedCard.Clear();
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

    bool isAvailableToPlay(GameObject gameObject)
    {

        return false;
    }
}
