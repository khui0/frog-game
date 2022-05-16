using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float gravityScale = 5f;
    public static float globalGravity = -9.81f;

    public Rigidbody playerRigidBody;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        playerRigidBody.AddForce(gravity, ForceMode.Acceleration);
    }
}
