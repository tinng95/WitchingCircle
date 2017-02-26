using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public bool isVisible = false;
    public GameObject player;

    public void Start()
    {
        player.SetActive(false);
    }
    public void playerAttack()
    {
        player.SetActive(true);
        isVisible = true;
        StartCoroutine(DoSomething(3.0f));
    }

    IEnumerator DoSomething(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("waited Success");
        player.SetActive(false);
        isVisible = false;
    }

}
