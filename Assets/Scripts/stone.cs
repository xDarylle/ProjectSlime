using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stone : MonoBehaviour
{
    GameController gamecontroller;
    public ObstacleObject obstacleobject;
    Player player;
    Animator anim;

    void Start()
    {
        gamecontroller = References.gamecontroller;
        player = References.player;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Vector2.down * obstacleobject.speed * Time.deltaTime);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player._isPowerUp() || (player.GetComponent<Player>()._isPowerUp() && transform.position.y <= player.transform.position.y + .5))
            {
                gamecontroller.updateScore();
                anim.SetBool("hit", true);
                gamecontroller.playDestroy();
            }
            else
            {
                player.disablePlayer();
                gamecontroller.gameover();
            }
            
        }
        if(collision.CompareTag("Scorer"))
        {
            gamecontroller.updateScore();
        }
    }
}
