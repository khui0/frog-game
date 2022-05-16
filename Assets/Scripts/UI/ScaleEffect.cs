using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    // I have no idea how this works
    public float speed = 4f;
    public float divisor = 20f;
    public float offset = 1f;

    void Update()
    {
        float scale = (Mathf.Sin(Time.time * speed) / divisor) + offset;
        GetComponent<RectTransform>().localScale = new Vector3(scale, scale, 1);
    }
}
