using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DrawCard : MonoBehaviour {

    public enum CardType
    {
        CARD1,
        CARD2,
        CARD3,
        CARD4
    }

    public  GameObject[] Cards;
    public Transform Hand = null;

    private GameObject CardClone;
    private CardType type;

    public void getCard()
    {
        StartCoroutine(DoSomething(0.3f));
    }
    IEnumerator DoSomething(float seconds)
    {
        for (int i = Hand.childCount; i < 5; i++)
        {
            type = (CardType)Random.Range(0, (int)CardType.CARD4 + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.GetComponent<Draggable>().updateToTrueIsDragable();
            CardClone.transform.SetParent(Hand);

            Debug.Log("The card is: " + i);
            yield return new WaitForSeconds(seconds);
        }
    }
}
