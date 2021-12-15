using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
   
    IEnumerator startShake()
    {
		float shakeAmt = GetComponent<RectTransform>().localPosition.y * 0.2f; // the degrees to shake the camera
		float shakePeriodTime = 0.3f; // The period of each shake
		float dropOffTime = 1.6f; // How long it takes the shaking to settle down to nothing
		LTDescr shakeTween = LeanTween.rotateAroundLocal(gameObject, Vector3.right, shakeAmt, shakePeriodTime)
		.setEase(LeanTweenType.easeShake) // this is a special ease that is good for shaking
		.setLoopClamp()
		.setRepeat(-1)
		.setIgnoreTimeScale(true);

		// Slow the camera shake down to zero
		LeanTween.value(gameObject, shakeAmt, 0f, dropOffTime).setOnUpdate(
			(float val) => {
				shakeTween.setTo(Vector3.right * val);
			}
		).setEase(LeanTweenType.easeOutQuad)
		.setIgnoreTimeScale(true);

		yield return null;
	}

	public void shakeScore()
    {
		StartCoroutine(startShake());
    }

}
