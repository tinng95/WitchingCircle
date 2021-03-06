﻿using UnityEngine;
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
    //private Transform hand;
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
                if (Hand.childCount < 7)
                {
                    type = (CardType)Random.Range(0, (int)CardType.GREEN + 1);
                    //CardClone = Instantiate(Cards[2], transform.position, Quaternion.identity) as GameObject;
                    Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
                    CardClone = Instantiate(Cards[(int)type], position, Quaternion.identity) as GameObject;
                    Debug.Log("NEW CARD POSITON IS: " + CardClone.transform.position);
                    CardClone.GetComponent<CardStats>().setCard();
                    CardClone.GetComponent<Draggable>().updateToTrueIsDragable();
                    CardClone.transform.SetParent(Hand,false);
                    //Debug.Log("The card is: " + i);
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
                    //CardClone = Instantiate(Cards[2], transform.position, Quaternion.identity) as GameObject;
                    Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
                    
                    //Debug.Log("CARD " + i + " position: " + position);
                    CardClone = Instantiate(Cards[(int)type], position, Quaternion.identity) as GameObject;
                    Debug.Log("NEW CARD POSITON IS: " + CardClone.transform.position);
                    CardClone.GetComponent<CardStats>().setCard();
                    CardClone.GetComponent<Draggable>().updateToTrueIsDragable();
                    CardClone.transform.SetParent(Hand, false);

                    //Debug.Log("The card is: " + i);
                    yield return new WaitForSeconds(seconds);
                }
              
            }
        }
       
    }

    
    public void getSpecificCard(string cardName)
    {
        //waitOnSpecificCard(0.3f, cardName);
        //Debug.Log("CURRENT HAND ISSSSS: " + Hand);

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
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        //Debug.Log("NEW CARD POSITON IS: " + position);
        CardClone = Instantiate(Cards[cardNum], position, Quaternion.identity) as GameObject;
        CardClone.GetComponent<CardStats>().setCard();
        CardClone.transform.SetParent(Hand, false);
    }


    IEnumerator waitOnSpecificCard(float seconds, string cardName)
    {

        yield return new WaitForSeconds(seconds);
        
    }
}
