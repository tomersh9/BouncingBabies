using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake() {
        if (FindObjectsOfType<MusicPlayer>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
    }
}
