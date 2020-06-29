using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Kalimba", menuName = "Kalimba")]
public class Kalimba : ScriptableObject {
    public UnityEvent tapEvent;
    public UnityEvent releaseEvent;

    public bool IsOctaveUp() {
        return Input.GetKey(KeyCode.Space);
    }

    public bool IsFlatted() {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    public bool UseNumberNotes() {
        return false;
    }
}
