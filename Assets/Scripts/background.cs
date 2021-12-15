using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public ObstacleObject obstacleobject;
    public float y;
    public float bottom;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * obstacleobject.speed * Time.deltaTime);

        if(transform.position.y <= -bottom)
        {
            transform.position = new Vector2(transform.position.x, y);
        }
    }
}
