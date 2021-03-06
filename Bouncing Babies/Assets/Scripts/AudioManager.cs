﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioClip babyJumpSfx;
    [SerializeField] private AudioClip babySpawnSfx;
    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioClip scoreSfx;
    
    private AudioSource _audioSource;
    
    #region Singleton
    private static AudioManager _instace;
    public static AudioManager GetInstance() => _instace;
    private void Awake() {
        if(FindObjectsOfType<AudioManager>().Length > 1) {
            Destroy(gameObject);
        } else {
            _instace = this;
            DontDestroyOnLoad(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
    }
    #endregion
    
    private void Start() {
        _audioSource.mute = !Preferences.GetToggleSfx();
    }

    public void ToggleSfx() => _audioSource.mute = !_audioSource.mute;
    
    public void PlayBabyJumpSfx() => _audioSource.PlayOneShot(babyJumpSfx,0.7f);
    public void PlayHitSfx() => _audioSource.PlayOneShot(hitSfx,0.75f);
    public void PlayBabySpawnSfx() => _audioSource.PlayOneShot(babySpawnSfx,0.75f);
    public void PlayScoreSfx() => _audioSource.PlayOneShot(scoreSfx,0.85f);
}
