using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    public Volume volume;
    private float timer = 0f;

    public float nightduration;
    public float dayduration;
    private bool isNight = false;

    public Light2D pointLight;
    private float timeElapsed = 0;
    public float lerpduration;

    private void Update()
    {
        if(timer >= dayduration)
        {
            timer = 0;
            StartCoroutine(startCycle());
        }

        if(!isNight)
        {
            timer += Time.unscaledDeltaTime;
        }
    }

    IEnumerator startCycle()
    {
        isNight = true;

        StartCoroutine(startNight());
        yield return new WaitForSeconds(nightduration);
        isNight = false;
        StartCoroutine(startDay());

    }

    IEnumerator startNight()
    {
        timeElapsed = 0;
        while (timeElapsed < lerpduration)
        {
            volume.weight = Mathf.Lerp(0, 1, timeElapsed/lerpduration);
            pointLight.intensity = Mathf.Lerp(0, 3.99f, timeElapsed / lerpduration);
            timeElapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        volume.weight = 1f;
        print("night");
        
    }


    IEnumerator startDay()
    {
        timeElapsed = 0;
        pointLight.intensity = 0;
        while (timeElapsed < lerpduration)
        {
            volume.weight = Mathf.Lerp(1, 0, timeElapsed / lerpduration);
            timeElapsed += Time.unscaledDeltaTime;
            pointLight.intensity = Mathf.Lerp(3.99f, 0f, timeElapsed / lerpduration);
            yield return null;
        }
        
        volume.weight = 0f;

        print("day");
    }

    public void resetVolumeWeight()
    {
        volume.weight = 0f;
    }
}