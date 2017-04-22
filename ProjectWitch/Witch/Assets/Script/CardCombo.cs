using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    //string comboText;
    int redCount = 0;
    int greenCount = 0;
    int blueCount = 0;
    public void setCombo()
    {
        this.board = Board;
        this.hand = Hand;
        this.monsterArea = MonsterArea;
        //this.discover = PopUp;
    }

    public void comboCheck () {
        redCount = 0;
        greenCount = 0;
        blueCount = 0;
        string temp;
        //Debug.Log("CURRENT NUMBER OF CARD IS: " + board.transform.childCount);
        for (int i = 0; i< board.transform.childCount; i++)
        {

            
            temp = board.transform.GetChild(i).GetComponent<CardStats>().getName();
            Debug.Log("current card: " + temp);
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
    }

    public string getComboName()
    {

        //COMBO
        //BB  draw 3 card instancely
        if (blueCount == 2)
        {
            return "Draw 3 Cards";
        }
        //RR  deal 3 dmg instancely
        else if (redCount == 2)
        {
            return "Deal 3 Damages";
        }
        //GG convert all left over GREEN card in hand to w/e Color you want, right now just to RED
        else if (greenCount == 2)
        {
            return "Convert GREEN In Hand to RED or BLUE";
        }
        //GB All BLUE TO GREEN
        else if (greenCount == 1 && blueCount == 1)
        {
            return "Convert BLUE In Hand to GREEN or RED";
        }
        //GR All RED TO GREEN
        else if (greenCount == 1 && redCount == 1)
        {
            return "Convert RED In Hand to GREEN or BLUE";
        }
        //BR
        else if (blueCount == 1 && redCount == 1)
        {
            return "Deal 2 Damages, Draw 1 Card";
        }
        else {
            return "ERRROR!!";
        }
    }
    public void comboAction()
    {
        //COMBO
        //BB  draw 3 card instancely
        if (blueCount == 2)
        {
            hand.GetComponent<DrawCard>().getCard(3, false);
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
