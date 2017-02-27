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
        while (MonsterBoard.childCount < 1)
        {
            type = (CardType)Random.Range(0, (int)CardType.ELITE + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.GetComponent<MonsterStats>().setMonster();
            Debug.Log("This new Monster health is: " + CardClone.GetComponent<MonsterStats>().getHealth());
            CardClone.transform.SetParent(MonsterBoard);
        }
    }
}
