using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused;

    public GameObject pauseMenu;
    public GameObject endMenu;

    public PlayerInfo playerInfo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ExitGame()
    {
        playerInfo.SetHighscore();
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.isGamePaused = false;
        SceneManager.LoadScene(2);
    }
}
