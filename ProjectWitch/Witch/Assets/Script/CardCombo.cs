﻿using UnityEngine;
using System.Collections;

public class CardCombo : MonoBehaviour {


    public GameObject Board = null;
    public GameObject Hand = null;
    public GameObject MonsterArea = null;
    public GameObject PopUp = null;
    private GameObject board;
    private GameObject hand;
    private GameObject monsterArea;
    public enum CardType
    {
        RED,
        BLUE,
        GREEN
    }

    public void setCombo()
    {
        this.board = Board;
        this.hand = Hand;
        this.monsterArea = MonsterArea;
        //this.discover = PopUp;
    }

    public void comboCheck () {
        int redCount = 0;
        int greenCount = 0;
        int blueCount = 0;
        string temp;
        for (int i = 0; i< board.transform.childCount; i++)
        {
            temp = board.transform.GetChild(i).GetComponent<CardStats>().getName();

            if (temp == "BLUE")
            {
                blueCount++;
            }
            else if (temp == "RED")
            {
                redCount++;
            }
            else if (temp == "GREEN")
            {
                greenCount++;
            }
        }

        //COMBO
        //BB  draw 3 card instancely
        if (blueCount == 2)
        {
            Debug.Log("2 BLUE IN!!!");
            hand.GetComponent<DrawCard>().getCard(3, false);
            Debug.Log("2 BLUE OUT!!!");
        } 
        //RR  deal 3 dmg instancely
        else if (redCount == 2)
        {
            for (int i = 0; i < MonsterArea.transform.childCount; i++)
            {
                monsterArea.transform.GetChild(i).GetComponent<MonsterStats>().minusHealth(3);
                monsterArea.transform.GetChild(i).GetComponent<CardTextModifier>().updateCardData();
            }
        }
        //GG convert all left over GREEN card in hand to w/e Color you want, right now just to RED
        else if (greenCount == 2)
        {
            PopUp.GetComponent<DiscoverCard>().chooseCard("BLUE", "RED");
            //cardConversion("GREEN", "RED");
        }
        //GB All BLUE TO GREEN
        else if (greenCount == 1 && blueCount == 1)
        {
            PopUp.GetComponent<DiscoverCard>().chooseCard("RED", "GREEN");
            //cardConversion("BLUE", "GREEN");
        }
        //GR All RED TO GREEN
        else if (greenCount == 1 && redCount == 1)
        {
            PopUp.GetComponent<DiscoverCard>().chooseCard("BLUE", "GREEN");
            //cardConversion("RED", "GREEN");
        }
        //BR
        else if (blueCount == 1 && redCount == 1)
        {
            for (int i = 0; i < MonsterArea.transform.childCount; i++)
            {
                monsterArea.transform.GetChild(i).GetComponent<MonsterStats>().minusHealth(2);
                monsterArea.transform.GetChild(i).GetComponent<CardTextModifier>().updateCardData();
                hand.GetComponent<DrawCard>().getCard(1, false);
            }
        }
    }

    public void cardConversion(string currentCard, string newCard)
    {
        int currentType = 0;
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            if (hand.transform.GetChild(i).GetComponent<CardStats>().getName() == currentCard)
            {
                currentType++;
            }
        }
        for (int i = 0; i < hand.transform.childCount; i++)
        {

            if (hand.transform.GetChild(i).GetComponent<CardStats>().getName() == currentCard)
            {
                Destroy(hand.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < currentType; i++)
        {
            hand.GetComponent<DrawCard>().getSpecificCard(newCard);
        }
    }

}
