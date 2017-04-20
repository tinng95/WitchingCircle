using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {
    public GameObject optionMenu;
    public GameObject volumeMixerMenu;
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
        if (volumeMixerMenu.activeInHierarchy)
        {
            volumeMixerMenu.SetActive(false);
        }
        fadeScreen.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(false);
    }

    void openOptionMenu()
    {
        fadeScreen.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(true);
    }
}
