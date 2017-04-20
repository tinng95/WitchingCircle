using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {
    public GameObject optionMenu;
    public Button optionButton;
    public Button fadeScreen;
	// Use this for initialization
	void Start () {
        fadeScreen.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
        optionButton.onClick.AddListener(openOptionMenu);
        fadeScreen.onClick.AddListener(hideOptionMenu);
    }

    void hideOptionMenu()
    {
        fadeScreen.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
    }

    void openOptionMenu()
    {
        fadeScreen.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(true);
    }
}
