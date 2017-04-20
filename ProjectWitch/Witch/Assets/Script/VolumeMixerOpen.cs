using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeMixerOpen : MonoBehaviour {
    public Button Volume;
    public Button Back;
    public GameObject VolumeMixer;
    public GameObject Parent;
	// Use this for initialization
	void Start () {
        VolumeMixer.SetActive(false);
        Volume.onClick.AddListener(openVolumeMixer);
        Back.onClick.AddListener(returnToParent);
    }

    void returnToParent()
    {
        VolumeMixer.SetActive(false);
        Parent.SetActive(true);
    }
    void openVolumeMixer()
    {
        Parent.SetActive(false);
        VolumeMixer.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
