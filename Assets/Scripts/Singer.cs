using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer : MonoBehaviour {
    const float ATTACK_TIME = 0;
    const float DECAY_TIME = 0.05f;
    const float SUSTAIN_LEVEL = 0.75f;
    const float RELEASE_TIME = 0.2f;

    [SerializeField] InstrumentData instrument = null;
    [SerializeField] Animator animator = null;
    [SerializeField] LineRenderer line = null;
    [SerializeField] Squishable squishable = null;
    [SerializeField] AudioSource source = null;

    Coroutine routine;
    uint offset;
    bool isSinging;

    public void Attack() {
        if (routine != null) {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(AttackRoutine(ATTACK_TIME, DECAY_TIME, SUSTAIN_LEVEL));
    }

    public void Release() {
        if (routine != null) {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(ReleaseRoutine(SUSTAIN_LEVEL, RELEASE_TIME));
    }

    public void SetOffset(uint offset) {
        this.offset = offset;
    }

    public bool IsSinging() {
        return isSinging;
    }

    void LateUpdate() {
        Vector3 pos = transform.position;
        float y = Mathf.Lerp(pos.y,((int) offset) * 6 - 72, 0.5f);
        transform.position = new Vector3(pos.x, y);
        if (isSinging) {
            line.startColor = Color.white;
            line.endColor = Color.white;
        } else {
            line.startColor = Color.grey;
            line.endColor = Color.grey;
        }

        float pitch = Mathf.Pow(2, offset / 12f - 1);
        source.pitch = Mathf.Lerp(source.pitch, pitch, instrument.GetPitchLerp());
    }

    IEnumerator AttackRoutine(float attackTime, float decayTime, float sustainLevel) {
        isSinging = true;
        animator.Play("Sing");
        source.Play();
        squishable.SquishWide();
        float t = 0;
        while (t < attackTime) {
            source.volume = t / attackTime;
            t += Time.deltaTime;
            yield return null;
        }
        t = 0;
        while (t < decayTime) {
            source.volume = Mathf.Lerp(1, sustainLevel, t / decayTime);
            t += Time.deltaTime;
            yield return null;
        }
        source.volume = sustainLevel;
    }

    IEnumerator ReleaseRoutine(float sustainLevel, float releaseTime) {
        isSinging = false;
        animator.Play("Idle");
        float t = 0;
        while (t < releaseTime) {
            source.volume = Mathf.Lerp(sustainLevel, 0, t / releaseTime);
            t += Time.deltaTime;
            yield return null;
        }
        source.volume = 0;
        source.Stop();
    }
}
