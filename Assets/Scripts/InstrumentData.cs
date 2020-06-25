using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstrumentData", menuName = "InstrumentData")]
public class InstrumentData : ScriptableObject {
    public uint rootOffset;
    public int highOffset;
    public int thirdOffset;
    public float glissando;
    public bool triangular;

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
        return Mathf.Lerp(1, 0.1f, glissando);
    }
}
