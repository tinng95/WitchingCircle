using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour {

    public Text winLose;
    public Button YES;
    public Button NO;
    public void setCondition(string condition)
    {
        winLose.text = condition;
    }

    public void pick()
    {
        YES.onClick.AddListener(clickYES);
        NO.onClick.AddListener(clickNO);
    }

    public void clickYES()
    {
        Debug.Log("REPLAY!");
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    public void clickNO()
    {
        Debug.Log("THANK YOU FOR PLAYING, NOT YET IMPLEMENT NO BUTTON!!!");
    }
}
