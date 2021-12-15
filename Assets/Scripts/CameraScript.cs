using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float duration;
    public float magnitude;

    private Camera cam;
    public float speed;

    private void Start()
    {
        cam = Camera.main;  
    }

    public IEnumerator shake()
    {
        Vector3 original_pos = new Vector3(0, 0, -10);
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            float x = Random.Range(-0.4f, 0.5f) * magnitude;
            float y = Random.Range(-0.5f, 0.4f) * magnitude;

            transform.localPosition = new Vector3(x, y, original_pos.z);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.position = original_pos;
    }

    public IEnumerator gameoverShake(float time)
    {
        Vector3 original_pos = new Vector3(0, 0, -10);
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float x = Random.Range(-0.7f, 0.7f) * magnitude;
            float y = Random.Range(-0.7f, 0.7f) * magnitude;

            transform.localPosition = new Vector3(x, y, original_pos.z);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.position = original_pos;
    }

    public void extendshake()
    {
        StopAllCoroutines();
        StartCoroutine(shake());
    }

    public void zoomout()
    {
        LeanTween.value(cam.gameObject, cam.orthographicSize, 5.3f, speed).setOnUpdate((float flt) => {
            cam.orthographicSize = flt;
        });
    }

    public void zoomin()
    {
        LeanTween.value(cam.gameObject, cam.orthographicSize, 5f, 0.2f).setOnUpdate((float flt) => {
            cam.orthographicSize = flt;
        });
    }

}
