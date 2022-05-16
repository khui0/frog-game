using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    GameObject playerCamera;

    private void Awake()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + playerCamera.transform.forward);
    }
}
