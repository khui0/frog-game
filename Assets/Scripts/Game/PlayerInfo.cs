using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public GameObject endMenu;

    public GameManager gameManager;

    public PlayerHealth playerHealth;

    public GameTime gameTime;

    public SpawnEnemy spawnEnemy;

    // UI
    public Image[] hearts;
    public Text coinsText;

    // Player stats
    public static int playerBalance;
    public static float playerBestTime;
    public static int playerBestWave;

    // Round info
    [HideInInspector]
    public int playerLives;
    [HideInInspector]
    public int coinsGained;

    // Enemies
    GameObject[] enemy;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        playerLives = hearts.Length;
    }

    public void AddCoins(int coins)
    {
        coinsGained += coins;
        playerBalance += coins;
        coinsText.text = "$" + coinsGained.ToString();
    }

    public void KillPlayer()
    {
        if (playerLives > 1)
        {
            EnemyForgetPlayer();
            playerLives--;
            hearts[playerLives].enabled = false;
            playerHealth.ResetHealth();
            gameManager.ResetPlayerPosition();
        }
        else
        {
            PlayerDeath();
        }
    }
    public void PlayerDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        endMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.isGamePaused = true;
        SetHighscore();
    }

    void EnemyForgetPlayer()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<EnemyController>().hasSeenPlayer = false;
            enemy[i].GetComponent<EnemyController>().attackPlayer = false;
        }
    }

    public void SetHighscore()
    {
        if (gameTime.gameTime > playerBestTime)
        {
            playerBestTime = gameTime.gameTime;
        }
        if (spawnEnemy.currentWave > playerBestWave)
        {
            playerBestWave = spawnEnemy.currentWave;
        }
    }
}
