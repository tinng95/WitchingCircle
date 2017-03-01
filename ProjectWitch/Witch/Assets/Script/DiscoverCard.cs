using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DiscoverCard : MonoBehaviour {

    public GameObject PopUp = null;
    public Button option1;
    public Button option2;
    private GameObject popUp;
    private bool isDisUp = false;
    void Start()
    {
        popUp = PopUp;
        popUp.SetActive(false);
    }

    public void chooseCard(string card1, string card2)
    {
        popUp.SetActive(true);
        if (isDisUp == false)
        {
            isDisUp = true;
            Debug.Log("WTF!!!");
            popUp.GetComponent<DrawCard>().getSpecificCard(card1);
            popUp.GetComponent<DrawCard>().getSpecificCard(card2);
        }
        

        option1 = popUp.transform.GetChild(0).GetComponent<Button>();
        option2 = popUp.transform.GetChild(1).GetComponent<Button>();
        
        option1.interactable = true;
        option2.interactable = true;
        option1.onClick.AddListener(TaskOnClick);
        option2.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
