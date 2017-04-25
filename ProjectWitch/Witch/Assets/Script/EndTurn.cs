using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour {

    public GameObject OFF;
    public GameObject ON;
    public GameObject toolTip;
    public bool isButtonActive = true;

    public void updateToOn()
    {
        ON.gameObject.SetActive(true);
        OFF.gameObject.SetActive(false);
        isButtonActive = true;
    }
    public void updateToOff()
    {
        Debug.Log("TRY TO TURN OFF!");
        ON.gameObject.SetActive(false);
        OFF.gameObject.SetActive(true);
        isButtonActive = false;
    }

    public void setIsButtonActiveToTrue()
    {
        isButtonActive = true;
    }

    public void setToolTipOff()
    {
        toolTip.SetActive(false);
    }

    public bool getIsButtonActive()
    {
        return isButtonActive;
    }
    
}
