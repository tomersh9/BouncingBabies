using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BabySpawner : MonoBehaviour {
    [SerializeField] private GameObject babyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private float _spawnRate = 4.25f;
    private float _spawnRateCounter = 2f;
    private float _spawnRateFactor = 0.25f;

    private void SpawnBaby() {
        Instantiate(babyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        AudioManager.GetInstance().PlayBabySpawnSfx();
    }

    void Update() {
        if (_spawnRateCounter <= 0) {
            SpawnBaby();
            _spawnRateCounter = _spawnRate;
        }
        _spawnRateCounter -= Time.deltaTime;
    }

    //called from StatsManager
    public void UpdateSpawnRate() {
        _spawnRate -= _spawnRateFactor;
        if (_spawnRate <= 0.5f) {
            _spawnRate = 0.5f; //hardest setting
        }
    }
}