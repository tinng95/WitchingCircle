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
            Debug.Log("Hand Count is " + MonsterBoard.childCount);
            type = (CardType)Random.Range(0, (int)CardType.ELITE + 1);
            CardClone = Instantiate(Cards[(int)type], transform.position, Quaternion.identity) as GameObject;
            CardClone.transform.SetParent(MonsterBoard);
        }
    }
}
