using UnityEngine;
using System.Collections;

public class MonsterStats : MonoBehaviour{

    public int counter;
    public int health;
    public string NAME;

    private int pCounter;
    private int pHealth;
    private string pName;
    public void setMonster()
    {
        this.pCounter = counter;
        this.pHealth = health;
        this.pName = NAME;
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

    public string getName() { return pName; }
    public int getHealth() { return pHealth; }
    public int getCounter() { return pCounter; }
}
