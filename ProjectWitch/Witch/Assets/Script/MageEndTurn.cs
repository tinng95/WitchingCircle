using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MageEndTurn : MonoBehaviour {

    public GameObject Board;
    public GameObject OnButton;
    public GameObject OffButton;
    public GameObject ToolTips;
    public Text Message;


    //private bool isButtonActive = false;

    public void checkHand()
    {
        Board.GetComponent<CardCombo>().comboCheck();
        if (Board.transform.childCount == 2)
        {
            //Debug.Log("COMBO READY!!!!");
            Message.text = Board.GetComponent<CardCombo>().getComboName();
            OnButton.SetActive(true);
            OffButton.SetActive(false);
        }
        else
        {
            Debug.Log("COMBO NOT READY!!!!");
            //OnButton.SetActive(false);
            //OffButton.SetActive(true);
        }
    }
}
