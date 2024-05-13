
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int coins { get; private set; }

    public int star { get; private set; }
    public int goomba { get; private set; }
    public int koopa { get; private set; }
    public int mushroom { get; private set; }

    public int score { get; private set; }

    public bool isGameOver;
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDetroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        NewGame();

        //AudioManager.instance.Play("Main music");
    }

  
    public void NewGame()
    {
        ResetScore();
        SetScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;



        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void Restart()
    {
        
        NewGame();
        LoadLevel(this.world, this.stage);
    }

    public void NextLevel()
    {
        this.world = world;
        this.stage = stage;
        if(world == 2 && stage == 3)
        {
            SceneManager.LoadScene("EndGame");
            AudioManager.instance.Play("LevelComplete");
            Invoke(nameof(BackToMainMenu), 7f);

        }
        else
        {
            if (stage + 1 == 4)
            {
                LoadLevel(world + 1, 1);
            }
            else
            {
                LoadLevel(world, stage + 1);
            }
        }
       
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;
        if (lives > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        ResetScore();
        isGameOver = true;
        SceneManager.LoadScene("Gameover");
        AudioManager.instance.Play("Game over");
        Invoke(nameof(BackToMainMenu), 6f);
    }

    private void BackToMainMenu()
    {
        ResetScore();
        isGameOver = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void AddCoin()
    {
        coins++;
        if (coins == 100)
        {
            AddLife();
            coins = 0;
        }

        AudioManager.instance.Play("Coin");
    }

    public void AddLife()
    {
         lives++;
          AudioManager.instance.Play("1_up");
    }

    public void AddMushroom()
    {
        mushroom++;
    }

    public void AddStar()
    {
        star++;
    }

    public void AddGoomba()
    {
        goomba++;
    }

    public void AddKoopa()
    {
        koopa++;
    }

    public void ResetScore()
    {
        lives = 3;
        coins = 0;
        star = 0;
        mushroom = 0;
        goomba = 0;
        koopa = 0;
        score = 0;
    }


    public void SetScene(int scene)
    {
        if (scene % 3== 0)
        {
            this.world = scene / 3;
            this.stage = 3;
        }
        else
        {
            this.world = scene / 3 + 1;
            this.stage = scene % 3;
        }
    }
}