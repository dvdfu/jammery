using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    [SerializeField] InstrumentData instrument = null;
    [SerializeField] Singer rootSinger = null;
    [SerializeField] Singer thirdSinger = null;
    [SerializeField] Singer fifthSinger = null;
    [SerializeField] Singer highSinger = null;

    void Update() {
        rootSinger.SetOffset(instrument.GetRootNote());
        thirdSinger.SetOffset(instrument.GetThirdNote());
        fifthSinger.SetOffset(instrument.GetFifthNote());
        highSinger.SetOffset(instrument.GetHighNote());

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            instrument.rootOffset = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            instrument.rootOffset = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            instrument.rootOffset = 4;
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            instrument.rootOffset = 5;
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            instrument.rootOffset = 7;
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            instrument.rootOffset = 9;
        } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            instrument.rootOffset = 11;
        } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            instrument.rootOffset = 12;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            instrument.thirdOffset = -1;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            instrument.thirdOffset = 0;
        }

        if (Input.GetKey(KeyCode.R)) {
            instrument.highOffset = 4;
        } else if (Input.GetKey(KeyCode.E)) {
            instrument.highOffset = 3;
        } else if (Input.GetKey(KeyCode.W)) {
            instrument.highOffset = 2;
        } else if (Input.GetKey(KeyCode.Q)) {
            instrument.highOffset = 1;
        } else if (Input.GetKey(KeyCode.F)) {
            instrument.highOffset = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            instrument.highOffset = -2;
        } else if (Input.GetKey(KeyCode.S)) {
            instrument.highOffset = -3;
        } else if (Input.GetKey(KeyCode.A)) {
            instrument.highOffset = -4;
        } else {
            instrument.highOffset = 0;
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            SetRootNote(true);
        } else if (Input.GetKeyUp(KeyCode.U)) {
            SetRootNote(false);
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            SetThirdNote(true);
        } else if (Input.GetKeyUp(KeyCode.I)) {
            SetThirdNote(false);
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            SetFifthNote(true);
        } else if (Input.GetKeyUp(KeyCode.O)) {
            SetFifthNote(false);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            SetHighNote(true);
        } else if (Input.GetKeyUp(KeyCode.P)) {
            SetHighNote(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            SetRootNote(true);
            SetThirdNote(true);
            SetFifthNote(true);
            SetHighNote(true);
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            SetRootNote(false);
            SetThirdNote(false);
            SetFifthNote(false);
            SetHighNote(false);
        }
    }

    bool IsRootNoteHeld() {
        return Input.GetKey(KeyCode.U) || Input.GetKey(KeyCode.UpArrow);
    }

    bool IsThirdNoteHeld() {
        return Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow);
    }

    bool IsFifthNoteHeld() {
        return Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.UpArrow);
    }

    bool IsHighNoteHeld() {
        return Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.UpArrow);
    }

    void SetRootNote(bool playing) {
        if (playing) {
            rootSinger.Attack();
        } else if (!IsRootNoteHeld()) {
            rootSinger.Release();
        }
    }

    void SetThirdNote(bool playing) {
        if (playing) {
            thirdSinger.Attack();
        } else if (!IsThirdNoteHeld()) {
            thirdSinger.Release();
        }
    }

    void SetFifthNote(bool playing) {
        if (playing) {
            fifthSinger.Attack();
        } else if (!IsFifthNoteHeld()) {
            fifthSinger.Release();
        }
    }

    void SetHighNote(bool playing) {
        if (playing) {
            highSinger.Attack();
        } else if (!IsHighNoteHeld()) {
            highSinger.Release();
        }
    }
}
