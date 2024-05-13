using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int scoreStart = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            scoreStart = GameManager.Instance.coins * 100 + GameManager.Instance.star * 1000 + GameManager.Instance.mushroom * 1000 + GameManager.Instance.koopa * 400 + GameManager.Instance.goomba * 200;
            scoreText.text = "Score:" + scoreStart.ToString();
        }
        else
        {
            scoreText.text = "Score: 0"; 
        }
    }



}
