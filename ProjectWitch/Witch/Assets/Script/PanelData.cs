using UnityEngine;
using System.Collections;

public class PanelData: MonoBehaviour{
    public GameObject currentPanel;

    public int totalCard { get; set; }
    public int redCard { get; set; }
    public int blueCard { get; set; }
    public int greenCard { get; set; }

    public void updateCardPanelData()
    {
        totalCard = 0;
        redCard = 0;
        blueCard = 0;
        greenCard = 0;
        for (int i = 0; i < currentPanel.transform.childCount; i++)
        {
            Debug.Log(" THIS CARD IS: " + currentPanel.transform.GetChild(i).GetComponent<CardStats>().getName());
            if(currentPanel.transform.GetChild(i).GetComponent<CardStats>().getName() == "RED")
            {
                redCard++;
            }
            else if (currentPanel.transform.GetChild(i).GetComponent<CardStats>().getName() == "GREEN")
            {
                blueCard++;
            }
            else if (currentPanel.transform.GetChild(i).GetComponent<CardStats>().getName() == "BLUE")
            {
                greenCard++;
            }
            totalCard++;
        }
    }
}
