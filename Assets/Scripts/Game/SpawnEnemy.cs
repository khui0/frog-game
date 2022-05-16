using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<GameObject> spawnedEnemies;

    public GameManager gameManager;

    public Transform spawnLocation;

    public Text waveText;

    [HideInInspector]
    public int currentWave;

    public float mapRange = 200f;

    void Update()
    {
        if (spawnedEnemies.Count == 0 && !PauseMenu.isGamePaused)
        {
            currentWave++;
            waveText.text = "Wave " + currentWave;
            spawnWave();
        }
    }

    void spawnWave()
    {
        for (int i = 0; i < currentWave * 3; i++)
        {
            bool hasCollision;

            do
            {
                float x = Random.Range(-mapRange / 2, mapRange / 2);
                float z = Random.Range(-mapRange / 2, mapRange / 2);

                spawnLocation.position = new Vector3(x, gameManager.spawnHeight, z);

                hasCollision = Physics.CheckSphere(spawnLocation.position, 3f);
            }
            while (hasCollision);

            GameObject enemy =  Instantiate(enemyPrefab, spawnLocation.position, Quaternion.identity);
            spawnedEnemies.Add(enemy);
        }
    }
}
