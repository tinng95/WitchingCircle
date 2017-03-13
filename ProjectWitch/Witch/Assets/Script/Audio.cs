using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {

    public AudioClip test;

    // Use this for initialization
    IEnumerator Start () {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = test;
        audio.Play();

        Debug.Log("went in AUDIO!");
    }
	

}
