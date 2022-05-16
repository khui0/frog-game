using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int groundLayer;

    public int enemyColliderLayer;

    [HideInInspector]
    public bool isGrounded;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == groundLayer)
        {
            isGrounded = other.gameObject.layer == groundLayer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == groundLayer)
        {
            isGrounded = other.gameObject.layer == groundLayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
