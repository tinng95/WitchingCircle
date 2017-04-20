using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public void loadScene()
    {
        //sceneName = name;
        //SceneManager.LoadScene(name);
        Debug.Log("ENTER");
        StartCoroutine(doTemp(sceneName));
        Debug.Log("OUTER");
    }

    IEnumerator doTemp(string name)
    {
        Debug.Log("sceneName: " + sceneName);
        float fadeTime = GameObject.Find("FadeScreen").GetComponent<Fadding>().beginFade(1);
        // Debug.Log("FADE TIME IS " + fadeTime);
        yield return new WaitForSeconds(fadeTime);
        //Debug.Log("END");
        SceneManager.LoadScene(sceneName);
    }
}