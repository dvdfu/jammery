using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tines : MonoBehaviour {
    [SerializeField] RectTransform tineContainer = null;
    [SerializeField] GameObject tinePrefab = null;

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
    }

    void AddTine(uint baseOffset, KeyCode keyCode) {
        Tine tine = Instantiate(tinePrefab, tineContainer).GetComponent<Tine>();
        tine.baseOffset = baseOffset;
        tine.keyCode = keyCode;
    }
}
