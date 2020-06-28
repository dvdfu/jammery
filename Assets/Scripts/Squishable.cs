using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squishable : MonoBehaviour {
    [SerializeField] Transform target = null;
    [SerializeField] float squishDuration = 0.3f;
    [SerializeField] float squishAmount = 0.4f;

    Coroutine coroutine;

    public void SquishWide() {
        if (coroutine != null) {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(SquishWideRoutine());
    }

    IEnumerator SquishWideRoutine() {
        float t = 0;
        while (t < squishDuration) {
            float scale = 1 + (1 - Easing.ElasticOut(t / squishDuration)) * squishAmount;
            target.localScale = new Vector3(scale, 1 / scale, 1);
            t += Time.deltaTime;
            yield return null;
        }
        target.localScale = new Vector3(1, 1, 1);
        coroutine = null;
    }
}
