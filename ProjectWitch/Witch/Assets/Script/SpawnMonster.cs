using UnityEngine;
using System.Collections;

public class SpawnMonster : MonoBehaviour {

    public enum CardType
    {
        DEATHWING,
        ELITE
    }
    public GameObject[] Cards;
    public Transform MonsterBoard = null;

    private GameObject CardClone;
    private CardType type;

    public void getCard()
    {
        StartCoroutine(DoSomething(0.5f));
        /*
        while (MonsterBoard.childCount < 1)
        {
            type = (CardType)Random.Range(0, (int)CardType.ELITE + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.GetComponent<MonsterStats>().setMonster();
            Debug.Log("This new Monster health is: " + CardClone.GetComponent<MonsterStats>().getHealth());
            CardClone.transform.SetParent(MonsterBoard);
        }
        */
    }

    IEnumerator DoSomething(float seconds)
    {
        while (MonsterBoard.childCount < 1)
        {
            yield return new WaitForSeconds(seconds);
            type = (CardType)Random.Range(0, (int)CardType.ELITE + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.GetComponent<MonsterStats>().setMonster();
            Debug.Log("This new Monster health is: " + CardClone.GetComponent<MonsterStats>().getHealth());
            CardClone.transform.SetParent(MonsterBoard);
        }
        /*
        for (int i = Hand.childCount; i < 5; i++)
        {
            type = (CardType)Random.Range(0, (int)CardType.CARD4 + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.GetComponent<Draggable>().updateToTrueIsDragable();
            CardClone.transform.SetParent(Hand);

            Debug.Log("The card is: " + i);
            yield return new WaitForSeconds(seconds);
        }
        */
    }
}
