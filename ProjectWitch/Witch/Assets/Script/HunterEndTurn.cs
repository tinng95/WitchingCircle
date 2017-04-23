using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HunterEndTurn : MonoBehaviour {

    public GameObject Board;
    public GameObject ToolTips;
    public Text Message;

    public void damageCheck()
    {
        Debug.Log("Num Card: " + Board.transform.childCount);
        if (Board.transform.childCount <= 1)
        {
            Message.text = "Deal " + Board.transform.childCount + " Damage";
        }
        else
        {
            Message.text = "Deal " + Board.transform.childCount + " Damages";
        }
    }


}
