using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {
    [SerializeField] InstrumentData instrument = null;
    [SerializeField] Text chord = null;

    void LateUpdate() {
        chord.text = RootToChord();
    }

    string RootToChord() {
        string chord = "";
        uint root = instrument.GetRootNote() % 12;
        switch (root) {
            case 0: chord = "C"; break;
            case 1: chord = "C#"; break;
            case 2: chord = "D"; break;
            case 3: chord = "D#"; break;
            case 4: chord = "E"; break;
            case 5: chord = "F"; break;
            case 6: chord = "F#"; break;
            case 7: chord = "G"; break;
            case 8: chord = "G#"; break;
            case 9: chord = "A"; break;
            case 10: chord = "A#"; break;
            case 11: chord = "B"; break;
        }
        bool isMinor = instrument.thirdOffset == -1;
        if (isMinor) {
            chord += "m";
        }
        switch (instrument.highOffset) {
            case -3: chord += "6"; break;
            case -2: chord += "7"; break;
            case -1: chord += "M7"; break;
            case 1: chord += "b9"; break;
            case 2: chord += "9"; break;
        }
        return chord;
    }
}
