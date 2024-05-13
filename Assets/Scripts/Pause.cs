using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool pause = false;
    public GameObject pausePanel;

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void BackHome()
    {
        Time.timeScale = 1f;
        GameManager.Instance.NewGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
        Time.timeScale = 1f;
        Resume();
    }
}
