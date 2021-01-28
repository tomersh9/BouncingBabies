using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour {
    
    private const string SFX = "sfx";
    private const string VOLUME = "volume";

    public static void ToggleSfx(bool toggle) {
        int result = 0;
        if (toggle) {
            result = 1;
        }
        PlayerPrefs.SetInt(SFX, result); // 0 mute, 1 volume
    }

    public static bool GetToggleSfx() => PlayerPrefs.GetInt(SFX) == 1; //is muted?

    public static void SetVolume(float volume) => PlayerPrefs.SetFloat(VOLUME, volume);

    public static float GetVolume() => PlayerPrefs.GetFloat(VOLUME); //called from MusicPlayer
}