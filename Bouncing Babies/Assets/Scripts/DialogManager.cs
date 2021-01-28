using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {
    
    [SerializeField] private GameObject pauseLabel;
    [SerializeField] private GameObject looseLabel;

    private bool _isPaused = false;

    private void Awake() {
        Time.timeScale = 1;
        pauseLabel.SetActive(false);
        looseLabel.SetActive(false);
    }

    public void OnPauseClick() {
        _isPaused = !_isPaused;
        pauseLabel.SetActive(_isPaused);

        //freeze time if paused
        if (_isPaused) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    public void ActivateLooseLabel() {
        Time.timeScale = 0;
        looseLabel.SetActive(true);
    }

    public void OnMenuClick() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
