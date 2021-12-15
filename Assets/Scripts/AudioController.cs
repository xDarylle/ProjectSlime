using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource moveSFX;
    public AudioSource goSFX;
    public AudioSource gameoverr;
    public AudioSource destroy;
    public AudioSource dash;
    public AudioSource highscore;
    public GameController gameController;
    private bool isMute = false;
    private int clicked = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("isMuted") == 1)
            isMute = true;
        if (PlayerPrefs.GetInt("isMuted") == 0)
            isMute = false;

        playBGM();

        clicked = PlayerPrefs.GetInt("clicked");

        if (clicked > 0)
            gameController.changeMuteSprite(0);
        else
            gameController.changeMuteSprite(1);
    }
    public void stopBGM()
    {
        bgm.Stop();
    }

    public void playSFX()
    {
        if (!isMute)
            moveSFX.Play();
    }

    public void playGameOver()
    {
        if (!isMute)
        {
            goSFX.Play();
            gameoverr.Play();
        }
    }

    public void pauseBGM()
    {
        bgm.Pause();
    }

    public void playBGM()
    {
        if (!isMute)
            bgm.Play();
    }

    public void onClick()
    {
        clicked++;
        if (clicked == 2)
        {
            clicked = 0;
            isMute = false;
            PlayerPrefs.SetInt("isMuted", 0);
            PlayerPrefs.SetInt("clicked", clicked);
            gameController.changeMuteSprite(1);
            bgm.Play();
        }
        else if (clicked == 1)
        {
            isMute = true;
            PlayerPrefs.SetInt("isMuted", 1);
            PlayerPrefs.SetInt("clicked", 1);
            gameController.changeMuteSprite(0);
            stopBGM();
        }
    }

    public void playHigh()
    {
        if(!isMute)
           highscore.Play();
    }

    public void playDestroy()
    {
        if (!isMute)
        {
            destroy.time = 0.1f;
            destroy.Play();
        }
    }

    public void playDash()
    {
        if (!isMute)
        {
            dash.Play();
        }
    }
}
