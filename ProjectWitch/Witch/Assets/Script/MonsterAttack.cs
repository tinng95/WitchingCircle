using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterAttack : MonoBehaviour {

    public GameObject MonsterArea;
    public GameObject Hand;
    public bool isDestroyed = false;
    int turn = 3;
    public void attack()
    {
        for (int i = 0; i < MonsterArea.transform.childCount; i++)
        {
            if (MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getAbilityCode() == 0)
            {
                Debug.Log("DO NOTHING!");
                isDestroyed = true;
            }
            else if (MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getAbilityCode() == 1)
            {
                StartCoroutine(discardCard(1.0f));
                
                Debug.Log("DISCARD A CARD");
            }
            else if (MonsterArea.transform.GetChild(i).GetComponent<MonsterStats>().getAbilityCode() == 2)
            {
                if (turn > 1)
                {
                    turn--;
                    MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateDiscard(turn);
                    Debug.Log("TIMER TURN " + turn);
                    isDestroyed = true;
                }
                else
                {
                    StartCoroutine(discardNTurn(1.0f));
                    turn = 3;
                    MonsterArea.transform.GetChild(0).GetComponent<CardTextModifier>().updateDiscard(turn);
                }
               

               
            }
        }
    }


    IEnumerator discardCard(float seconds)
    {
        if(Hand.transform.childCount > 0)
        {
            int temp = Random.Range(0, Hand.transform.childCount);
            Debug.Log("Should detele CARD: " + temp);
            Destroy(Hand.transform.GetChild(temp).gameObject);
        }
        yield return new WaitForSeconds(seconds);
        isDestroyed = true;
    }

    IEnumerator discardNTurn(float seconds)
    {
        if (Hand.transform.childCount > 0)
        {
            for(int i = 0; i < Hand.transform.childCount; i++)
            {
                Destroy(Hand.transform.GetChild(i).gameObject);
            }

        }
        yield return new WaitForSeconds(seconds);
        isDestroyed = true;
    }
}
