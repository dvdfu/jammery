using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squishable : MonoBehaviour {
    const float SQUISH_DURATION = 0.3f;
    const float SQUISH_AMOUNT = 0.4f;

    [SerializeField] Transform target = null;

    Coroutine coroutine;

    public void SquishWide() {
        if (coroutine != null) {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(SquishWideRoutine());
    }

    IEnumerator SquishWideRoutine() {
        float t = 0;
        while (t < SQUISH_DURATION) {
            float scale = 1 + (1 - Easing.ElasticOut(t / SQUISH_DURATION)) * SQUISH_AMOUNT;
            target.localScale = new Vector3(scale, 1 / scale, 1);
            t += Time.deltaTime;
            yield return null;
        }
        target.localScale = new Vector3(1, 1, 1);
        coroutine = null;
    }
}
