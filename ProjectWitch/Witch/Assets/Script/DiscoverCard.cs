﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DiscoverCard : MonoBehaviour {

    public GameObject PopUp = null;
    public GameObject Board = null;

    public Button leftCard;
    public Button rightCard;
    private GameObject popUp;
    private bool isDisUp = false;

    void Start()
    {
        popUp = PopUp;
        popUp.SetActive(false);
    }

    public void chooseCard(string left, string right)
    {
        popUp.SetActive(true);
        if (isDisUp == false)
        {
            isDisUp = true;
            
            popUp.GetComponent<DrawCard>().getSpecificCard(left);
            popUp.GetComponent<DrawCard>().getSpecificCard(right);
        }

        leftCard = popUp.transform.GetChild(0).GetComponent<Button>();
        rightCard = popUp.transform.GetChild(1).GetComponent<Button>();

        leftCard.interactable = true;
        rightCard.interactable = true;

        //GG GREEN TO BLUE OR RED
        if(left == "BLUE" && right == "RED")
        {
            leftCard.onClick.AddListener(delegate { TaskOnClick(left, "GREEN"); });
            rightCard.onClick.AddListener(delegate { TaskOnClick(right, "GREEN"); });
        }
        //BG all blue to RED OR GREEN
        else if (left == "RED" && right == "GREEN")
        {
            leftCard.onClick.AddListener(delegate { TaskOnClick(left, "BLUE"); });
            rightCard.onClick.AddListener(delegate { TaskOnClick(right, "BLUE"); });
        }
        //RG all blue to BLUE OR GREEN
        else if (left == "BLUE" && right == "GREEN")
        {
            leftCard.onClick.AddListener(delegate { TaskOnClick(left, "RED"); });
            rightCard.onClick.AddListener(delegate { TaskOnClick(right, "RED"); });
        }
    }
    void TaskOnClick(string cardPick, string cardDiscard)
    {
        //Debug.Log("WILL REPLACE " + cardDiscard + " with " + cardPick);
        Board.GetComponent<CardCombo>().cardConversion(cardDiscard, cardPick);
        for (int i = 0; i < popUp.transform.childCount; i++)
        {
            Destroy(popUp.transform.GetChild(i).gameObject);
        }
        popUp.SetActive(false);
        isDisUp = false;
    }

    public bool getIsDisUp()
    {
        return isDisUp;
    }
}