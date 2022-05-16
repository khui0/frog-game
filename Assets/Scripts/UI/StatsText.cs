using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStatsText();
    }

    string SecondsToTime(float seconds)
    {
        int min = Mathf.FloorToInt(seconds / 60);
        int sec = Mathf.FloorToInt(seconds % 60);

        return min.ToString("00") + ":" + sec.ToString("00");
    }

    void UpdateStatsText()
    {
        text.text = "Most time: " + SecondsToTime(PlayerInfo.playerBestTime) + "\nHighest wave: " + PlayerInfo.playerBestWave;
    }
}
