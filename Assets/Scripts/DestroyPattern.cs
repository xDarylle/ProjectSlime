using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPattern : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if (timer >= 4f)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
}
