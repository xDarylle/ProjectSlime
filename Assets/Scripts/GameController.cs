using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float timer=0f;
    public GameObject score;
    public Text urscore;
    public Text highscore;
    public Button mute;
    private float _score=0;
    public float duration;

    public Text highscoreTxT;

    public GameObject bg;

    public Sprite[] mute_sprite;

    public GameObject _gameover;
    public GameObject _pause;
    public GameObject pausebtn;
    public GameObject mutebtn;

    public Spawner spawner;
    public DayNight dnController;

    public AudioController audioController;

    public Animator player;

    public CameraScript cam;

    public bool isOver = false;

    private float scale;

    private float secondTimer = 0;

    public Player pl;
    int counter = 0;
    public int count;
    public int end;
    int temp = 10;


    private void Start()
    {
        Application.targetFrameRate = 144;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {

            if (counter < count)
                timer += Time.unscaledDeltaTime;

            if (counter >= count)
                secondTimer += Time.unscaledDeltaTime;

            if (Mathf.Round(timer) == 3 && counter < count)
            {
                Time.timeScale += 0.1f;
                counter++;
                timer = 0f;
            }

            if (Mathf.Round(secondTimer) == temp && counter >= count && counter < end)
            {
                counter++;
                if (counter >= 20)
                {
                    temp = 15;
                }

                if (counter % 2 == 0)
                {
                    spawner.increaseTimeRespawn();
                }


                Time.timeScale += 0.1f;
                secondTimer = 0;
            }

        }
    }

    public void gameover()
    {
        isOver = true;
        audioController.playGameOver();

        StartCoroutine(cam.gameoverShake(0.2f));

        if (_score > PlayerPrefs.GetFloat("highscore"))
        {
            highscoreTxT.text = "NEW HIGHSCORE";
            PlayerPrefs.SetFloat("highscore", Mathf.Ceil(_score));
        } else
        {
            highscoreTxT.text = "HIGHSCORE";
        }

        score.SetActive(false);
        highscore.text = PlayerPrefs.GetFloat("highscore").ToString();
        urscore.text = Mathf.Ceil(_score).ToString();

        mutebtn.SetActive(false);
        pausebtn.SetActive(false);
        StartCoroutine("over");
        PlayerPrefs.Save();
    }

    private IEnumerator over()
    {
        _gameover.SetActive(true);
        bg.SetActive(true);
        //dnController.resetVolumeWeight();
        yield return new WaitForSeconds(duration);
        
        audioController.stopBGM();
        Time.timeScale = 0f;
        
    }

    public void updateScore()
    {
        _score += 0.5f;
            
        score.GetComponent<Text>().text = Mathf.Ceil(_score).ToString();
    }

    public void onPressed()
    {
        isOver = false;
        bg.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pausebtn.SetActive(true);
        _pause.SetActive(false);
        player.updateMode = AnimatorUpdateMode.UnscaledTime;
        Time.timeScale = scale;
        bg.SetActive(false);
        audioController.playBGM();
    }


    public void setpause()
    {
        if (!isOver)
        {
            pausebtn.SetActive(false);
            audioController.pauseBGM();
            bg.SetActive(true);
            _pause.SetActive(true);
            scale = Time.timeScale;
            player.updateMode = AnimatorUpdateMode.Normal;
            Time.timeScale = 0;
        }
    }

    public void changeMuteSprite(int i)
    {
        mute.GetComponent<Image>().sprite = mute_sprite[i];
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void playDestroy()
    {
        audioController.playDestroy();
    }
}


