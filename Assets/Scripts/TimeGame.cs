using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeGame : MonoBehaviour
{
    public float timeStart = 400;
    public TextMeshProUGUI timerText;
    private bool musicPlay = false;
    private GameObject player;
    public AudioClip audioClip;
    private AudioSource audioSource;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        timerText.text = timeStart.ToString();
    }

    void Update()
    {
        timeStart -= (Time.deltaTime) * 2;
        timerText.text = "Time: " + Mathf.Round(timeStart).ToString();
        if (timeStart < 10 && musicPlay == false)
        {
            audioSource.PlayOneShot(audioClip);
            musicPlay = true;
        }
    }
    public void ResetTime()
    {
        timeStart = 400;
    }
}
