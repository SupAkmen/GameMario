using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuEvent : MonoBehaviour
{
    public void Scenes(int scene)
    {
        SceneManager.LoadScene(scene);
        if(GameManager.Instance != null)
        {
            GameManager.Instance.SetScene(scene);
        }    
    }    

    public void StartGame()
    {
        GameManager.Instance.NewGame();
    }    

    public void Quit()
    {
        Application.Quit();
    }
}
