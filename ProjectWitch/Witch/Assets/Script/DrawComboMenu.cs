using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawComboMenu : MonoBehaviour {

    public GameObject cardMenu;

    public Button backButton;
    public Button cardButton;
    public Button fadeScreen;

    // Use this for initialization
    void Start () {
        //fadeScreen.gameObject.SetActive(false);
        cardMenu.gameObject.SetActive(false);
        cardButton.onClick.AddListener(openCardMenu);
        fadeScreen.onClick.AddListener(hideCardMenu);
        backButton.onClick.AddListener(hideCardMenu);
    }
	
	void openCardMenu()
    {
        fadeScreen.gameObject.SetActive(true);
        cardMenu.gameObject.SetActive(true);
    }

    void hideCardMenu()
    {
        fadeScreen.gameObject.SetActive(false);
        cardMenu.gameObject.SetActive(false);
    }
}
