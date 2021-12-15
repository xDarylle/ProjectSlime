using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration;
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), duration).setIgnoreTimeScale(true);
    }
}
