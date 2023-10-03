using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardLink : MonoBehaviour
{
    public List<GameObject> linkedCards = new List<GameObject>();

    private void FixedUpdate()
    {
        //if (linkedCards.All(card => card.GetComponent<Card>().isChanged == true) || linkedCards.Count == 0)
        //{
        //    if (!gameObject.gameObject.GetComponent<Card>().isVisible)
        //    {
        //        gameObject.GetComponent<Card>().isVisible = true;
        //        gameObject.transform.rotation = Quaternion.Euler(-120, 0, 180);
        //    }
        //}
    }
}
