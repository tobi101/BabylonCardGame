using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public CardTemplate template;

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
