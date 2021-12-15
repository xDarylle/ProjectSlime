using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Player player;
    private GameController gamecontroller;
    public ObstacleObject obstacleobject;

    private void Start()
    {
        player = References.player;
        gamecontroller = References.gamecontroller;
    }

    void Update()
    {
        transform.Translate(Vector2.down * obstacleobject.speed * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {

                if (player._isPowerUp())
                {
                    player.extendPowerUp();
                }
                else
                {
                    player.powerUP();
                }

        }

        if (collision.CompareTag("Scorer"))
        {
            gamecontroller.updateScore();
        }
    }
}
