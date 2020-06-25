using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSinger : MonoBehaviour {
    [SerializeField] Singer singer = null;
    [SerializeField] InstrumentData instrument = null;
    [SerializeField] SpriteRenderer baseSprite = null;
    [SerializeField] Color darkBlue = Color.white;
    [SerializeField] Color lightBlue = Color.white;
    [SerializeField] Animator animator = null;
    [SerializeField] RuntimeAnimatorController smileAnimation = null;
    [SerializeField] RuntimeAnimatorController frownAnimation = null;

    void LateUpdate() {
        if (instrument.thirdOffset == 0) {
            baseSprite.color = lightBlue;
            animator.runtimeAnimatorController = smileAnimation;
        } else {
            baseSprite.color = darkBlue;
            animator.runtimeAnimatorController = frownAnimation;
        }
        if (singer.IsSinging()) {
            animator.Play("Sing");
        } else {
            animator.Play("Idle");
        }
    }
}
