using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardTextModifier : MonoBehaviour {


    public GameObject monster;
    public Text heal = null;
    public Text counter = null;
    public Text ability = null;
    public Text discardCounter = null;
    // Use this for initialization
    
    public void setData(int health, int counter)
    {
        heal.text = health.ToString();
        this.counter.text = counter.ToString();
        this.ability.text = monster.GetComponent<MonsterStats>().getAbility();
    }
	
	public void updateCardData()
    {
        heal.text = monster.GetComponent<MonsterStats>().getHealth().ToString();
        this.counter.text = monster.GetComponent<MonsterStats>().getCounter().ToString();
    }

    public void updateDiscard(int num)
    {
        discardCounter.text = num.ToString();
    }
}
