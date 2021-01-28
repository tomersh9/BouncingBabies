using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] private GameObject mainLabel;
    [SerializeField] private GameObject aboutLabel;

    private void Awake() {
        /*mainLabel.SetActive(true);
        aboutLabel.SetActive(false);*/
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OnAboutClick() {
        mainLabel.SetActive(false);
        aboutLabel.SetActive(true);
    }

    public void OnExitAbout() {
        aboutLabel.SetActive(false);
        mainLabel.SetActive(true);
    }
}