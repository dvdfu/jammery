using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tine : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler {
    readonly Color LIGHT_GREY = new Color(0.86f, 0.84f, 0.82f);

    public Kalimba kalimba;
    public uint baseOffset = 0;
    public KeyCode keyCode = KeyCode.Space;

    enum State {
        IDLE,
        PRESSED,
        PLAYING,
    }

    [SerializeField] RectTransform container = null;
    [SerializeField] Image image = null;
    [SerializeField] Text note = null;
    [SerializeField] AudioSource source = null;
    [SerializeField] AudioClip highNoteSound = null;
    [SerializeField] AudioClip noteSound = null;
    [SerializeField] AudioClip stopSound = null;

    State state;

    public void OnPointerDown(PointerEventData pointerEventData) {
        if (state != State.PRESSED) {
            Tap();
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData) {
        if (state == State.PRESSED) {
            Release();
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        if (state != State.PRESSED && Input.GetMouseButton(0)) {
            Tap();
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData) {
        if (state == State.PRESSED && Input.GetMouseButton(0)) {
            Release();
        }
    }

    public void Tap() {
        if (state == State.PLAYING) {
            source.clip = stopSound;
            source.Play();
        }
        state = State.PRESSED;
        kalimba.tapEvent.Invoke();
    }

    public void Release() {
        if (GetOffset() >= 12) {
            source.clip = highNoteSound;
            source.pitch = GetPitch() / 2;
        } else {
            source.clip = noteSound;
            source.pitch = GetPitch();
        }
        source.Play();
        state = State.PLAYING;
        kalimba.releaseEvent.Invoke();
    }

    void Awake() {
        state = State.IDLE;
    }

    void Update() {
        if (state != State.PRESSED && Input.GetKeyDown(keyCode)) {
            Tap();
        }
        if (state == State.PRESSED && Input.GetKeyUp(keyCode)) {
            Release();
        }

        if (state == State.PLAYING && !source.isPlaying) {
            state = State.IDLE;
        }
    }

    void LateUpdate() {
        float pitch = GetPitch();

        // Tine position
        float goalY = -48 - 120 / pitch;
        float y = Mathf.Lerp(container.anchoredPosition.y, goalY, 0.5f);
        container.anchoredPosition = new Vector2(container.anchoredPosition.x, y);

        // Tine vibration
        float x = 0;
        if (source.isPlaying) {
            float progress = source.time / noteSound.length;
            x = Mathf.Cos(Time.time * pitch * 100) * Easing.CubicOut(1 - progress);
        }
        image.rectTransform.anchoredPosition = Vector3.right * x;
        
        // Tine colour if held down
        if (state == State.PRESSED) {
            image.color = LIGHT_GREY;
        } else {
            image.color = Color.white;
        }

        // Tine note
        note.text = GetNoteString();
    }

    int GetOffset() {
        // 0 is low C
        int offset = (int) baseOffset;
        if (kalimba.IsFlatted()) {
            offset--;
        }
        if (kalimba.IsOctaveUp()) {
            offset += 12;
        }
        return offset;
    }

    float GetPitch() {
        int offset = GetOffset();
        return Mathf.Pow(2, offset / 12f);
    }

    string GetNoteString() {
        int offset = (GetOffset() + 12) % 12;
        if (kalimba.UseNumberNotes()) {
            switch (offset) {
                case 0: return "1";
                case 1: return "2b";
                case 2: return "2";
                case 3: return "3b";
                case 4: return "3";
                case 5: return "4";
                case 6: return "5b";
                case 7: return "5";
                case 8: return "6b";
                case 9: return "6";
                case 10: return "7b";
                case 11: return "7";
                default: return "";
            }
        }
        switch (offset) {
            case 0: return "C";
            case 1: return "Db";
            case 2: return "D";
            case 3: return "Eb";
            case 4: return "E";
            case 5: return "F";
            case 6: return "Gb";
            case 7: return "G";
            case 8: return "Ab";
            case 9: return "A";
            case 10: return "Bb";
            case 11: return "B";
            default: return "";
        }
    }
}
