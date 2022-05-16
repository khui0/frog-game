using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    GameObject gameManager;

    public AudioSource deathSound;
    public AudioSource hitSound;

    public HealthBar healthBar;

    public float maxEnemyHealth = 20f;
    public float currentEnemyHealth;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        healthBar.SetMaxHealth(maxEnemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyHealth <= 0f)
        {
            PlayDeathSound();
            killEnemy();
        }
    }

    public void TakeDamage(float damage)
    {
        PlayHitSound();

        currentEnemyHealth -= damage;

        healthBar.SetHealth(currentEnemyHealth);
    }

    void killEnemy()
    {
        Destroy(gameObject);
        gameManager.GetComponent<SpawnEnemy>().spawnedEnemies.Remove(gameObject);
        gameManager.GetComponent<PlayerInfo>().AddCoins(10);
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
