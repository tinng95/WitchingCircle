using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DrawCard : MonoBehaviour {

    public enum CardType
    {
        RED,
        BLUE,
        GREEN
    }

    public  GameObject[] Cards;
    public Transform Hand = null;

    private GameObject CardClone;
    private CardType type;

    public void getCard(int numDraw, bool drawState)
    {
        StartCoroutine(DoSomething(0.3f, numDraw, drawState));
    }
    IEnumerator DoSomething(float seconds, int numDraw, bool drawState)
    {
        if (drawState == true)
        {
            for (int i = 0; i < numDraw; i++)
            {
                if (Hand.childCount < 5)
                {
                    type = (CardType)Random.Range(0, (int)CardType.GREEN + 1);
                    CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
                    CardClone.GetComponent<CardStats>().setCard();
                    CardClone.GetComponent<Draggable>().updateToTrueIsDragable();
                    CardClone.transform.SetParent(Hand);
                    Debug.Log("The card is: " + i);
                    yield return new WaitForSeconds(seconds);
                }
            }
        }
        else
        {
            for (int i = 0; i < numDraw; i++)
            {
                if(Hand.childCount < 7)
                {
                    type = (CardType)Random.Range(0, (int)CardType.GREEN + 1);
                    CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
                    CardClone.GetComponent<CardStats>().setCard();
                    CardClone.GetComponent<Draggable>().updateToTrueIsDragable();
                    CardClone.transform.SetParent(Hand);

                    Debug.Log("The card is: " + i);
                    yield return new WaitForSeconds(seconds);
                }
              
            }
        }
       
    }

    public void getSpecificCard(string cardName)
    {
        int cardNum = 0;
        if (cardName == "RED")
        {
            cardNum = 0;
        }
        else if (cardName == "BLUE")
        {
            cardNum = 1;
        }
        else if (cardName == "GREEN")
        {
            cardNum = 2;
        }
        CardClone = Instantiate(Cards[cardNum], transform.position, Quaternion.identity) as GameObject;
        CardClone.GetComponent<CardStats>().setCard();
        CardClone.transform.SetParent(Hand);
    }
}
