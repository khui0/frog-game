using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public static bool isAudioMuted;

    public Image image;

    public Sprite muted;
    public Sprite unmuted;

    public void ToggleMute()
    {
        isAudioMuted = !isAudioMuted;
        if (isAudioMuted)
        {
            image.sprite = muted;
        }
        else
        {
            image.sprite = unmuted;
        }
    }
}
