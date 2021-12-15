using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    private Vector2 startPos, endPos;
    private float flyTime;
    public float flightDuration = 0.1f;
    public float distance = 1.25f;

    public float duration;
    public AudioController audioController;

    public Scorer scorer;

    public CameraScript cam;

    public bool isPowerUp = false;
    private float scale;

    public bool isRunning = false;

    float timer = 0;
    float timer2 = 0;

    private IEnumerator coroutinePU;
    private IEnumerator temp;

    private bool isExtended;

    public ParticleSystem effect;
    public ParticleSystem powerupEffect;

    public GameObject[] Players;

    private void Awake()
    {
        Players[PlayerPrefs.GetInt("Player")].SetActive(true);
    }

    private void Update()
    {

        if (Input.touchCount > 0 )
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (Input.GetTouch(0).position.x < Screen.width / 2 && transform.position.x > -distance)
                    if (!isRunning)
                        StartCoroutine(MoveTo("left"));

                if (Input.GetTouch(0).position.x > Screen.width / 2 && transform.position.x < distance)
                    if(!isRunning)
                        StartCoroutine(MoveTo("right"));

            }
        }
    }

    private IEnumerator MoveTo(string whereToFly)
    {
        isRunning = true;
        audioController.playSFX();
        effect.Play();
        switch (whereToFly)
        {
            case "left":
                flyTime = 0f;
                startPos = transform.position;
                endPos = new Vector2
                    (startPos.x - distance, transform.position.y);

                while (flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startPos, endPos, flyTime / flightDuration);
                    yield return null;
                    
                }
                isRunning = false;
                break;

            case "right":
                flyTime = 0f;
                startPos = transform.position;
                endPos = new Vector2
                    (startPos.x + distance, transform.position.y);

                while (flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startPos, endPos, flyTime / flightDuration);
                    yield return null;
                   
                }
                isRunning = false;
                break;
        }

    }

    public void powerUP()
    {
        cam.zoomout();
        isPowerUp = true;
        scale = Time.timeScale;
        audioController.playDash();
        

        if(isExtended)
            StopCoroutine(temp);

        coroutinePU = _powerup(scale);

        scorer.shakeScore();

        if (isRunning)
        {
            StartCoroutine(Delay());
        }

        if (!isRunning)
        {
            StartCoroutine(coroutinePU);
        }
    }

    public void extendPowerUp()
    {
        StopCoroutine(coroutinePU);
        isPowerUp = true;

        if (isExtended)
            StopCoroutine(temp);

        coroutinePU = _powerup(scale);

        if (isRunning)
        {
            StartCoroutine(DelayExtend());
        }
        if (!isRunning)
        {
            Time.timeScale = scale;
            StartCoroutine(coroutinePU);
        }
    }

    IEnumerator Delay()
    {
        if(isRunning)
        {
            timer += Time.unscaledDeltaTime;
        }

        yield return new WaitForSeconds(flightDuration-timer);

        timer = 0;

        StopCoroutine(coroutinePU);

        scale = Time.timeScale;
        coroutinePU = _powerup(scale);
        StartCoroutine(coroutinePU);
    }

    IEnumerator DelayExtend()
    {
        if (isRunning)
        {
            timer2 += Time.unscaledDeltaTime;
        }
        yield return new WaitForSeconds(flightDuration - timer2);

        timer2 = 0;
        
        Time.timeScale = scale;

        StopCoroutine(coroutinePU);

        coroutinePU = _powerup(scale);
        StartCoroutine(coroutinePU);
    }

    private IEnumerator _powerup(float scale)
    {
        powerupEffect.Play();
        Time.timeScale += 4;
        yield return new WaitForSeconds(duration);
        cam.zoomin();
        Time.timeScale = scale;
        temp = delayIsPowerUp();
        StartCoroutine(temp);
    }

    private IEnumerator delayIsPowerUp()
    {
        isExtended = true;
        yield return new WaitForSeconds(.5f);
        isExtended = false;
        isPowerUp = false;
    }

    public bool _isPowerUp()
    {
        return isPowerUp;
    }

    public float getY()
    {
        return transform.position.y;
    }

    public void disablePlayer()
    {
        gameObject.SetActive(false);
    }
}
