using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    [SerializeField] InstrumentData instrument = null;
    [SerializeField] Singer rootSinger = null;
    [SerializeField] Singer thirdSinger = null;
    [SerializeField] Singer fifthSinger = null;
    [SerializeField] Singer highSinger = null;

    void Start() {
        instrument.triangular = true;
        instrument.glissando = false;
        instrument.sustain = false;
    }

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

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            instrument.triangular = !instrument.triangular;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            instrument.glissando = !instrument.glissando;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            instrument.sustain = !instrument.sustain;
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
            PlayRootNote();
        } else if (Input.GetKeyUp(KeyCode.U)) {
            StopRootNote();
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            PlayThirdNote();
        } else if (Input.GetKeyUp(KeyCode.I)) {
            StopThirdNote();
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            PlayFifthNote();
        } else if (Input.GetKeyUp(KeyCode.O)) {
            StopFifthNote();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            PlayHighNote();
        } else if (Input.GetKeyUp(KeyCode.P)) {
            StopHighNote();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            PlayRootNote();
            PlayThirdNote();
            PlayFifthNote();
        } else if (Input.GetKeyUp(KeyCode.Return)) {
            StopRootNote();
            StopThirdNote();
            StopFifthNote();
        }
    }

    bool IsRootNoteHeld() {
        return Input.GetKey(KeyCode.U) || Input.GetKey(KeyCode.Return);
    }

    bool IsThirdNoteHeld() {
        return Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.Return);
    }

    bool IsFifthNoteHeld() {
        return Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.Return);
    }

    bool IsHighNoteHeld() {
        return Input.GetKey(KeyCode.P);
    }

    void PlayRootNote() {
        rootSinger.Attack(instrument.GetTone());
    }

    void PlayThirdNote() {
        thirdSinger.Attack(instrument.GetTone());
    }

    void PlayFifthNote() {
        fifthSinger.Attack(instrument.GetTone());
    }

    void PlayHighNote() {
        highSinger.Attack(instrument.GetTone());
    }

    void StopRootNote() {
        if (!IsRootNoteHeld()) {
            rootSinger.Release();
        }
    }

    void StopThirdNote() {
        if (!IsThirdNoteHeld()) {
            thirdSinger.Release();
        }
    }

    void StopFifthNote() {
        if (!IsFifthNoteHeld()) {
            fifthSinger.Release();
        }
    }

    void StopHighNote() {
        if (!IsHighNoteHeld()) {
            highSinger.Release();
        }
    }
}
