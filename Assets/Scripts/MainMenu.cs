using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] Players;
    public SFX_Menu sfx;

    int i = 0;

    private void Awake()
    {
        Time.timeScale = 1f;   
    }

    public void Start()
    {
        i = PlayerPrefs.GetInt("Player");
        Players[i].SetActive(true);
    }

    public void LeftPlayer()
    {
        sfx.playClick();
        Players[i].SetActive(false);
        if(i <= 0)
        {
            i = Players.Length;
        }
        i--;

        Players[i].SetActive(true);
    }

    public void RightPlayer()
    {
        sfx.playClick();
        Players[i].SetActive(false);
        i++;
        if (i >= Players.Length)
        {
            i = 0;
        }

        Players[i].SetActive(true);
    }

    public void StartGame()
    {
        sfx.FadeBGM();
        PlayerPrefs.SetInt("Player", i);
        SceneManager.LoadScene("GamePlay");
    }


}
