using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerup;
    public Spawner spawner;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawner = References.spawner;
        int rand = Random.Range(3, 10);

        if (spawner.getTime() % rand == 0)
        {
            Instantiate(powerup, transform.position, Quaternion.identity);
            spawner.resetTimer();
        }
    }

    private void Update()
    {
        timer += Time.unscaledDeltaTime;
        if (timer >= 4f)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
}
