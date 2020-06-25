using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSinger : MonoBehaviour {
    [SerializeField] InstrumentData instrument = null;
    [SerializeField] SpriteRenderer baseSprite = null;
    [SerializeField] Color yellow = Color.white;
    [SerializeField] Color red = Color.white;

    void LateUpdate() {
        float offset = instrument.highOffset;
        if (offset > 0) {
            baseSprite.color = BlendColors(yellow, Color.white, offset / 4);
        } else if (offset < 0) {
            baseSprite.color = BlendColors(yellow, red, -offset / 4);
        } else {
            baseSprite.color = yellow;
        }
    }

    Color BlendColors(Color a, Color b, float amount) {
        return a + (b - a) * amount;
    }
}
