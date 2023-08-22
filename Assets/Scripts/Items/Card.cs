using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public CardTemplate template;

    public bool isVisible = true;
    public bool isChanged = false;

    public Card(CardTemplate template)
    {
        this.template = template;

        if (!(template is CardTemplate))
        {
            Debug.LogWarning("Template is not CardTemplate");
        }
    }

    public static Card CreateCard(CardTemplate template) 
    {
        if (template == null)
        {
            Debug.LogWarning("CardTemplate is null!");
            return null;
        }

        return new Card(template);
    }
}
