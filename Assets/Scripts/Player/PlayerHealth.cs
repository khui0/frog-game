using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioSource hitSound;

    public PlayerInfo playerInfo;

    public HealthBar healthBar;

    public float maxPlayerHealth = 20f;
    public float currentPlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerHealth <= 0f)
        {
            Debug.Log("Player died");
            PlayDeathSound();
            playerInfo.KillPlayer();
        }

        if (currentPlayerHealth > 0 && currentPlayerHealth < maxPlayerHealth)
        {
            AddHealth(1f * Time.deltaTime);
        }
    }

    public void ResetHealth()
    {
        currentPlayerHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
    }

    public void TakeDamage(float damage)
    {
        PlayHitSound();

        currentPlayerHealth -= damage;

        healthBar.SetHealth(currentPlayerHealth);
    }

    public void AddHealth(float health)
    {
        currentPlayerHealth += health;

        healthBar.SetHealth(currentPlayerHealth);
    }

    void PlayDeathSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            deathSound.Play();
        }
    }

    void PlayHitSound()
    {
        if (!MuteAudio.isAudioMuted)
        {
            hitSound.Play();
        }
    }
}
