using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kalimba : MonoBehaviour {
    [SerializeField] RectTransform tineContainer = null;
    [SerializeField] Hole hole = null;
    [SerializeField] GameObject tinePrefab = null;

    bool isOctaveUp;
    bool useNumberNotes;

    public bool IsOctaveUp() {
        return isOctaveUp;
    }

    public bool IsFlatted() {
        return Input.GetKey(KeyCode.Space);
    }

    public bool UseNumberNotes() {
        return useNumberNotes;
    }

    public void OnTineTap() {
        hole.OnTap();
    }

    public void OnTineRelease() {
        hole.OnRelease();
    }

    void Start() {
        AddTine(16, KeyCode.Q);
        AddTine(12, KeyCode.W);
        AddTine(9, KeyCode.E);
        AddTine(5, KeyCode.R);
        AddTine(2, KeyCode.T);
        AddTine(0, KeyCode.Y);
        AddTine(4, KeyCode.U);
        AddTine(7, KeyCode.I);
        AddTine(11, KeyCode.O);
        AddTine(14, KeyCode.P);
        useNumberNotes = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
            isOctaveUp = !isOctaveUp;
        }
    }

    void AddTine(uint baseOffset, KeyCode keyCode) {
        Tine tine = Instantiate(tinePrefab, tineContainer).GetComponent<Tine>();
        tine.kalimba = this;
        tine.baseOffset = baseOffset;
        tine.keyCode = keyCode;
    }
}
