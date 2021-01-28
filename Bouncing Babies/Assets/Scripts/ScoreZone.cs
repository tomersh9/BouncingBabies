using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    //event to StatsManager
    public delegate void ScoreAddedDelegate(int score);
    public event ScoreAddedDelegate OnScoreAddEvent;
    
    private void OnTriggerEnter2D(Collider2D other) {
        Baby baby = other.gameObject.GetComponent<Baby>();
        if (baby != null) {
            Destroy(baby.gameObject);
            OnScoreAddEvent?.Invoke(10);
            AudioManager.GetInstance().PlayScoreSfx();
        }
    }
}
