using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour {
    [SerializeField] Image icon = null;
    [SerializeField] Sprite enabledSprite = null;
    [SerializeField] Sprite disabledSprite = null;

    public void Set(bool enabled) {
        icon.sprite = enabled ? enabledSprite : disabledSprite;
    }
}
