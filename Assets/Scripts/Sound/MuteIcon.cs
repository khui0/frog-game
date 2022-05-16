using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteIcon : MonoBehaviour
{
    public Image image;

    public Sprite muted;
    public Sprite unmuted;

    // Start is called before the first frame update
    void Start()
    {
        if (MuteAudio.isAudioMuted)
        {
            image.sprite = muted;
        }
        else
        {
            image.sprite = unmuted;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
