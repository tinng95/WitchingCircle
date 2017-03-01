using UnityEngine;
using System.Collections;

public class CardStats : MonoBehaviour
{
    public string Name;

    private string pName;

    public void setCard()
    {
        this.pName = Name;
    }

    public void setName(string Name)
    {
        this.pName = name;
    }
    public string getName()
    {
        return pName;
    }

}
