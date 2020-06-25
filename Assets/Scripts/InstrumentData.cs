using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstrumentData", menuName = "InstrumentData")]
public class InstrumentData : ScriptableObject {
    [SerializeField] AudioClip triangleTone = null;
    [SerializeField] AudioClip sineTone = null;

    public uint rootOffset;
    public int highOffset;
    public int thirdOffset;
    public bool triangular;
    public bool glissando;
    public bool sustain;

    public uint GetRootNote() {
        return rootOffset;
    }

    public uint GetThirdNote() {
        return (uint) (rootOffset + 4 + thirdOffset);
    }

    public uint GetFifthNote() {
        return rootOffset + 7;
    }

    public uint GetHighNote() {
        return (uint) (rootOffset + 12 + highOffset);
    }

    public float GetPitchLerp() {
        return glissando ? 0.1f : 1;
    }

    public float GetReleaseTime() {
        return sustain ? 1 : 0.2f;
    }

    public AudioClip GetTone() {
        return triangular ? triangleTone : sineTone;
    }

    void Reset() {
        rootOffset = 0;
        highOffset = 0;
        thirdOffset = 0;
        glissando = false;
        sustain = false;
        triangular = true;
    }
}
