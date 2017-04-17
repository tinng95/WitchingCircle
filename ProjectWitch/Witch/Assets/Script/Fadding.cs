﻿using UnityEngine;
using System.Collections;

public class Fadding : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDept = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDept;
        Debug.Log("INSIDE FADDING");
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float beginFade(int dir)
    {
        fadeDir = dir;
        return fadeSpeed;
    }

    void OnLevelWasLoaded()
    {
        beginFade(-1);
    }
}