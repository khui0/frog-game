using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text timeText;

    public float gameTime;

    [HideInInspector]
    public int min;
    [HideInInspector]
    public int sec;

    // Update is called once per frame
    void Update()
    {
        min = Mathf.FloorToInt(gameTime / 60);
        sec = Mathf.FloorToInt(gameTime % 60);
        gameTime += Time.deltaTime;

        timeText.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
