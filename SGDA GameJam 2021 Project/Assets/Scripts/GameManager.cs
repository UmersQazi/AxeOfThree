using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject timeUpText;
    
    public GameObject title;
    public bool gameOver;
    public PlayerController player;
    public float score = 0;
    static public float highscore = 0;

    private Animator anim;



    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject timerSprite;

    public GameObject manualButton;
    public GameObject page1;
    public GameObject page2;
    public GameObject exitButton;
  

    public float timer = 60f;

    public GameObject retryButton;
    public GameObject startButton;
    public bool isGameActive;

    public bool canPlay;

    public GameObject[] huds;
    public int index=0;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        canPlay = false;
        TitleScreen();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        anim = timerSprite.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (canPlay)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && !gameOver)
            {
                timeUpText.SetActive(true);
                gameOver = true;
                retryButton.SetActive(true);
                canPlay = false;
                
            }
        }

        scoreText.text = "" + score;
        highScoreText.text = "" + highscore;
        if (highscore < score)
        {
            highscore = score;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            index++;
            if(index > 2)
            {
                index = 0;
            }
        }
        if(index == 0)
        {
            huds[index].SetActive(true);
            huds[1].SetActive(false);
            huds[2].SetActive(false); 
        }else if(index == 1)
        {
            huds[index].SetActive(true);
            huds[0].SetActive(false);
            huds[2].SetActive(false); 
        }else if(index == 2)
        {
            huds[index].SetActive(true);
            huds[1].SetActive(false);
            huds[0].SetActive(false); 
        }

        if(player.health == 0)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            retryButton.SetActive(true);
            canPlay = false;
            

        }

        if (gameOver || !canPlay)
        {
            anim.SetBool("canTime", false);
        }
        
    }

    public void TitleScreen()
    {
        startButton.SetActive(true);
        title.SetActive(true);
    }

    public void StartGame()
    {
        isGameActive = true;
        title.SetActive(false);
        startButton.SetActive(false);
        canPlay = true;
        anim.SetBool("canTime", true);
        gameOver = false;
        manualButton.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Instructions()
    {
        page1.SetActive(true);
        page2.SetActive(true);
        title.SetActive(false);
        startButton.SetActive(false);
        manualButton.SetActive(false);
        exitButton.SetActive(true);
    }

    public void ExitManual()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
