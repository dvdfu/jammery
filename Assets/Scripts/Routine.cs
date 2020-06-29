using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine {
    MonoBehaviour mb;
    Coroutine coroutine;

    public Routine(MonoBehaviour mb) {
        this.mb = mb;
        coroutine = null;
    }

    public void Start(IEnumerator routine) {
        Stop();
        coroutine = mb.StartCoroutine(StartRoutine(routine));
    }

    public void StartIfReady(IEnumerator routine) {
        if (IsReady()) {
            Start(routine);
        }
    }

    public void Stop() {
        if (coroutine != null) {
            mb.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public bool IsReady() {
        return coroutine == null;
    }

    IEnumerator StartRoutine(IEnumerator routine) {
        yield return routine;
        coroutine = null;
    }
}
