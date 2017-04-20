using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public void loadScene()
    {
        StartCoroutine(doTemp(sceneName));
    }

    IEnumerator doTemp(string name)
    {
        float fadeTime = GameObject.Find("FadeScreen").GetComponent<Fadding>().beginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }
}