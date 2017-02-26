using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour {

    public GameObject OFF;
    public GameObject ON;

    public bool isButtonActive = false;

    public void updateToOn()
    {
        Debug.Log("Button turing ON");
        ON.SetActive(true);
        OFF.SetActive(false);
        isButtonActive = true;
    }
    public void updateToOff()
    {
        Debug.Log("Button turing OFF");
        ON.SetActive(false);
        OFF.SetActive(true);
        isButtonActive = false;
    }

    public bool getIsButtonActive()
    {
        Debug.Log("current Status: " + isButtonActive);
        return isButtonActive;
    }
    
}
