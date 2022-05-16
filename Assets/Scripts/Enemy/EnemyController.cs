using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    GameObject player;

    public float jumpAmount = 10f;

    public AudioSource jumpSound;

    public GroundCheck groundCheck;

    public Transform playerCheck;
    float playerDistance;

    [HideInInspector]
    public bool hasSeenPlayer;

    public Transform enemyCamera;

    [HideInInspector]
    public bool attackPlayer;

    public float idleInterval;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 move = transform.up * jumpAmount + (transform.forward * jumpAmount);

        // If player is within 40 units
        if (playerDistance < 40)
        {
            // If player is in line of sight
            if (checkLineOfSight())
            {
                hasSeenPlayer = true;

                // Look in player's direction if grounded
                if (groundCheck.isGrounded)
                {
                    Vector3 targetPostition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                    transform.LookAt(targetPostition);
                }

                // If player is close
                if (playerDistance < 15)
                {
                    attackPlayer = true;
                }
                // If player is far
                else
                {
                    attackPlayer = false;

                    // Regular jump
                    if (groundCheck.isGrounded)
                    {
                        GetComponent<Rigidbody>().velocity = move;
                        PlayJumpSound();
                        animator.SetBool("isJumpHeld", true);
                    }
                    else
                    {
                        animator.SetBool("isJumpHeld", false);
                    }
                }
            }
        }
        // If player is not within 40 units
        else
        {
            hasSeenPlayer = false;

            // Timer
            idleInterval -= Time.deltaTime;
            if (idleInterval <= 0 && groundCheck.isGrounded)
            {
                // Look in random direction
                transform.Rotate(Vector3.up * Random.Range(-45f, 45f));

                // Regular jump
                if (groundCheck.isGrounded)
                {
                    GetComponent<Rigidbody>().velocity = move;
                    PlayJumpSound();
                    animator.SetBool("isJumpHeld", true);
                }
                else
                {
                    animator.SetBool("isJumpHeld", false);
                }

                idleInterval = Random.Range(0f, 5f);
            }
        }
    }

    bool checkLineOfSight()
    {
        playerCheck.LookAt(player.transform);

        RaycastHit hit;

        if (Physics.Raycast(playerCheck.transform.position, playerCheck.transform.forward, out hit))
        {
            return hit.transform.position == player.transform.position;
        }
        else
        {
            return false;
        }
    }
    void PlayJumpSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            jumpSound.Play();
        }
    }
}
