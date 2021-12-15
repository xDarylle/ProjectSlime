using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public float duration;
    public GameObject title;
    public GameObject[] arrow;
    public GameObject start;

    void Awake()
    {
        StartCoroutine(titleAnim());
        StartCoroutine(LeftarrowAnim());
        StartCoroutine(RightarrowAnim());
    }

    IEnumerator titleAnim()
    {
        LeanTween.moveLocalY(title, 0, duration).setEase(LeanTweenType.easeInBounce);
        yield return null;
    }

    IEnumerator LeftarrowAnim()
    {
        LeanTween.moveLocalX(arrow[0], -289, duration).setEase(LeanTweenType.easeInBounce);
        yield return null;
    }

    IEnumerator RightarrowAnim()
    {
        LeanTween.moveLocalX(arrow[1], 289, duration).setEase(LeanTweenType.easeInBounce);
        yield return null;
    }

    IEnumerator startAnim()
    {
        yield return null;
    }
}
