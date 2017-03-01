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
        StartCoroutine(DoSomething(1.5f));
    }

    IEnumerator DoSomething(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.SetActive(false);
        isVisible = false;
    }

}
