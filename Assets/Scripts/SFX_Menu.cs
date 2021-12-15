using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX_Menu : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource click;
    public Button mute;
    public Sprite[] mute_sprite;
    private bool isMute = true;
    private int clicked = 0;

    private void Awake()
    {
        clicked = PlayerPrefs.GetInt("clicked");

        if (PlayerPrefs.GetInt("isMuted") == 0)
        {
            isMute = false;
        }

        if (PlayerPrefs.GetInt("isMuted") == 1)
        {
            isMute = true;
        }

        if (clicked > 0)
           changeMuteSprite(0);
        else
           changeMuteSprite(1);

    }

    private void Start()
    {
        if(!isMute)
        {
            bgm.Play();
        }
    }

    public void playClick()
    {
        if(!isMute)
        {
            click.Play();
        }
    }

    public void FadeBGM()
    {
        LeanTween.value(bgm.gameObject, bgm.volume, 0f, 0.2f).setOnUpdate((float flt) => {
            bgm.volume = flt;
        });
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
            changeMuteSprite(1);
            bgm.Play();
        }
        else if (clicked == 1)
        {
            isMute = true;
            PlayerPrefs.SetInt("isMuted", 1);
            PlayerPrefs.SetInt("clicked", 1);
            changeMuteSprite(0);
            bgm.Stop();
        }
    }

    public void changeMuteSprite(int i)
    {
        mute.GetComponent<Image>().sprite = mute_sprite[i];
    }
}
