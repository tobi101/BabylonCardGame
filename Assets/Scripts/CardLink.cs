using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardLink : MonoBehaviour
{
    public List<Card> linkedCards = new List<Card>();

    private void FixedUpdate()
    {
        if (linkedCards.All(card => card.isChanged == true) || linkedCards.Count == 0)
        {
            gameObject.GetComponent<Card>().isVisible = true;
            gameObject.transform.rotation = Quaternion.Euler(0, -180, -60);
        }
    }
}
