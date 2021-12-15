using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pattern;
    private float timePerSpawn;
    public float startTimeSpawn = 0.2f;
    public float increaseTime;
    public GameController gamecontroller;
    private float timer = 0;

    void Update()
    {

            int rand = Random.Range(0, pattern.Length);
            if (timePerSpawn <= 0)
            {
                Instantiate(pattern[rand], transform.position, Quaternion.identity);
                timePerSpawn = startTimeSpawn;
            }
            else
            {
                timePerSpawn -= Time.deltaTime;
            }

        timer += Time.unscaledDeltaTime;
    }

    public void increaseTimeRespawn()
    {
        startTimeSpawn += increaseTime;
    }

    public float getTime()
    {
        return Mathf.Ceil(timer);
    }

    public void resetTimer()
    {
        timer = 0;
    }
}