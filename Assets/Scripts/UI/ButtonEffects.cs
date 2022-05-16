using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    public void mouseEnterEffect()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1);
    }

    public void mouseExitEffect()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
