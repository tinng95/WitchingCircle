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
        
        for (int i = Hand.childCount; i < 5; i++)
        {
            type = (CardType)Random.Range(0, (int)CardType.CARD4 + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            //CardClone.SetActive(false);
            CardClone.transform.SetParent(Hand);
        }
        
        //Debug.Log("SET CARD 0 INACTIVE");
        //Hand.transform.GetChild(0).GetComponent<GameObject>().SetActive(false);
        //Debug.Log("BEFORE DOSOMETHING");
       // StartCoroutine(DoSomething(0.5f));
        //Debug.Log("AFTER DOSOMETHING");
    }
    IEnumerator DoSomething(float seconds)
    {
        //Debug.Log("TOTAL HAND CARD IS " + Hand.childCount);
        for (int i = Hand.childCount; i < 5; i++)
        {
            type = (CardType)Random.Range(0, (int)CardType.CARD4 + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.transform.SetParent(Hand);
            Debug.Log("The card is: " + i);
            yield return new WaitForSeconds(seconds);
        }
       // Debug.Log("SHOULD ONLY OUTPUT 1!");
    }
}
