using UnityEngine;
using System.Collections;

public class SpawnMonster : MonoBehaviour {

    public enum CardType
    {
        ELITE,
        HIGHMANE,
        DEATHWING,
        NZOTH
    }
    public GameObject[] Cards;
    public Transform MonsterBoard = null;

    private GameObject CardClone;
    private CardType type;

    public void getCard()
    {
        StartCoroutine(DoSomething(0.5f));
    }

    IEnumerator DoSomething(float seconds)
    {
        while (MonsterBoard.childCount < 1)
        {
            yield return new WaitForSeconds(seconds);
            type = (CardType)Random.Range(0, (int)CardType.ELITE + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.GetComponent<MonsterStats>().setMonster();
            CardClone.GetComponent<CardTextModifier>().setData(
                CardClone.GetComponent<MonsterStats>().getHealth(), CardClone.GetComponent<MonsterStats>().getCounter());
            CardClone.transform.SetParent(MonsterBoard, false);
        }
    }

    public void getSpecificCard(string cardName)
    {

        int cardNum = 0;
        if (cardName == "RANDOM")
        {
            cardNum = Random.Range(0, 2);
        }
        else if (cardName == "DEATHWING")
        {
            cardNum = 2;
        }
        else if (cardName == "NZOTH")
        {
            cardNum = 3;
        }

        Debug.Log("BEGIN");
        CardClone = Instantiate(Cards[cardNum], transform.position, Quaternion.identity) as GameObject;
        CardClone.GetComponent<MonsterStats>().setMonster();
        CardClone.GetComponent<CardTextModifier>().setData(
                CardClone.GetComponent<MonsterStats>().getHealth(), CardClone.GetComponent<MonsterStats>().getCounter());
        CardClone.transform.SetParent(MonsterBoard, false);
        Debug.Log("END");
    }
}
