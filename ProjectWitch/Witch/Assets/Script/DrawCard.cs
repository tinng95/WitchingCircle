using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DrawCard : MonoBehaviour {

    public GameObject Card = null;
    public Transform Hand = null;
    GameObject CardClone;
    //public GameObject HandDraw = null;
	// Use this for initialization
    public void drawCard()
    {
        Debug.Log("Hand Count is " + Hand.childCount);
        if (Hand.childCount < 5)
        {
            CardClone = Instantiate(Card, transform.position, Quaternion.identity) as GameObject;
            CardClone.transform.SetParent(Hand);
        }
    }	
}
