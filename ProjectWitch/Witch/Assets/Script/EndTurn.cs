using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour {

    public GameObject OFF;
    public GameObject ON;

    public bool isButtonActive = false;

    public void updateToOn()
    {
        ON.SetActive(true);
        OFF.SetActive(false);
        isButtonActive = true;
    }
    public void updateToOff()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        isButtonActive = false;
    }

    public bool getIsButtonActive()
    {
        return isButtonActive;
    }
    
}
