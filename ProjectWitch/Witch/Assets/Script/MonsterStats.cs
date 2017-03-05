using UnityEngine;
using System.Collections;

public class MonsterStats : MonoBehaviour{
    public int DiscardCounter;
    public int counter;
    public int health;
    public int AbilityCode;
    public string NAME;
    public string MonsterAbility;

    private int discardCounter;
    private int abilityCode;
    private string monsterAbility;
    private int pCounter;
    private int pHealth;
    private string pName;



    /* MONSTER ABILITY CODE
    0 NO ABILITY
    1 DISCARD A RANDOM CARD
    2 DISCARD PLAYER HAND EVERY n TURNS
    */


    public void setMonster()
    {
        this.discardCounter = DiscardCounter;
        this.pCounter = counter;
        this.pHealth = health;
        this.pName = NAME;
        this.monsterAbility = MonsterAbility;
        this.abilityCode = AbilityCode;
    }
   


    public void addHealth(int health)
    {
        this.pHealth += health;
    }
    public void addCounter(int counter)
    {
        this.pCounter += counter;
    }
    public void minusHealth(int health)
    {
        this.pHealth -= health;
    }
    public void minusCounter(int counter)
    {
        this.pCounter -= counter;
    }


    public void setCounter(int counter)
    {
        this.pCounter = counter;
    }
    public void setHealth(int health)
    {
        this.pHealth = health;
    }
    public void setName(string NAME)
    {
        this.pName = NAME;
    }


    public int getDiscardCounter() { return discardCounter; }
    public string getAbility() { return monsterAbility; }
    public string getName() { return pName; }
    public int getHealth() { return pHealth; }
    public int getAbilityCode() { return abilityCode; }
    public int getCounter() { return pCounter; }
}
