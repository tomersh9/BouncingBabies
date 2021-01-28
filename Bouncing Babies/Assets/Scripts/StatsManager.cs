using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {
    
    //UI elements
    [SerializeField] private ScoreDisplay scoreDisplay;
    [SerializeField] private WaveDisplay waveDisplay;
    [SerializeField] private Image[] lifeIcons;

    //handling events
    private DeadZone _deadZone;
    private ScoreZone _scoreZone;
    private BabySpawner _babySpawner;
    private DialogManager _dialogManager;
    
    //privates
    private int _score = 0;
    private int _wave = 1;
    private int _lives = 3;

    //wave timing
    private float _timeToNextWave = 30f;
    private float _gameTimer;
    
    //events
    private void OnEnable() {
        _scoreZone.OnScoreAddEvent += AddToScore;
        _deadZone.OnBabyHitEvent += TakeDamage;
    }

    private void OnDisable() {
        _scoreZone.OnScoreAddEvent -= AddToScore;
        _deadZone.OnBabyHitEvent -= TakeDamage;
    }

    private void Awake() {
        _scoreZone = FindObjectOfType<ScoreZone>();
        _deadZone = FindObjectOfType<DeadZone>();
        _babySpawner = FindObjectOfType<BabySpawner>();
        _dialogManager = FindObjectOfType<DialogManager>();
    }

    private void Start() {
        _gameTimer = _timeToNextWave;
        SetUpUI();
    }
    
    private void Update() {
        _gameTimer -= Time.deltaTime;
        if (_gameTimer <= 0) {
            UpdateWave();
            _gameTimer = _timeToNextWave;
        }
    }

    private void SetUpUI() {
        waveDisplay.UpdateWaveDisplay(_wave);
        scoreDisplay.UpdateScoreDisplay(_score);
    }

    private void AddToScore(int points) {
        _score += points;
        scoreDisplay.UpdateScoreDisplay(_score);
    }
    
    private void UpdateWave() {
        waveDisplay.UpdateWaveDisplay(++_wave);
        _babySpawner.UpdateSpawnRate();
    }

    private void TakeDamage() {
        HealthUpdateUI();
        if (_lives <= 0) {
            GameOver();
        }
    }

    private void HealthUpdateUI() {
        Image currLifeIcon = lifeIcons[--_lives];
        currLifeIcon.enabled = false;
    }

    private void GameOver() {
        _dialogManager.ActivateLooseLabel();
    }
}
