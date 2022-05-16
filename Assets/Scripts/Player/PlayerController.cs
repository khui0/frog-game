using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource deathSound;

    public PlayerInfo playerInfo;

    public Animator animator;

    public Transform frog;

    public GroundCheck groundCheck;

    public float jumpAmount = 15f;

    public AudioSource jumpSound;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            Vector3 move = transform.up * jumpAmount + (transform.forward * jumpAmount);

            if (Input.GetButton("Jump") && Input.GetKey(KeyCode.LeftShift) && groundCheck.isGrounded)
            {
                GetComponent<Rigidbody>().velocity = move * 1.5f;
                PlayJumpSound();
                animator.SetBool("isJumpHeld", true);
            }
            else if (Input.GetButton("Jump") && groundCheck.isGrounded)
            {
                GetComponent<Rigidbody>().velocity = move;
                PlayJumpSound();
                animator.SetBool("isJumpHeld", true);
            }
            else
            {
                animator.SetBool("isJumpHeld", false);
            }

            CheckPlayerHeight();
        }
    }

    void CheckPlayerHeight()
    {
        if (transform.position.y < -10)
        {
            Debug.Log("Fell into void");
            PlayDeathSound();
            playerInfo.KillPlayer();
        }
    }

    void PlayJumpSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            jumpSound.Play();
        }
    }

    void PlayDeathSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            deathSound.Play();
        }
    }
}
