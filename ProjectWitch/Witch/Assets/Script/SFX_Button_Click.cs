using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SFX_Button_Click : MonoBehaviour {

    public Button Button;
    public AudioClip soundToPlay;
    public float soundVolume;

    public AudioSource source;
    // Use this for initialization
    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
        //source = GetComponent<AudioSource>();
    }

    void TaskOnClick()
    {
        Debug.Log("PLAY PLEASE!");
        source.PlayOneShot(soundToPlay, soundVolume);
    }
}
