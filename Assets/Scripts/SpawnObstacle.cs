using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    float timer = 0;
    public GameObject[] obstacle;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[rand], transform.position, Quaternion.identity);
    }

    private void Update()
    {

        timer += Time.unscaledDeltaTime;
        if(timer >= 4f)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
}
