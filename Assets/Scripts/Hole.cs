using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    [SerializeField] Kalimba kalimba = null;
    [SerializeField] Animator animator = null;
    [SerializeField] Transform hole = null;

    Routine routine;

    public void OnTap() {
        routine.Start(TapRoutine());
    }

    public void OnRelease() {
        routine.Start(ReleaseRoutine());
    }

    void Start() {
        routine = new Routine(this);
        animator.Play("Idle");
    }

    void LateUpdate() {
        float targetY = kalimba.IsOctaveUp() ? 10 : -2;
        float y = Mathf.Lerp(animator.transform.localPosition.y, targetY, 0.5f);
        animator.transform.localPosition = Vector3.up * y;
    }

    IEnumerator TapRoutine() {
        yield return new WaitForSeconds(0.2f);
        animator.Play("Hold");
        float t = 0;
        while (t < 0.2f) {
            t += Time.deltaTime;
            float progress = t / 0.2f;
            float scale = 1 + 0.2f * Easing.CubicOut(1 - progress);
            hole.localScale = new Vector3(scale, 1 / scale, 1);
            yield return null;
        }
        hole.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator ReleaseRoutine() {
        animator.Play("Sing");
        float t = 0;
        while (t < 0.5f) {
            t += Time.deltaTime;
            float progress = t / 0.5f;
            float scale = 1 - 0.1f * Mathf.Cos(Time.time * 100) * Easing.CubicOut(1 - progress);
            hole.localScale = new Vector3(scale, 1 / scale, 1);
            yield return null;
        }
        hole.localScale = new Vector3(1, 1, 1);
        animator.Play("Idle");
    }
}
