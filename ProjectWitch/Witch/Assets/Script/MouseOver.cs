using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MouseOver : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler{

    public GameObject Button;
    public GameObject ToolTip;
    public GameObject Text;
    void start()
    {
        Debug.Log("GO IN HERE AT LEAST ONCE!!!");
        ToolTip.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTip.SetActive(true);
        //Text.SetActive(true);
        //Debug.Log("GO IN!!!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTip.SetActive(false);
        //Text.SetActive(true);
        //Debug.Log("Go OUT!!!!");
    }
}
