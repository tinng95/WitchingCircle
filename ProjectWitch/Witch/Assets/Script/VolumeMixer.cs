using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour {

    public Slider VolumeSlider;

    void Start()
    {
       
    }

    public void Update()
    {
        //Displays the value of the slider in the console.
        AudioListener.volume = VolumeSlider.value;
    }
}
