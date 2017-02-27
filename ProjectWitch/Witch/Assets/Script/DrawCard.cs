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
        while (Hand.childCount < 5)
        {
            type = (CardType)Random.Range(0, (int)CardType.CARD4 + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.transform.SetParent(Hand);
        }
    }	
}
